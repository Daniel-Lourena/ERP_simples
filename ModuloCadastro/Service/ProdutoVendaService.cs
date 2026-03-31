using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;

namespace ModuloCadastro.Service
{
    public class ProdutoVendaService
    {
        private readonly ModuloCadastroContext _db_context;
        public ProdutoVendaService(ModuloCadastroContext db_context) => this._db_context = db_context;
        public List<ProdutoVendaViewModel> GetListProdutosPedido(int id)
        {
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
            return _db_context.ProdutosVendas
                .AsNoTracking()
                .Include(pp => pp.PedidoVenda)
                .Where(pp => pp.PedidoVenda.DataFechamento == null)
                .ToList();
        }
        public List<ProdutoVendaEntity> GetListProdutosVendaFechado()
        {
            return _db_context.ProdutosVendas
                .AsNoTracking()
                .Include(pp => pp.PedidoVenda)
                .Where(pp => pp.PedidoVenda.DataFechamento != null)
                .ToList();
        }

        public void Insert(ProdutoVendaEntity entity)
        {
            _db_context.ProdutosVendas.Add(entity);
            _db_context.SaveChanges();
        }
        public void UpdateParcial(ProdutoVendaEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }

        public void Delete(int id)
        {
            _db_context.ProdutosVendas.Remove(new ProdutoVendaEntity { Id = id });
            _db_context.SaveChanges();
        }
    }
}
