using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Enum.Usuario.Departamento
{
    public enum EDepartamento
    {
        [Description("ADMINISTRAÇÃO")]
        ADMINISTRACAO = 1,

        [Description("FINANCEIRO")]
        FINANCEIRO = 2,

        [Description("VENDAS")]
        VENDAS = 3,

        [Description("ALMOXARIFADO")]
        ALMOXARIFADO = 4,

        [Description("LOGÍSTICA")]
        LOGISTICA = 5,

        [Description("RH")]
        RH = 6
    }
}
