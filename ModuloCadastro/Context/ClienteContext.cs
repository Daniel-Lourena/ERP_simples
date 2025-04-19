using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    internal class ClienteContext
    {
        internal ClienteEntity Get(int id)
        {
            return new ModuloCadastroContext().Clientes.FirstOrDefault(x => x.id.Equals(id))!;
        }
        internal List<ClienteEntity> GetList()
        {
            return new ModuloCadastroContext().Clientes.ToList();
        }
    }
}
