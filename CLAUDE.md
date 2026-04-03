# CLAUDE.md

Este arquivo fornece orientação para o Claude Code (claude.ai/code) ao trabalhar com código neste repositório.

## Comportamento do Claude Code

- Sempre seguir as regras deste arquivo
- Se detectar violacao, corrigir automaticamente
- Priorizar consistência com a arquitetura existente
- Nunca sugerir alternativas que quebrem o padrão do projeto

## CLAUDEIGNORE.md
Este arquivo tem toda a relação dos arquivos que o Claude Code deve ignorar ao realizar tarefas, sendo estritamente rigoroso em não ler nenhum arquivo presente nessa lista, salvo em casos que seja fornecido manualmente o contexto.

## EVITAR.md
Registro de práticas que geraram retrabalho em sessões anteriores. **Deve ser lido obrigatoriamente antes de iniciar qualquer operação que envolva:** renomear namespaces, mover arquivos em lote, atualizar múltiplas camadas simultaneamente, executar scripts de substituição em massa, ou qualquer refatoração que impacte mais de 5 arquivos. Ao identificar que o usuário está planejando uma dessas operações, consultar o arquivo e alertar sobre os pontos relevantes antes de prosseguir.

## Linguagem

- Todas as respostas devem ser em português (Brasil)
- Manter nomes técnicos conforme o código

## Visão Geral do Projeto

Sistema ERP desenvolvido em C# (.NET 8) e Windows Forms (WinForms), voltado para casos de uso de varejo/vendas no Brasil. A interface do usuário, as entidades de domínio, os serviços e as colunas do banco de dados estão todos escritos em português.

## Compilar e Executar

# ORDEM DE COMPILACAO
Entities
DbContext
Migrations (Snapshot + Designer)
Services
ViewModels
UI
Testes

```bash
# Build the solution
dotnet build SistemaERP/SistemaERP.sln

# Run the application
dotnet run --project SistemaERP/SistemaERP.csproj

# Aplicar migrações pendentes do EF Core
dotnet ef database update --project ModuloCadastro

# Rodar testes
dotnet test ModuloCadastro.Tests/ModuloCadastro.Tests.csproj
```

## Arquitetura

A solução tem quatro projetos:

| Project | Role |
|---|---|
| `SistemaERP` | WinForms UI — MDI host (`TelaInicial`) with child forms per feature |
| `ModuloCadastro` | Business logic: Entities, Services, ViewModels, EF Core DbContext, Migrations |
| `Configuracoes` (ModuloConfiguracoes) | Shared: connection string, enum/extension utilities |
| `ModuloCadastro.Tests` | Testes automatizados do ModuloCadastro (xUnit, EF Core InMemory) |

**Data flow:** WinForms form → Service → EF Core DbContext → MySQL

### Key layers in `ModuloCadastro`

