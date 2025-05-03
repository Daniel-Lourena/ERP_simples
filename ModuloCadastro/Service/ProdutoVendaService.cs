using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Service
{
    public class ProdutoVendaService
    {
        public List<ProdutoVendaViewModel> GetListProdutosPedido(int id)
        {
            return new ModuloCadastroContext().ProdutosVendas
                .AsNoTracking()
                .Include(pp => pp.DadosPedidoVenda)
                .Where(pp => pp.DadosPedidoVenda.id == id)
                .Select(x => new ProdutoVendaViewModel
                {
                    id = x.id,
                    idPedido = x.idPedido,
                    idProduto = x.idProduto,
                    quantidade = x.quantidade,
                    valor = x.valor
                }).ToList();
        }
        public List<ProdutoVendaEntity> GetListProdutosVendaAberto()
        {
            return new ModuloCadastroContext().ProdutosVendas
                .AsNoTracking()
                .Include(pp => pp.DadosPedidoVenda)
                .Where(pp => pp.DadosPedidoVenda.dataFechamento == null)
                .ToList();
        }
        public List<ProdutoVendaEntity> GetListProdutosVendaFechado()
        {
            return new ModuloCadastroContext().ProdutosVendas
                .AsNoTracking()
                .Include(pp => pp.DadosPedidoVenda)
                .Where(pp => pp.DadosPedidoVenda.dataFechamento != null)
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

        public void Delete(int id)
        {
            using (var _context = new ModuloCadastroContext())
            {
                _context.ProdutosVendas.Remove(new ProdutoVendaEntity { id = id});
                _context.SaveChanges();
            }
        }
    }
}
