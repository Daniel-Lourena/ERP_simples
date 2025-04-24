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
        private ModuloCadastro.Context.ModuloCadastroContext _db_context;

        public ProdutoContext(ModuloCadastroContext db_context) => _db_context = db_context;
        public ProdutoEntity Get(int id)
        {
            return new ModuloCadastroContext().Produtos.FirstOrDefault(x => x.id.Equals(id))!;
        }
        public List<ProdutoEntity> GetList()
        {
            return _db_context.Produtos.ToList();
        }

        public void Insert(ProdutoEntity entity)
        {
            using (var autoNumeradorContext = new ModuloCadastro.Context.AutoNumeradorContext(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.idProduto++;
                entity.id = numerador.idCliente;
                var _context = new ModuloCadastroContext();
                _context.Produtos.Add(entity);
                _context.SaveChanges();
                ContextMethods.UpdateParcial<AutoNumeradorEntity>(numerador, new List<string>() { nameof(AutoNumeradorEntity.idProduto) });
            }
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
