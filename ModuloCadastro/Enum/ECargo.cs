using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Enum
{
    public enum ECargo
    {
        [Description("DIRETOR")]
        DIRETOR = 0,
        [Description("SÓCIO")]
        SOCIO = 1,
        [Description("FATURISTA")]
        FATURISTA = 2,
        [Description("ORÇAMENTISTA")]
        ORCAMENTISTA = 3,
        [Description("CARREGADOR")]
        CARREGADOR = 4,
        [Description("SUPERVISOR")]
        SUPERVISOR = 5,
        [Description("GERENTE")]
        GERENTE = 6
    }
}
