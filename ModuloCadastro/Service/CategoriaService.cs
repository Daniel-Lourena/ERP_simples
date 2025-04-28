using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Service
{
    public class CategoriaService
    {
        private ModuloCadastroContext _db_context;
        public CategoriaService(ModuloCadastroContext db_context) => _db_context = db_context;

        public List<CategoriaEntity> GetList()
        {
            return _db_context.Categorias.ToList();
        }
    }
}
