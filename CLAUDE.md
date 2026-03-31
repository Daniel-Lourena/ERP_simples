# CLAUDE.md

Este arquivo fornece orientação para o Claude Code (claude.ai/code) ao trabalhar com código neste repositório.

## CLAUDEIGNORE.md
Este arquivo tem toda a relação dos arquivos que o Claude Code deve ignorar ao realizar tarefas, sendo estritamente rigoroso em não ler nenhum arquivo presente nessa lista, salvo em casos que seja fornecido manualmente o contexto.

## Linguagem

- Todas as respostas devem ser em português (Brasil)
- Manter nomes técnicos conforme o código

## Visão Geral do Projeto

Sistema ERP desenvolvido em C# (.NET 8) e Windows Forms (WinForms), voltado para casos de uso de varejo/vendas no Brasil. A interface do usuário, as entidades de domínio, os serviços e as colunas do banco de dados estão todos escritos em português.

## Compilar e Executar

```bash
# Build the solution
dotnet build SistemaERP/SistemaERP.sln

# Run the application
dotnet run --project SistemaERP/SistemaERP.csproj

# Aplicar migrações pendentes do EF Core
dotnet ef database update --project ModuloCadastro
```

Nenhuma ferramenta de teste ou lint está configurada.

## Arquitetura

A solução tem três projetos:

| Project | Role |
|---|---|
| `SistemaERP` | WinForms UI — MDI host (`TelaInicial`) with child forms per feature |
| `ModuloCadastro` | Business logic: Entities, Services, ViewModels, EF Core DbContext, Migrations |
| `Configuracoes` (ModuloConfiguracoes) | Shared: connection string, enum/extension utilities |

**Data flow:** WinForms form → Service → EF Core DbContext → MySQL

### Key layers in `ModuloCadastro`

- **Entity/** — EF Core model classes mapped to `tb_*` MySQL tables
- **Service/** — One service per entity implementing `IService<T>`; all DB access goes through services
- **ViewModel/** — Lightweight DTOs with `INotifyPropertyChanged`; entities expose a `ToViewModel()` method
- **Enum/** — Domain constants (`EFormaPagamento`, `EAdquirenteMaquininha`, `EBandeiraCartao`, etc.)
- **Context/ModuloCadastroContext.cs** — Single DbContext; injetado via DI nos services

### UI conventions

- Formulários são organizados sob `SistemaERP/Cadastros/<Module>/` e `SistemaERP/Venda/`
- Formulários de recibo de pagamento ficam em `SistemaERP/Venda/Recebimento/`, um formulário por método de pagamento
- Formulários genéricos reutilizáveis estão em `SistemaERP/Generico/`

### Injeção de Dependência (DI)

O projeto usa `Microsoft.Extensions.DependencyInjection`. O container é configurado em `Program.cs` via dois métodos de extensão em `SistemaERP/DI/DependencyInjectionRegistryClass.cs`:

- **`AddServices()`** — registra automaticamente via reflection todos os tipos que implementam `IService<T>`, tanto pelo tipo concreto quanto pela interface
- **`AddForms()`** — registra automaticamente todos os `Form` do assembly como `Transient`; também registra `IFormFactory` como `Singleton`

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

- **Vendas** (`tb_vendas`, `tb_produto_venda`) — pedidos com itens de linha, vinculados ao cliente e ao usuário
- **Pagamentos** (`tb_recebimento_venda`) — aceita dinheiro, cheque, boleto, transferência, PIX, crédito na loja, cartão de débito, cartão de crédito
- **Processamento de cartão** — adquirentes (`tb_config_adquirente`), maquininhas (`tb_maquininhas`), e bandeiras de cartão (`tb_adquirente_bandeira`) são configuradas separadamente; adquirentes suportados: REDE, STONE, PAGSEGURO, SUMUP, GETNET, CIELO
- **Inventário** — multisetor estoque (`tb_estoque` composto PK: `ProdutoId` + `SetorEstoqueId`)
- **Endereço** — três-niveis de hierarquia: Estado → Cidade → Cliente

## Diretrizes de Desenvolvimento

- Ignorar arquivos de `CLAUDEIGNORE.md`, salvo quando fornecidos manualmente
- Sempre seguir o padrão Service → Repository existente
- Não acessar o DbContext diretamente fora dos Services
- Manter nomenclatura em português
- Não gerar código de interface (WinForms) a menos que seja solicitado
- Focar em lógica de negócio e estrutura por padrão
- Não alterar a arquitetura existente sem solicitação explícita
- Ignorar arquivos Designer e código de UI, salvo quando fornecidos manualmente
- Nunca instanciar services com `new` dentro de formulários — sempre via injeção no construtor
- Nunca abrir formulários filhos com `new formXxx()` — sempre via `_formFactory.Criar<T>(...)`
- Ao criar novos formulários, registrá-los no container é automático (reflection em `AddForms`)
- Ao criar novos services, o registro no container também é automático (reflection em `AddServices`)
