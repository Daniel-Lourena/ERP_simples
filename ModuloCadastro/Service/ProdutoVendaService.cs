using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;

namespace ModuloCadastro.Service
{
    public class ProdutoVendaService
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;
        public ProdutoVendaService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;
        
        public List<ProdutoVendaViewModel> GetListProdutosPedido(int id)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.ProdutosVendas
                .AsNoTracking()
                .Include(pp => pp.PedidoVenda)
                .Include(pp => pp.Produto)
                .Include(pp => pp.SetorEstoque)
                .Where(pp => pp.PedidoVenda.Id == id)
                .Select(x => new ProdutoVendaViewModel
                {
                    id = x.Id,
                    idPedido = x.PedidoVendaId,
                    idProduto = x.ProdutoId,
                    idSetorEstoque = x.SetorEstoqueId,
                    descricaoProduto = x.Produto.Descricao,
                    quantidade = Convert.ToDecimal(x.Quantidade),
                    valor = x.Valor
                }).ToList();
        }
        public List<ProdutoVendaEntity> GetListProdutosVendaAberto()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.ProdutosVendas
                .AsNoTracking()
                .Include(pp => pp.PedidoVenda)
                .Where(pp => pp.PedidoVenda.DataFechamento == null)
                .ToList();
        }
        public List<ProdutoVendaEntity> GetListProdutosVendaFechado()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.ProdutosVendas
                .AsNoTracking()
                .Include(pp => pp.PedidoVenda)
                .Where(pp => pp.PedidoVenda.DataFechamento != null)
                .ToList();
        }

        public void Insert(ProdutoVendaEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.ProdutosVendas.Add(entity);
            _db_context.SaveChanges();
        }
        public void UpdateParcial(ProdutoVendaEntity entity, List<string> listaPropriedadesAtualizar)
        {
            var _db_context = _factory.CreateDbContext();
            new ServiceMethods(_db_context).UpdateParcial(entity, listaPropriedadesAtualizar);
        }

        public void Delete(int id)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.ProdutosVendas.Remove(new ProdutoVendaEntity { Id = id });
            _db_context.SaveChanges();
        }
    }
}
