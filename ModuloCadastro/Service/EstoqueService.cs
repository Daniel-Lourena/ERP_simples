using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;
using ModuloConfiguracoes.Extensions;
using MySqlConnector;

namespace ModuloCadastro.Service
{
    public class EstoqueService
    {
        public List<EstoqueViewModel> GetListEstoqueBruto()
        {
            return new ModuloCadastroContext().Estoques
                .AsNoTracking()
                .Select(x => new EstoqueViewModel
                {
                    idProduto = x.ProdutoId,
                    descricaoProduto = x.Produto.Descricao,
                    descricaoSetorEstoque = x.SetorEstoque.Descricao,
                    quantidadeEstoque = x.Quantidade
                }).ToList();
        }

        public List<EstoqueViewModel> GetListEstoqueDisponivel()
        {
            List<EstoqueViewModel> produtosEstoque = new();
            string tb_estoque = "estoque";
            string tb_produtosvenda = "produtosvenda";

            string sql = @$"
                    SELECT  
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.Id)} AS {nameof(EstoqueViewModel.idProduto)},
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.Descricao)} AS {nameof(EstoqueViewModel.descricaoProduto)},
                        IFNULL({SetorEstoqueEntity.Table}.{nameof(SetorEstoqueEntity.Descricao)},'SEM SETOR') AS {nameof(EstoqueViewModel.descricaoSetorEstoque)},
                        IFNULL({tb_estoque}.{nameof(EstoqueEntity.Quantidade)},0) AS {nameof(EstoqueViewModel.quantidadeEstoque)},
                        IFNULL({tb_produtosvenda}.{nameof(ProdutoVendaEntity.Quantidade)},0) AS {nameof(EstoqueViewModel.quantidadePedidoVenda)}
    
                    FROM {ProdutoEntity.Table}
                    LEFT JOIN 
                    (
                        SELECT 
                            {EstoqueEntity.Table}.{nameof(EstoqueEntity.ProdutoId)},
                            {EstoqueEntity.Table}.{nameof(EstoqueEntity.SetorEstoqueId)},
                            SUM(IFNULL({EstoqueEntity.Table}.{nameof(EstoqueEntity.Quantidade)},0)) AS {nameof(EstoqueEntity.Quantidade)}
                        FROM {EstoqueEntity.Table}
                        GROUP BY {EstoqueEntity.Table}.{nameof(EstoqueEntity.ProdutoId)},{EstoqueEntity.Table}.{nameof(EstoqueEntity.SetorEstoqueId)}
                    ) AS {tb_estoque} ON {ProdutoEntity.Table}.{nameof(ProdutoEntity.Id)} = {tb_estoque}.{nameof(EstoqueEntity.ProdutoId)}
                    LEFT JOIN
                    (
                        SELECT 
                            {ProdutoVendaEntity.Table}.{nameof(ProdutoVendaEntity.ProdutoId)},
                            SUM(IFNULL({ProdutoVendaEntity.Table}.{nameof(ProdutoVendaEntity.Quantidade)},0)) AS {nameof(ProdutoVendaEntity.Quantidade)}
                        FROM {ProdutoVendaEntity.Table},{PedidoVendaEntity.Table}
                        WHERE {PedidoVendaEntity.Table}.{nameof(PedidoVendaEntity.Id)} = {ProdutoVendaEntity.Table}.{nameof(ProdutoVendaEntity.PedidoVendaId)}
                        AND {PedidoVendaEntity.Table}.{nameof(PedidoVendaEntity.DataFechamento)} IS NULL 
                        AND {PedidoVendaEntity.Table}.{nameof(PedidoVendaEntity.Excluido)} IS FALSE 
                        GROUP BY {ProdutoVendaEntity.Table}.{nameof(ProdutoVendaEntity.ProdutoId)}
                    ) AS {tb_produtosvenda} ON  {ProdutoEntity.Table}.{nameof(ProdutoEntity.Id)} = {tb_produtosvenda}.{nameof(ProdutoVendaEntity.ProdutoId)}
                    LEFT JOIN 
                    (
                        SELECT {nameof(SetorEstoqueEntity.Id)},{nameof(SetorEstoqueEntity.Descricao)} 
                        FROM {SetorEstoqueEntity.Table}
                    ) AS {SetorEstoqueEntity.Table} ON {SetorEstoqueEntity.Table}.{nameof(SetorEstoqueEntity.Id)} = {tb_estoque}.{nameof(EstoqueEntity.SetorEstoqueId)};";

            using (MySqlCommand comando = new() { Connection = new MySqlConnection(ModuloConfiguracoes.ConfiguracoesGerais.stringConexaoDB)})
            {
                comando.CommandText = sql;
                using (comando.Connection)
                {
                    comando.Connection.Open();
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produtosEstoque.Add(reader.MapTo<EstoqueViewModel>());
                        }
                    }
                }
            }

            return produtosEstoque;
        }
    }
}
