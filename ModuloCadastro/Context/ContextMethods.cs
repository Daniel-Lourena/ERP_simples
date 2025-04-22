using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    public static class ContextMethods
    {
        public static void UpdateParcial<T>(T entity, List<string> listaPropriedadesAtualizar) where T : class
        {
            using (var _context = new ModuloCadastroContext())
            {
                _context.Attach(entity);

                listaPropriedadesAtualizar.
                    ForEach(propriedadeAtualiza =>
                    _context.Entry(entity).Property(propriedadeAtualiza).IsModified = true);

                _context.SaveChanges();
            }
        }
    }
}
