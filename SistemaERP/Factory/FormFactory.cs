using Microsoft.Extensions.DependencyInjection;

namespace SistemaERP.Factory
{
    internal class FormFactory : IFormFactory
    {
        private readonly IServiceProvider _provider;

        public FormFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public T Criar<T>(params object[] parameters) where T : Form
        {
            return ActivatorUtilities.CreateInstance<T>(_provider, parameters);
        }
    }
}
