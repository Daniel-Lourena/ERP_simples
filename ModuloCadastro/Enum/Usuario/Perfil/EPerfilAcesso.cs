using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Enum.Usuario.Perfil
{
    public enum EPerfilAcesso
    {
        [Description("ADMINISTRADOR")]
        ADMINISTRADOR = 1,

        [Description("GERENTE")]
        GERENTE = 2,

        [Description("USUÁRIO COMUM")]
        USUARIO_COMUM = 3,
    }
}
