using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Enum
{
    public enum ERecebimentoEspecie
    {
        [Description("Dinheiro")]
        DINHEIRO = 0,
        [Description("Boleto")]
        BOLETO = 1,
        [Description("Cheque")]
        CHEQUE = 2,
        [Description("Crédito Loja")]
        CREDITO_LOJA = 3,
        [Description("Transferência")]
        TRANSFERENCIA = 4,
        [Description("Cartão de Débito")]
        CARTAO_DEBITO = 5,
        [Description("Cartão de Crédito")]
        CARTAO_CREDITO = 6
    }
}
