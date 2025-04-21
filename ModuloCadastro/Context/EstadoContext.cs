using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    public class EstadoContext
    {
        public EstadoEntity Get(int cuf)
        {
            return new ModuloCadastroContext().Estados.FirstOrDefault(x => x.cuf.Equals(cuf))!;
        }
        public EstadoEntity Get(string uf)
        {
            return new ModuloCadastroContext().Estados.FirstOrDefault(x => x.uf.Equals(uf))!;
        }
        public List<EstadoEntity> GetList()
        {
            return new ModuloCadastroContext().Estados.ToList();
        }
    }
}
