using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    public class CategoriaContext
    {
        private ModuloCadastroContext _db_context;
        public CategoriaContext(ModuloCadastroContext db_context) => _db_context = db_context;

        public List<CategoriaEntity> GetList()
        {
            return _db_context.Categorias.ToList();
        }
    }
}
