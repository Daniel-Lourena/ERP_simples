using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Service
{
    public class SetorEstoqueService
    {
        public List<SetorEstoqueEntity> GetList()
        {
            return new ModuloCadastroContext().SetoresEstoque.ToList();
        }
    }
}
