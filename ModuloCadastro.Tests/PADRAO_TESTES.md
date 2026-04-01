# PADRAO_TESTES.md

Este documento define a estrutura e as convencoes para testes automatizados neste projeto (.NET 8, xUnit, EF Core InMemory).

---

## OBJETIVO

* Garantir consistencia entre projetos de testes
* Facilitar manutencao e leitura
* Promover boas praticas de testes unitarios
* Separar responsabilidades claramente

---

## ESTRUTURA DE PASTAS

```
ModuloCadastro.Tests/
├── Services/
│   └── ClienteServiceTests.cs
├── Entity/
│   └── ClienteTests.cs
├── Geral/
│   ├── Fixtures/
│   ├── Builders/
│   │   └── ClienteBuilder.cs
│   └── Mocks/
└── ModuloCadastro.Tests.csproj
```

---

## REGRAS GERAIS

### Um projeto de teste por projeto principal

```
ModuloCadastro  ->  ModuloCadastro.Tests
```

### Espelhar a estrutura (quando fizer sentido)

A estrutura de pastas dentro do projeto de testes deve refletir a estrutura do projeto original.
Nao e obrigatorio copiar tudo. Apenas o que precisa ser testado.

### Nomeacao dos arquivos

Sempre terminar com "Tests":

```
ClienteServiceTests.cs
PedidoServiceTests.cs
```

### Nomeacao dos metodos

Padrao: `Metodo_Condicao_ResultadoEsperado()`

```
Get_QuandoClienteExiste_DeveRetornarClienteComCidadeEEstado()
GetList_QuandoBancoVazio_DeveRetornarListaVazia()
Update_QuandoClienteExiste_DeveAtualizarDadosNoBanco()
```

---

## DEPENDENCIAS

```xml
<PackageReference Include="xunit" Version="2.5.3" />
<PackageReference Include="FluentAssertions" Version="6.12.0" />
<PackageReference Include="Moq" Version="4.20.70" />
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="8.0.0" />
```

Sempre adicionar referencia ao projeto sendo testado:

```xml
<ProjectReference Include="..\ModuloCadastro\ModuloCadastro.csproj" />
```

---

## ESTRUTURA DE UMA CLASSE DE TESTE

```csharp
public class ClienteServiceTests
{
    private static int GerarIdAleatorio() => new Random().Next(0, 101);

    private (ModuloCadastroContext context, int idInicial) CriarContexto()
    {
        int idInicial = GerarIdAleatorio();
        var options = new DbContextOptionsBuilder<ModuloCadastroContext>()
            .UseInMemoryDatabase("ClienteServiceTests")
            .Options;
        var context = new ModuloCadastroContext(options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        // seed minimo necessario para os testes
        context.Set<AutoNumeradorEntity>().Add(new AutoNumeradorEntity { IdCliente = idInicial });
        context.SaveChanges();
        return (context, idInicial);
    }

    [Fact]
    public void Get_QuandoClienteExiste_DeveRetornarCliente()
    {
        // Arrange
        var (context, _) = CriarContexto();
        var cliente = new ClienteBuilder().ComRazaoSocial("Empresa ABC").Build();
        cliente.Id = 1;
        context.Set<ClienteEntity>().Add(cliente);
        context.SaveChanges();
        var service = new ClienteService(context);

        // Act
        var resultado = service.Get(1);

        // Assert
        resultado.Should().NotBeNull();
        resultado.RazaoSocial.Should().Be("Empresa ABC");
    }
}
```

---

## PADRAO DE CONTEXTO INMEMORY

Usar `UseInMemoryDatabase` com nome fixo por classe + `EnsureDeleted()` no inicio do setup para garantir isolamento entre testes.

```csharp
var options = new DbContextOptionsBuilder<ModuloCadastroContext>()
    .UseInMemoryDatabase("NomeDaClasseTests") // nome fixo por classe
    .Options;
var context = new ModuloCadastroContext(options);
context.Database.EnsureDeleted(); // limpa estado anterior
context.Database.EnsureCreated();
```

### Acesso aos DbSets

Os DbSets de `ModuloCadastroContext` sao `internal`. Usar sempre `context.Set<TEntity>()`:

