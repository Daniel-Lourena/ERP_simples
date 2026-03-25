# CLAUDE.md

Este arquivo fornece orientação para o Claude Code (claude.ai/code) ao trabalhar com código neste repositório.

## Linguagem

- Todas as respostas devem ser em português (Brasil)
- Manter nomes técnicos conforme o código

## Visão Geral do Projeto

Sistema ERP desenvolvido em C# (.NET 6) e Windows Forms (WinForms), voltado para casos de uso de varejo/vendas no Brasil. A interface do usuário, as entidades de domínio, os serviços e as colunas do banco de dados estão todos escritos em português.

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
- **Context/ModuloCadastroContext.cs** — Single DbContext; registered and instantiated directly in service constructors

### UI conventions

- Forms are organized under `SistemaERP/Cadastros/<Module>/` and `SistemaERP/Venda/`
- Payment receipt forms live under `SistemaERP/Venda/Recebimento/`, one form per payment method
- Generic reusable forms are in `SistemaERP/Generico/`

## Database

- MySQL on `localhost:3306`, database `erp_simples`
- Connection string is hard-coded in `Configuracoes/ConfiguracoesGerais.cs`
- EF Core migrations are in `ModuloCadastro/Migrations/`
- Auto-increment IDs for clients/orders are managed through the `tb_autonumerador` table (`AutoNumeradorEntity`), not MySQL `AUTO_INCREMENT`

## Domain Highlights

- **Vendas** (`tb_vendas`, `tb_produto_venda`) — pedidos com itens de linha, vinculados ao cliente e ao usuário
- **Pagamentos** (`tb_recebimento_venda`) — aceita dinheiro, cheque, boleto, transferência, PIX, crédito na loja, cartão de débito, cartão de crédito
- **Processamento de cartão** — adquirentes (`tb_config_adquirente`), maquininhas (`tb_maquininhas`), e bandeiras de cartão (`tb_adquirente_bandeira`) são configuradas separadamente; adquirentes suportados: REDE, STONE, PAGSEGURO, SUMUP, GETNET, CIELO
- **Inventário** — multisetor estoque (`tb_estoque` composto PK: `ProdutoId` + `SetorEstoqueId`)
- **Endereço** — três-niveis de hierarquia: Estado → Cidade → Cliente

## Diretrizes de Desenvolvimento

- Sempre seguir o padrão Service → Repository existente
- Não acessar o DbContext diretamente fora dos Services
- Manter nomenclatura em português
- Não gerar código de interface (WinForms) a menos que seja solicitado
- Focar em lógica de negócio e estrutura por padrão
- Não alterar a arquitetura existente sem solicitação explícita
- Ignorar arquivos Designer e código de UI, salvo quando fornecidos manualmente