using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    internal class UsuarioContext : ModuloCadastroContext
    {
        internal UsuarioEntity Get(int id)
        {
            return new ModuloCadastroContext().Usuarios.FirstOrDefault(x => x.id.Equals(id))!;
        }
        internal List<UsuarioEntity> GetList()
        {
            return new ModuloCadastroContext().Usuarios.ToList();
        }
    }
}