```csharp
// correto
context.Set<ClienteEntity>().Add(cliente);
context.Set<ClienteEntity>().Find(id);

// nao funciona fora do assembly
context.Clientes.Add(cliente);
```

### Seed minimo por contexto

Incluir apenas o que os testes precisam. Exemplo para testes de cliente:

```csharp
context.Set<AutoNumeradorEntity>().Add(new AutoNumeradorEntity { IdCliente = idInicial });
context.Set<EstadoEntity>().Add(new EstadoEntity { Cuf = 35, Uf = "SP", Nome = "Sao Paulo" });
context.Set<CidadeEntity>().Add(new CidadeEntity { Id = 1, Cuf = 35, Cmunicipio = "3550308", Dmunicipio = "Sao Paulo" });
```

### GerarIdAleatorio

Usar numero aleatorio entre 0 e 100 como valor inicial do IdCliente no AutoNumerador. Isso garante que os testes validem o comportamento de incremento com valores variados, nao apenas partindo de zero.

```csharp
private static int GerarIdAleatorio() => new Random().Next(0, 101);
```

---

## BUILDERS

Usar Builders para construir entidades com defaults sensiveis. Campos `varchar` nao anulaveis devem ter valor vazio como default para nao violar constraints do InMemory.

```csharp
public class ClienteBuilder
{
    private string _razaoSocial = "Cliente Teste";
    private int _cidadeId = 1;
    private int _estadoId = 35;

    public ClienteBuilder ComRazaoSocial(string valor) { _razaoSocial = valor; return this; }
    public ClienteBuilder ComCidadeId(int id) { _cidadeId = id; return this; }

    public ClienteEntity Build() => new ClienteEntity
    {
        RazaoSocial = _razaoSocial,
        CidadeId = _cidadeId,
        EstadoId = _estadoId,
        End_nomeRua = "",    // campos varchar nao anulaveis precisam de valor
        End_bairro = "",
        End_numero = "",
        End_logradouro = "",
        DataCadastro = DateTime.Now,
        Excluido = false
    };
}
```

---

## ORGANIZACAO POR TIPO DE TESTE

**Testes Unitarios (InMemory)**
* Foco em Services isolados
* Banco InMemory como substituto do MySQL
* Nao requerem conexao externa

**Testes de Integracao** (nao implementados ainda)
* Acessam banco de dados real
* Validam fluxo completo incluindo MySQL

---

## LIMITACOES CONHECIDAS

### ServiceMethods.UpdateParcial

`ServiceMethods.UpdateParcial` e estatico e cria `new ModuloCadastroContext()` internamente sem receber injecao de provider. Qualquer metodo de service que o chame internamente nao e testavel com InMemory:

- `ClienteService.Insert` — chama `ServiceMethods.UpdateParcial` no AutoNumerador
- `ClienteService.UpdateParcial` — delega diretamente para `ServiceMethods.UpdateParcial`

Nesses casos, documentar no arquivo de teste como comentario e nao criar testes para esses metodos ate que `ServiceMethods` seja refatorado para aceitar injecao de contexto.

---

## BOAS PRATICAS

**AAA (Arrange, Act, Assert)** — separar claramente as tres secoes em todo teste

**Evite logica dentro dos testes** — testes devem ser lineares e previsıveis

**Limpe o ChangeTracker entre operacoes** — ao buscar dados apos uma escrita no mesmo contexto:

```csharp
context.ChangeTracker.Clear(); // evita que EF retorne entidade em cache
```

**Teste comportamento, nao implementacao**
* Nao testar metodos privados
* Nao acoplar testes a detalhes internos

---

## O QUE EVITAR

* Testes dependentes entre si
* Compartilhar instancia de contexto entre testes (usar `EnsureDeleted`)
* Deixar campos `varchar` nao anulaveis sem valor (InMemory enforcea nullability)
* Usar `with {}` em entidades — funciona apenas com `record`, nao com `class`
* Acessar DbSets diretamente pelo nome da propriedade (sao `internal`)

---

## EXECUTAR OS TESTES

```bash
dotnet test ModuloCadastro.Tests/ModuloCadastro.Tests.csproj

# com output detalhado
dotnet test ModuloCadastro.Tests/ --logger "console;verbosity=detailed"
```
