using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;

namespace ModuloCadastro.Service
{
    public class ProdutoVendaService
    {
        public List<ProdutoVendaViewModel> GetListProdutosPedido(int id)
        {
            return new ModuloCadastroContext().ProdutosVendas
                .AsNoTracking()
                .Include(pp => pp.PedidoVenda)
                .Include(pp => pp.Produto)
                .Where(pp => pp.PedidoVenda.Id == id)
                .Select(x => new ProdutoVendaViewModel
                {
                    id = x.Id,
                    idPedido = x.PedidoVendaId,
                    idProduto = x.ProdutoId,
                    descricaoProduto = x.Produto.Descricao,
                    quantidade = Convert.ToDecimal(x.Quantidade),
                    valor = x.Valor
                }).ToList();
        }
        public List<ProdutoVendaEntity> GetListProdutosVendaAberto()
        {
            return new ModuloCadastroContext().ProdutosVendas
                .AsNoTracking()
                .Include(pp => pp.PedidoVenda)
                .Where(pp => pp.PedidoVenda.DataFechamento == null)
                .ToList();
        }
        public List<ProdutoVendaEntity> GetListProdutosVendaFechado()
        {
            return new ModuloCadastroContext().ProdutosVendas
                .AsNoTracking()
                .Include(pp => pp.PedidoVenda)
                .Where(pp => pp.PedidoVenda.DataFechamento != null)
                .ToList();
        }

        public void Insert(ProdutoVendaEntity entity)
        {
            using (var _context = new ModuloCadastroContext())
            {
                _context.ProdutosVendas.Add(entity);
                _context.SaveChanges();
            }
        }
        public void UpdateParcial(ProdutoVendaEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }

        public void Delete(int id)
        {
            using (var _context = new ModuloCadastroContext())
            {
                _context.ProdutosVendas.Remove(new ProdutoVendaEntity { Id = id });
                _context.SaveChanges();
            }
        }
    }
}
