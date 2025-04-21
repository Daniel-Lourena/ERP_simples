using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    public class SetorEstoqueContext
    {
        public List<SetorEstoqueEntity> GetList()
        {
            return new ModuloCadastroContext().SetoresEstoque.ToList();
        }
    }
}
