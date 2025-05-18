using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;
using ModuloConfiguracoes.Extensions;
using MySqlConnector;
using System.Text;

namespace ModuloCadastro.Service
{
    public class EstoqueService
    {
        public List<EstoqueViewModel> GetListEstoqueBruto()
        {
            return new ModuloCadastroContext().Estoques
                .AsNoTracking()
                .Include(x => x.SetorEstoque)
                .Include(x => x.Produto)
                .Select(x => new EstoqueViewModel
                {
                    IdProduto = x.ProdutoId,
                    DescricaoProduto = x.Produto.Descricao,
                    DescricaoSetorEstoque = x.SetorEstoque.Descricao,
                    QuantidadeEstoque = x.Quantidade
                }).ToList();
        }

        public List<EstoqueViewModel> GetListEstoqueDisponivel()
        {
            List<EstoqueViewModel> produtosEstoque = new();
            string tb_estoque = "estoque";
            string tb_produtosvenda = "produtosvenda";

            string sql = @$"
                    SELECT  
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.Id)} AS {nameof(EstoqueViewModel.IdProduto)},
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.CodigoEstoque_SKU)} AS {nameof(EstoqueViewModel.Codigo_SKU)},
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.Descricao)} AS {nameof(EstoqueViewModel.DescricaoProduto)},
                        IFNULL({SetorEstoqueEntity.Table}.{nameof(SetorEstoqueEntity.Id)},0) AS {nameof(EstoqueViewModel.IdSetorEstoque)},
                        IFNULL({SetorEstoqueEntity.Table}.{nameof(SetorEstoqueEntity.Descricao)},'SEM SETOR') AS {nameof(EstoqueViewModel.DescricaoSetorEstoque)},
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.Inativo)} AS {nameof(EstoqueViewModel.inativo)},
                        IFNULL({tb_estoque}.{nameof(EstoqueEntity.Quantidade)},0) AS {nameof(EstoqueViewModel.QuantidadeEstoque)},
                        IFNULL({tb_produtosvenda}.{nameof(ProdutoVendaEntity.Quantidade)},0) AS {nameof(EstoqueViewModel.QuantidadePedidoVenda)}
    
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
        public List<EstoqueViewModel> GetListEstoquePosicaoItem()
        {
            List<EstoqueViewModel> produtosEstoque = new();
            string tb_estoque = "estoque";
            string tb_produtosvenda = "produtosvenda";

            string sql = @$"
                    SELECT  
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.Id)} AS {nameof(EstoqueViewModel.IdProduto)},
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.CodigoEstoque_SKU)} AS {nameof(EstoqueViewModel.Codigo_SKU)},
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.Descricao)} AS {nameof(EstoqueViewModel.DescricaoProduto)},
                        IFNULL({SetorEstoqueEntity.Table}.{nameof(SetorEstoqueEntity.Id)},0) AS {nameof(EstoqueViewModel.IdSetorEstoque)},
                        IFNULL({SetorEstoqueEntity.Table}.{nameof(SetorEstoqueEntity.Descricao)},'SEM SETOR') AS {nameof(EstoqueViewModel.DescricaoSetorEstoque)},
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.Inativo)} AS {nameof(EstoqueViewModel.inativo)},
                        IFNULL({tb_estoque}.{nameof(EstoqueEntity.Quantidade)},0) AS {nameof(EstoqueViewModel.QuantidadeEstoque)},
                        IFNULL({tb_produtosvenda}.{nameof(ProdutoVendaEntity.Quantidade)},0) AS {nameof(EstoqueViewModel.QuantidadePedidoVenda)}
    
                    FROM {ProdutoEntity.Table}
                    INNER JOIN 
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
        public EstoqueViewModel Get(int _idProduto ,int _setorEstoque )
        {
            EstoqueViewModel produtoEstoque = new();
            string tb_estoque = "estoque";
            string tb_produtosvenda = "produtosvenda";
            StringBuilder sql = new StringBuilder();
            
            sql.Append(@$"
                    SELECT  
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.Id)} AS {nameof(EstoqueViewModel.IdProduto)},
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.CodigoEstoque_SKU)} AS {nameof(EstoqueViewModel.Codigo_SKU)},
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.Descricao)} AS {nameof(EstoqueViewModel.DescricaoProduto)},
                        IFNULL({SetorEstoqueEntity.Table}.{nameof(SetorEstoqueEntity.Id)},0) AS {nameof(EstoqueViewModel.IdSetorEstoque)},
                        IFNULL({SetorEstoqueEntity.Table}.{nameof(SetorEstoqueEntity.Descricao)},'SEM SETOR') AS {nameof(EstoqueViewModel.DescricaoSetorEstoque)},
                        {ProdutoEntity.Table}.{nameof(ProdutoEntity.Inativo)} AS {nameof(EstoqueViewModel.inativo)},
                        IFNULL({tb_estoque}.{nameof(EstoqueEntity.Quantidade)},0) AS {nameof(EstoqueViewModel.QuantidadeEstoque)},
                        IFNULL({tb_produtosvenda}.{nameof(ProdutoVendaEntity.Quantidade)},0) AS {nameof(EstoqueViewModel.QuantidadePedidoVenda)}
    
                    FROM {ProdutoEntity.Table}
                    INNER JOIN 
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
                    ) AS {SetorEstoqueEntity.Table} ON {SetorEstoqueEntity.Table}.{nameof(SetorEstoqueEntity.Id)} = {tb_estoque}.{nameof(EstoqueEntity.SetorEstoqueId)}
                    WHERE {ProdutoEntity.Table}.{nameof(ProdutoEntity.Id)} = @{ProdutoEntity.Table}{nameof(ProdutoEntity.Id)}
                    AND {SetorEstoqueEntity.Table}.{nameof(SetorEstoqueEntity.Id)} = @{SetorEstoqueEntity.Table}{nameof(SetorEstoqueEntity.Id)};");

            using (MySqlCommand comando = new() { Connection = new MySqlConnection(ModuloConfiguracoes.ConfiguracoesGerais.stringConexaoDB)})
            {
                comando.Parameters.Add($"@{ProdutoEntity.Table}{nameof(ProdutoEntity.Id)}", MySqlDbType.Int32).Value = _idProduto;
                comando.Parameters.Add($"@{SetorEstoqueEntity.Table}{nameof(SetorEstoqueEntity.Id)}", MySqlDbType.Int32).Value = _setorEstoque;

                comando.CommandText = sql.ToString();
                using (comando.Connection)
                {
                    comando.Connection.Open();
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            produtoEstoque = reader.MapTo<EstoqueViewModel>();
                        }
                    }
                }
            }

            return produtoEstoque;
        }

        public void Insert(EstoqueEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.Estoques.Add(entity);
            _context.SaveChanges();
        }
        public void UpdateParcial(EstoqueEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
        public void Delete(EstoqueEntity entity)
        {
            using (var _context = new ModuloCadastroContext())
            {
                _context.Estoques.Remove(new EstoqueEntity { ProdutoId = entity.ProdutoId, SetorEstoqueId = entity.SetorEstoqueId });
                _context.SaveChanges();
            }
        }
    }
}
