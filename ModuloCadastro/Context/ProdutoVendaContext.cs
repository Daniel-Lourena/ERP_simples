using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    public class ProdutoVendaContext
    {
        public List<ProdutoVendaEntity> GetListProdutosPedido(int id)
        {
            return new ModuloCadastroContext().ProdutosVendas
                .Include(pp => pp.DadosPedidoVenda)
                .Where(pp => pp.DadosPedidoVenda.id == id)
                .AsNoTracking().ToList();
        }
        public List<ProdutoVendaEntity> GetListProdutosVendaAberto()
        {
            return new ModuloCadastroContext().ProdutosVendas
                .Include(pp => pp.DadosPedidoVenda)
                .Where(pp => pp.DadosPedidoVenda.dataFechamento == null)
                .AsNoTracking().ToList();
        }
        public List<ProdutoVendaEntity> GetListProdutosVendaFechado()
        {
            return new ModuloCadastroContext().ProdutosVendas
                .Include(pp => pp.DadosPedidoVenda)
                .Where(pp => pp.DadosPedidoVenda.dataFechamento != null)
                .AsNoTracking().ToList();
        }

        public void Insert(ProdutoVendaEntity entity)
        {
            using (var _context = new ModuloCadastroContext())
            {
                _context.ProdutosVendas.Add(entity);
                _context.SaveChanges();
            }
        }
    }
}
