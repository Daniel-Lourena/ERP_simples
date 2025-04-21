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
        public List<CategoriaEntity> GetList()
        {
            return new ModuloCadastroContext().Categorias.ToList();
        }
    }
}
