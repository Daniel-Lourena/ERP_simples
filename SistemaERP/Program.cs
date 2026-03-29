using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Service;

namespace SistemaERP
{
    internal static class Program
    {
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
            Application.Run(new TelaInicial());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            MessageBox.Show("Houve um erro ao realizar a ação!" + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void OnConfiguring()
        {
            // Conexão com MySQL
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseMySql(ModuloConfiguracoes.ConfiguracoesGerais.stringConexaoDB + "AllowLoadLocalInfile=true;",
                new MySqlServerVersion(new Version(5, 7)),  // Versão mínima suportada
                options => options.EnableRetryOnFailure()); // Configurações adicionais
        }
    }
}