# PADRAO_TESTES.md

Este documento define uma estrutura padrao para organizacao de testes automatizados em projetos .NET, com foco em clareza, escalabilidade e manutenibilidade.

---

##OBJETIVO

* Garantir consistencia entre projetos de testes
* Facilitar manutencao e leitura
* Promover boas praticas de testes unitarios
* Separar responsabilidades claramente

---

##ESTRUTURA DE PASTAS

├── MeuProjeto.Tests
│   ├── Services
│   │   ├── ClienteServiceTests.cs
│   │   │   
│   │
│   ├── Entity
│   │   ├── ClienteTests.cs
│   │   │   
│   │
│   ├── Geral
│   │   ├── Fixtures
│   │   ├── Builders
│   │   └── Mocks
│   │
│   └── MeuProjeto.Tests.csproj

---

# REGRAS GERAIS

## Um projeto de teste por projeto principal

Para cada projeto principal, deve existir um correspondente de testes:

Projeto Principal       -> Projeto de Teste
MeuProjeto.Application  -> MeuProjeto.Tests

---

## Espelhar a estrutura (quando fizer sentido)

A estrutura de pastas dentro do projeto de testes deve refletir a estrutura do projeto original.

Nao e obrigatorio copiar tudo. Apenas o que precisa ser testado.

---

## Nomeacao dos arquivos

Sempre terminar com "Tests"

Exemplos:
ClienteServiceTests.cs
PedidoRepositoryTests.cs

---

## Nomeacao dos metodos

Padrao recomendado:

Metodo_Condicao_ResultadoEsperado()

Exemplo:
CriarCliente_QuandoDadosValidos_DeveSalvarComSucesso()

---

# ESTRUTURA DE UMA CLASSE DE TESTE

public class ClienteServiceTests
{
private readonly ClienteService _service;

```
public ClienteServiceTests()
{
    // Setup (Arrange global)
    _service = new ClienteService();
}

[Fact]
public void CriarCliente_QuandoDadosValidos_DeveSalvarComSucesso()
{
    // Arrange
    var cliente = new Cliente { Nome = "Joao" };

    // Act
    var resultado = _service.Criar(cliente);

    // Assert
    Assert.True(resultado);
}
```

}

---

# ORGANIZACAO POR TIPO DE TESTE

Testes Unitarios

* Foco em classes isoladas
* Uso de mocks (ex: Moq)

Testes de Integracao

* Acessam banco de dados real ou em memoria
* Validam fluxo completo

Sugestao:

/tests
├── MeuProjeto.UnitTests
├── MeuProjeto.IntegrationTests

---

# BOAS PRATICAS

AAA (Arrange, Act, Assert)

Sempre separar claramente:

// Arrange
// Act
// Assert

Evite logica dentro dos testes

Use Builders para objetos complexos

var cliente = new ClienteBuilder()
.ComNome("Joao")
.Build();

Centralize mocks e fixtures

Common/
├── Mocks/
├── Fixtures/
└── Builders/

Teste comportamento, nao implementacao

Evite:

* Testar metodos privados
* Acoplar testes a implementacao interna

---

# O QUE EVITAR

* Testes dependentes entre si
* Uso de dados reais sem controle
* Testes muito grandes
* Repeticao de codigo

---

# DEPENDENCIAS COMUNS

* xUnit
* Moq
* FluentAssertions

---

# CONCLUSAO

Seguindo esse padrao voce garante:

* Organizacao consistente
* Testes faceis de manter
* Melhor legibilidade
* Facilidade para novos desenvolvedores

---
