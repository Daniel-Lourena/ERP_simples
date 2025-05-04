using System.ComponentModel;

namespace ModuloCadastro.Enum
{
    public enum ETipoChavePix
    {
        [Description("CPF/CNPJ")]
        CPF_CPNJ = 0,
        [Description("Celular")]
        CELULAR = 1,
        [Description("E-mail")]
        EMAIL = 2,
        [Description("Aleatória")]
        ALEATORIA = 3
    }
}
