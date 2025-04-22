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
        DIRETOR = 1,
        [Description("SÓCIO")]
        SOCIO = 2,
        [Description("FATURISTA")]
        FATURISTA = 3,
        [Description("ORÇAMENTISTA")]
        ORCAMENTISTA = 4,
        [Description("CARREGADOR")]
        CARREGADOR = 5,
        [Description("SUPERVISOR")]
        SUPERVISOR = 6,
        [Description("GERENTE")]
        GERENTE = 7
    }
}
