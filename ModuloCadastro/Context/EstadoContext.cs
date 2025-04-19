using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    internal class EstadoContext
    {
        internal EstadoEntity Get(int cuf)
        {
            return new ModuloCadastroContext().Estados.FirstOrDefault(x => x.cuf.Equals(cuf))!;
        }
        internal EstadoEntity Get(string uf)
        {
            return new ModuloCadastroContext().Estados.FirstOrDefault(x => x.uf.Equals(uf))!;
        }
        internal List<EstadoEntity> GetList()
        {
            return new ModuloCadastroContext().Estados.ToList();
        }
    }
}
