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
├── Factory/
│   └── DbContextFactoryFake.cs     # IDbContextFactory<> fake para injeção nos services
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

Os services recebem `IDbContextFactory<ModuloCadastroContext>`. Usar `DbContextFactoryFake` para injeção e retornar o `options` junto com o `context` para que o fake possa ser criado depois:

```csharp
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;                          // AutoNumeradorEntity
using ModuloCadastro.Entity.Cadastro.Cliente;         // ClienteEntity
using ModuloCadastro.Entity.Cadastro.Localizacao;     // CidadeEntity, EstadoEntity
using ModuloCadastro.Service.Cadastro.Cliente;        // ClienteService
using ModuloCadastro.Tests.Factory;
using ModuloCadastro.Tests.Geral.Builders;

public class ClienteServiceTests
{
    private static int GerarIdAleatorio() => new Random().Next(0, 101);

    private (DbContextOptions<ModuloCadastroContext> options, ModuloCadastroContext context, int idInicial) CriarContexto()
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
        context.Set<EstadoEntity>().Add(new EstadoEntity { Cuf = 35, Uf = "SP", Nome = "Sao Paulo" });
        context.Set<CidadeEntity>().Add(new CidadeEntity { Id = 1, Cuf = 35, Cmunicipio = "3550308", Dmunicipio = "Sao Paulo" });
        context.SaveChanges();
        return (options, context, idInicial);
    }

    [Fact]
    public void Get_QuandoClienteExiste_DeveRetornarCliente()
    {
        // Arrange
        var (options, context, _) = CriarContexto();
        var cliente = new ClienteBuilder().ComRazaoSocial("Empresa ABC").Build();
        cliente.Id = 1;
        context.Set<ClienteEntity>().Add(cliente);
        context.SaveChanges();
        var service = new ClienteService(new DbContextFactoryFake(options));

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

Usar `UseInMemoryDatabase` com nome fixo por classe + `EnsureDeleted()` no inicio do setup para garantir isolamento entre testes. Retornar também o `options` para criar o `DbContextFactoryFake`:

```csharp
var options = new DbContextOptionsBuilder<ModuloCadastroContext>()
    .UseInMemoryDatabase("NomeDaClasseTests") // nome fixo por classe
    .Options;
var context = new ModuloCadastroContext(options);
context.Database.EnsureDeleted(); // limpa estado anterior
context.Database.EnsureCreated();
```

### DbContextFactoryFake

Os services recebem `IDbContextFactory<ModuloCadastroContext>`. Usar `DbContextFactoryFake` com o mesmo `options` do contexto de teste para que o service acesse o mesmo banco InMemory:

```csharp
// Factory/DbContextFactoryFake.cs
public class DbContextFactoryFake : IDbContextFactory<ModuloCadastroContext>
{
    private readonly DbContextOptions<ModuloCadastroContext> _options;
    public DbContextFactoryFake(DbContextOptions<ModuloCadastroContext> options) => _options = options;
    public ModuloCadastroContext CreateDbContext() => new ModuloCadastroContext(_options);
}

// Uso nos testes
var factory = new DbContextFactoryFake(options);
var service = new ClienteService(factory);
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

Incluir apenas o que os testes precisam. Exemplo para testes de cliente (namespaces: `AutoNumeradorEntity` em `ModuloCadastro.Entity`; `EstadoEntity`/`CidadeEntity` em `ModuloCadastro.Entity.Cadastro.Localizacao`):

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

Usar Builders para construir entidades com defaults sensiveis. Campos `varchar` nao anulaveis devem ter valor vazio como default para nao violar constraints do InMemory. O Builder deve importar o namespace correto da entidade (ex: `ModuloCadastro.Entity.Cadastro.Cliente` para `ClienteEntity`).

```csharp
using ModuloCadastro.Entity.Cadastro.Cliente;

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

## NAMESPACES DE REFERENCIA

A estrutura de pastas de Entity, Service e ViewModel espelha diretamente o namespace. Referência rápida para os usings mais comuns em testes:

| Tipo | Namespace |
|---|---|
| `AutoNumeradorEntity`, `BaseEntity` | `ModuloCadastro.Entity` |
| `ClienteEntity` | `ModuloCadastro.Entity.Cadastro.Cliente` |
| `CidadeEntity`, `EstadoEntity` | `ModuloCadastro.Entity.Cadastro.Localizacao` |
| `CategoriaEntity`, `EstoqueEntity`, `ProdutoEntity`, `SetorEstoqueEntity` | `ModuloCadastro.Entity.Cadastro.Produto` |
| `UsuarioEntity` | `ModuloCadastro.Entity.Cadastro.Usuario` |
| `AdquirenteBandeira`, `BancoEntity`, `ConfigAdquirenteEntity`, `MaquininhaEntity` | `ModuloCadastro.Entity.Financeiro` |
| `PedidoVendaEntity`, `ProdutoVendaEntity`, `RecebimentoVendaEntity` | `ModuloCadastro.Entity.Venda` |
| `ClienteService` | `ModuloCadastro.Service.Cadastro.Cliente` |
| `CidadeService`, `EstadoService` | `ModuloCadastro.Service.Cadastro.Localizacao` |
| `CategoriaService`, `EstoqueService`, `ProdutoService`, `SetorEstoqueService` | `ModuloCadastro.Service.Cadastro.Produto` |
| `UsuarioService` | `ModuloCadastro.Service.Cadastro.Usuario` |
| `BancoService`, `ConfigAdquirenteService`, `MaquininhaService` | `ModuloCadastro.Service.Financeiro` |
| `PedidoVendaService`, `ProdutoVendaService`, `RecebimentosVendaService` | `ModuloCadastro.Service.Venda` |
| `AutoNumeradorService`, `IService`, `ServiceMethods` | `ModuloCadastro.Service` |

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
- O mesmo vale para services similares (Produto, Banco, Maquininha, Adquirente, Pedido)

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
