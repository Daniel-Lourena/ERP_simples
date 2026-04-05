using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaERP.DI;

namespace SistemaERP
{
    internal static class Program
    {
        private static ServiceProvider _serviceProvider;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            OnConfiguring();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(_serviceProvider.GetRequiredService<TelaInicial>());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            MessageBox.Show("Houve um erro ao realizar a a��o!" + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void OnConfiguring()
        {
            ServiceCollection service = new ServiceCollection();
            service.AddDbContextFactory<ModuloCadastro.Context.ModuloCadastroContext>
                (
                    optionsBuilder => optionsBuilder.UseMySql(ModuloConfiguracoes.ConfiguracoesGerais.stringConexaoDB + "AllowLoadLocalInfile=true;",
                    new MySqlServerVersion(new Version(5, 7)),  // Vers�o m�nima suportada
                    options => options.EnableRetryOnFailure()) // Configura��es adicionais);
                );
            service.AddServices();
            service.AddForms();
            _serviceProvider = service.BuildServiceProvider();
        }
    }
}