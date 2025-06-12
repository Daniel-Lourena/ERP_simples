using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Enum
{
    public enum EBandeiraCartao
    {
        [Description("Visa")]
        Visa = 1,
        [Description("Mastercard")]
        Mastercard = 2,
        [Description("Elo")]
        Elo = 3,
        [Description("Hipercard")]
        Hipercard = 4,
        [Description("American Express")]
        AmericanExpress = 5,
        [Description("Hiper")]
        Hiper = 6,
        [Description("Cabal")]
        Cabal = 7,
        [Description("Sorocred")]
        Sorocred = 8,
        [Description("Aura")]
        Aura = 9,
        [Description("Discover")]
        Discover = 10,
        [Description("JCB")]
        JCB = 11,
        [Description("Diners Club")]
        DinersClub = 12,
        [Description("UnionPay")]
        UnionPay = 13
    }
}
