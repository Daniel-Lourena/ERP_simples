using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    public class ProdutoContext
    {
        public ProdutoEntity Get(int id)
        {
            return new ModuloCadastroContext().Produtos.FirstOrDefault(x => x.id.Equals(id))!;
        }
        public List<ProdutoEntity> GetList()
        {
            return new ModuloCadastroContext().Produtos.ToList();
        }

        public void Insert(ProdutoEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.Produtos.Add(entity);
            _context.SaveChanges();
        }
        public void Update(ProdutoEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.Produtos.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateParcial(ProdutoEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ContextMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
