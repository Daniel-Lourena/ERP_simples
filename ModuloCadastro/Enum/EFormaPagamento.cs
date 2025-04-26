using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Enum
{
    public enum EFormaPagamento
    {
        [Description("DINHEIRO")]
        DINHEIRO = 1,
        [Description("CHEQUE")]
        CHEQUE = 2,
        [Description("BOLETO")]
        BOLETO = 3,
        [Description("TRANSFERÊNCIA")]
        TRANSFERENCIA = 4,
        [Description("CRÉDITO")]
        CREDITO_LOJA = 5,
        [Description("CARTÃO DÉDITO")]
        CARTAO_DEBITO = 6,
        [Description("CARTÃO CRÉDITO")]
        CARTAO_CREDITO = 7
    }
}
