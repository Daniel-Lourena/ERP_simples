using System.ComponentModel;

namespace ModuloCadastro.Enum
{
    public enum ECst
    {
        [Description("00 – Tributada integralmente")]
        Item00 = 00,
        [Description("10 – Tributada e com cobrança do ICMS por substituição tributária")]
        Item10 = 10,
        [Description("20 – Com redução de base de cálculo")]
        Item20 = 20,
        [Description("30 – Isenta ou não tributada e com cobrança do ICMS por substituição tributária")]
        Item30 = 30,
        [Description("40 – Isenta")]
        Item40 = 40,
        [Description("41 – Não tributada")]
        Item41 = 41,
        [Description("50 – Suspensão")]
        Item50 = 50,
        [Description("51 – Diferimento")]
        Item51 = 51,
        [Description("60 – ICMS cobrado anteriormente por substituição tributária")]
        Item60 = 60,
        [Description("70 – Com redução de base de cálculo e cobrança do ICMS por substituição tributária")]
        Item70 = 70,
        [Description("90 – Outras")]
        Item90 = 90
    }
}