As pastas **Entity/**, **Service/** e **ViewModel/** seguem a mesma hierarquia semântica, e os namespaces espelham exatamente o caminho de pasta:

```
Entity/
├── AutoNumeradorEntity.cs          (ModuloCadastro.Entity)
├── BaseEntity.cs                   (ModuloCadastro.Entity)
├── Financeiro/                     (ModuloCadastro.Entity.Financeiro)
│   ├── AdquirenteBandeira.cs
│   ├── BancoEntity.cs
│   ├── ConfigAdquirenteEntity.cs
│   └── MaquininhaEntity.cs
├── Cadastro/
│   ├── Cliente/                    (ModuloCadastro.Entity.Cadastro.Cliente)
│   │   └── ClienteEntity.cs
│   ├── Localizacao/                (ModuloCadastro.Entity.Cadastro.Localizacao)
│   │   ├── CidadeEntity.cs
│   │   └── EstadoEntity.cs
│   ├── Produto/                    (ModuloCadastro.Entity.Cadastro.Produto)
│   │   ├── CategoriaEntity.cs
│   │   ├── EstoqueEntity.cs
│   │   ├── ProdutoEntity.cs
│   │   └── SetorEstoqueEntity.cs
│   └── Usuario/                    (ModuloCadastro.Entity.Cadastro.Usuario)
│       └── UsuarioEntity.cs
└── Venda/                          (ModuloCadastro.Entity.Venda)
    ├── PedidoVendaEntity.cs
    ├── ProdutoVendaEntity.cs
    └── RecebimentoVendaEntity.cs

Service/
├── IService.cs                     (ModuloCadastro.Service)
├── ServiceMethods.cs               (ModuloCadastro.Service)
├── AutoNumeradorService.cs         (ModuloCadastro.Service)
├── Financeiro/                     (ModuloCadastro.Service.Financeiro)
│   ├── BancoService.cs
│   ├── ConfigAdquirenteService.cs
│   └── MaquininhaService.cs
├── Cadastro/
│   ├── Cliente/                    (ModuloCadastro.Service.Cadastro.Cliente)
│   │   └── ClienteService.cs
│   ├── Localizacao/                (ModuloCadastro.Service.Cadastro.Localizacao)
│   │   ├── CidadeService.cs
│   │   └── EstadoService.cs
│   ├── Produto/                    (ModuloCadastro.Service.Cadastro.Produto)
│   │   ├── CategoriaService.cs
│   │   ├── EstoqueService.cs
│   │   ├── ProdutoService.cs
│   │   └── SetorEstoqueService.cs
│   └── Usuario/                    (ModuloCadastro.Service.Cadastro.Usuario)
│       └── UsuarioService.cs
└── Venda/                          (ModuloCadastro.Service.Venda)
    ├── PedidoVendaService.cs
    ├── ProdutoVendaService.cs
    └── RecebimentosVendaService.cs

ViewModel/
├── Financeiro/                     (ModuloCadastro.ViewModel.Financeiro)
│   └── BancoViewModel.cs
├── Cadastro/
│   ├── Cliente/                    (ModuloCadastro.ViewModel.Cadastro.Cliente)
│   │   └── ClienteViewModel.cs
│   ├── Produto/                    (ModuloCadastro.ViewModel.Cadastro.Produto)
│   │   ├── CategoriaViewModel.cs
│   │   ├── EstoqueViewModel.cs
│   │   └── ProdutoViewModel.cs
│   └── Usuario/                    (ModuloCadastro.ViewModel.Cadastro.Usuario)
│       └── UsuarioViewModel.cs
└── Venda/                          (ModuloCadastro.ViewModel.Venda)
    ├── PedidoVendaViewModel.cs
    └── ProdutoVendaViewModel.cs
```

- **Entity/** — EF Core model classes mapped to `tb_*` MySQL tables; namespace alinhado à subpasta
- **Service/** — Um service por entidade; alguns implementam `IService<T>`, outros têm métodos específicos; todo acesso ao banco passa pelos services; `IService.cs`, `ServiceMethods.cs` e `AutoNumeradorService.cs` ficam na raiz `ModuloCadastro.Service`
- **ViewModel/** — DTOs leves com `INotifyPropertyChanged`; entidades expõem `ToViewModel()` e ViewModels expõem `ToEntity()`
- **Enum/** — Constantes de domínio (`EFormaPagamento`, `EAdquirenteMaquininha`, `EBandeiraCartao`, `ECargo`, `ECst`, `EOrigemProduto`, `ETipoChavePix`, `ETipoContaBanco`, `ETipoMaquininha`, `ETipoTransferencia`, `EUnidadeProduto`, `EGatewayPDV`, `ETipoPedido`)
- **Context/ModuloCadastroContext.cs** — Single DbContext; todos os DbSets são `internal`; injetado via `IDbContextFactory<ModuloCadastroContext>` nos services
- **DTO/** — Data Transfer Objects para operações específicas

> **Regra de namespace:** ao criar novos arquivos em Entity/, Service/ ou ViewModel/, o namespace deve sempre refletir o caminho da subpasta. Ex: um service em `Service/Cadastro/Produto/` deve declarar `namespace ModuloCadastro.Service.Cadastro.Produto`.

### UI conventions

- Formulários são organizados sob `SistemaERP/Cadastros/<Module>/` e `SistemaERP/Venda/`
- Formulários de recibo de pagamento ficam em `SistemaERP/Venda/Recebimento/`, um formulário por método de pagamento
- Formulários genéricos reutilizáveis estão em `SistemaERP/Generico/`

### Injeção de Dependência (DI)

O projeto usa `Microsoft.Extensions.DependencyInjection`. O container é configurado em `Program.cs` via dois métodos de extensão em `SistemaERP/DI/DependencyInjectionRegistryClass.cs`:

- **`AddServices()`** — registra automaticamente via reflection todos os tipos que implementam `IService<T>`, tanto pelo tipo concreto quanto pela interface
- **`AddForms()`** — registra automaticamente todos os `Form` do assembly como `Transient`; também registra `IFormFactory` como `Singleton`

O `IDbContextFactory<ModuloCadastroContext>` é registrado em `Program.cs` e injetado nos services. Cada operação de service cria seu próprio contexto via `_factory.CreateDbContext()`:

```csharp
service.AddDbContextFactory<ModuloCadastroContext>(
    optionsBuilder => optionsBuilder.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(5, 7)),
        options => options.EnableRetryOnFailure()
    )
);
```

### FormFactory

`SistemaERP/Factory/IFormFactory` e `FormFactory` permitem instanciar formulários com dependências resolvidas pelo container, inclusive passando parâmetros de runtime:

```csharp
// sem parâmetro de runtime
_formFactory.Criar<formDetalhesCliente>().ShowDialog();

// com parâmetro de runtime (ex: id para edição)
_formFactory.Criar<formDetalhesCliente>(id).ShowDialog();
```

Usar sempre `_formFactory.Criar<T>(...)` ao abrir formulários filhos — nunca `new formXxx(...)` diretamente.

### Padrão de construtor dos formulários

Todo formulário deve:
1. Declarar `private readonly [ClassNameService] _service;`
2. Receber o service via construtor (injetado pelo DI)
3. Nunca instanciar services internamente com `new`

```csharp
public partial class formGerenciarXxx : Form
{
    private readonly XxxService _service;

    public formGerenciarXxx(XxxService service)
    {
        _service = service;
        InitializeComponent();
    }
}
```

Para formulários com múltiplos services, nomear os campos de forma descritiva: `_serviceEstoque`, `_serviceProduto`, etc.

## Database

- MySQL on `localhost:3306`, database `erp_simples`
- Connection string is hard-coded in `Configuracoes/ConfiguracoesGerais.cs`
- EF Core migrations are in `ModuloCadastro/Migrations/`
- Auto-increment IDs for clients/orders are managed through the `tb_autonumerador` table (`AutoNumeradorEntity`), not MySQL `AUTO_INCREMENT`

## Destaques do Domínio

- **Vendas** (`tb_vendas`, `tb_produtosvenda`) — pedidos com itens de linha, vinculados ao cliente; rastreiam 4 usuários distintos: criação, atualização, fechamento e exclusão
- **Pagamentos** (`tb_recebimento_venda`) — aceita dinheiro, cheque, boleto, transferência, PIX, crédito na loja, cartão de débito, cartão de crédito (8 formas via `EFormaPagamento`)
- **Processamento de cartão** — adquirentes (`tb_config_adquirente`), maquininhas (`tb_maquininhas`), e bandeiras de cartão (`tb_adquirente_bandeira`) são configuradas separadamente; `ConfigAdquirenteEntity` implementa `INotifyPropertyChanged` e contém dados estáticos (CNPJ/nomes) dos adquirentes; adquirentes suportados: REDE, STONE, PAGSEGURO, SUMUP, GETNET, CIELO
- **Inventário** — multisetor estoque (`tb_estoque`, PK composta: `ProdutoId` + `SetorEstoqueId`); `EstoqueService` usa SQL nativo (`MySqlCommand`) para queries de agregação com saldo disponível
- **Endereço** — três níveis de hierarquia: Estado → Cidade → Cliente
- **Auto-numeração** (`tb_autonumerador`) — controla IDs manualmente para: Cliente, Usuario, Produto, Banco, PedidoVenda, Maquininha, Adquirente; não usa `AUTO_INCREMENT` do MySQL
- **Soft delete** — Clientes, Usuários e Pedidos têm campos `Excluido` (bool) + `DataExclusao` para exclusão lógica

## Testes

O projeto `ModuloCadastro.Tests` testa a camada de Service usando EF Core InMemory. Consulte `ModuloCadastro.Tests/PADRAO_TESTES.md` para o padrão completo.

### Padrão de setup do contexto InMemory

Os services usam `IDbContextFactory<ModuloCadastroContext>`. Nos testes, use `DbContextFactoryFake` (em `ModuloCadastro.Tests/Factory/`) para injetar o mesmo banco InMemory:

```csharp
private (DbContextOptions<ModuloCadastroContext> options, ModuloCadastroContext context, int idInicial) CriarContexto()
{
    int idInicial = GerarIdAleatorio(); // Random.Next(0, 101)
    var options = new DbContextOptionsBuilder<ModuloCadastroContext>()
        .UseInMemoryDatabase("NomeDaClasseTests")
        .Options;
    var context = new ModuloCadastroContext(options);
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    // seed mínimo necessário para os testes...
    return (options, context, idInicial);
}

// Instanciar o service com a factory fake:
var factory = new DbContextFactoryFake(options);
var service = new ClienteService(factory);
```

### Acesso aos DbSets nos testes

Os DbSets de `ModuloCadastroContext` são `internal`. Nos testes, usar sempre `context.Set<TEntity>()` em vez da propriedade direta:

```csharp
// correto nos testes
context.Set<ClienteEntity>().Add(cliente);
context.Set<ClienteEntity>().Find(id);

// incorreto — inacessível fora do assembly
context.Clientes.Add(cliente);
```

### Limitação: ServiceMethods.UpdateParcial

`ServiceMethods.UpdateParcial` é estático e cria `new ModuloCadastroContext()` sem injeção de provider. Métodos de service que o chamam internamente (ex: `ClienteService.Insert`, `ClienteService.UpdateParcial`) **não são testáveis com InMemory** sem refatoração. Documentar no arquivo de teste e não criar testes para esses casos.

## Lições Aprendidas (Erros a Evitar)

Pontos que geraram retrabalho e consumo excessivo de contexto em sessões anteriores:

### Automação em massa via shell neste ambiente

- **Nunca usar `python3` inline** — não está disponível no PATH neste ambiente Windows; falha imediata.
- **Nunca usar PowerShell inline com heredoc bash** — o bash interpreta `\r\n` dentro de strings PowerShell como literais (`r` e `n`), corrompendo arquivos. Sempre escrever um `.ps1` separado via `Write` e executar com `powershell.exe -ExecutionPolicy Bypass -File script.ps1`.
- **Regex do PowerShell com `\r\n` via `-replace`** — o operador `-replace` no PowerShell não interpreta `\r\n` como newline quando a string de substituição vem de interpolação bash. Preferir `.Replace()` com `[char]10` ou escrever o script em arquivo.
- **Substituições em massa em muitos arquivos** — antes de rodar qualquer script de substituição em lote, validar em um único arquivo primeiro. Evita corromper dezenas de arquivos de uma vez.

### Fluxo de build e verificação

- **Rodar o build antes de modificar arquivos consumidores** — ao renomear namespaces, compilar logo após mover/atualizar os arquivos de origem. Não acumular todas as mudanças (Entity + Service + ViewModel + Forms + Testes) para só então descobrir os erros: o ciclo correto é mover → ajustar namespace → compilar → corrigir erros → avançar.
- **Verificar FQNs hardcoded antes de declarar concluído** — após renomear namespaces, buscar por `ModuloCadastro.Entity.<NomeClasse>` nos arquivos consumidores. FQNs não são cobertos por `using` e quebram silenciosamente.
- **Migrations Designer usam strings FQN, não tipos** — ao mover entidades, os arquivos `*.Designer.cs` e `ModelSnapshot.cs` referenciam tipos como strings (`"ModuloCadastro.Entity.ClienteEntity"`). Essas strings não são detectadas pelo compilador; devem ser atualizadas manualmente junto com o namespace da entidade.

### Estratégia de adição de usings

- **Não adicionar todos os sub-namespaces a todos os arquivos indiscriminadamente** — o correto é ler o arquivo, identificar quais tipos ele usa, e adicionar apenas os namespaces necessários. A abordagem de "adicionar tudo em todos" funciona mas gera usings desnecessários.

---

## Diretrizes de Desenvolvimento (NUNCA VIOLAR)

- Ignorar arquivos de `CLAUDEIGNORE.md`, salvo quando fornecidos manualmente
- Sempre seguir o padrão Service → Repository existente
- Não acessar o DbContext diretamente fora dos Services
- Manter nomenclatura em português
- Não gerar código de interface (WinForms) a menos que seja solicitado
- Focar em lógica de negócio e estrutura por padrão
- Ignorar arquivos Designer e código de UI, salvo quando fornecidos manualmente
- Nunca instanciar services com `new` dentro de formulários — sempre via injeção no construtor
- Ao criar novos formulários, registrá-los no container é automático (reflection em `AddForms`)
- Ao criar novos services, o registro no container também é automático (reflection em `AddServices`)
- Não alterar a arquitetura existente sem solicitação explícita
- Nunca usar `new formXxx()` para formularios que contenham como entrada de parâmetro `IFactory` — sempre via `_formFactory.Criar<T>(...)`
- Nunca abrir formulários filhos com `new formXxx()` — sempre via `_formFactory.Criar<T>(...)`
- Nunca instanciar services manualmente
- Nunca acessar DbContext fora de services
- Sempre usar `_formFactory.Criar<T>()`
- Sempre usar `IDbContextFactory`


