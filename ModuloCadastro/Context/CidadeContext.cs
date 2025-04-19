using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    internal class CidadeContext
    {
        internal CidadeEntity Get(int id)
        {
            return new ModuloCadastroContext().Cidades.FirstOrDefault(x => x.id.Equals(id))!;
        }
        internal List<CidadeEntity> GetList()
        {
            return new ModuloCadastroContext().Cidades.ToList();
        }
        internal List<CidadeEntity> GetListByEstado(int cuf)
        {
            return new ModuloCadastroContext().Cidades.ToList().Where(x => x.cuf.Equals(cuf)).ToList();
        }
    }
}
