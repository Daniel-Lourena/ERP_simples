namespace SistemaERP.Factory
{
    public interface IFormFactory
    {
        T Criar<T>(params object[] parameters) where T : Form;
    }
}
