using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Enum
{
    public enum ETipoContaBanco
    {
        [Description("CORRENTE")]
        CORRENTE = 0,
        [Description("POUPANÇA")]
        POUPANCA = 1,
        [Description("PAGAMENTO")]
        PAGAMENTO = 2,
        [Description("INVESTIMENTO")]
        INVESTIMENTO = 3,
        [Description("CAIXA")]
        CAIXA = 4
    }
}
