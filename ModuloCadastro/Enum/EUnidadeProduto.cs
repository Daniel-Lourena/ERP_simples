using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Enum
{
    public enum EUnidadeProduto
    {
        [Description("Un")]
        UNIDADE = 0,
        [Description("Pç")]
        PECA = 1,
        [Description("Pct")]
        PACOTE = 2,
        [Description("Kg")]
        KG = 3,
        [Description("Cen")]
        CENTO = 4,
        [Description("Mts")]
        METRO = 5 
    }
}
