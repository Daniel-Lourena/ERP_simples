using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    public static class ConfigurationContext
    {
        public static IServiceCollection ConfigurarContexto(this IServiceCollection service)
        {
            service.AddDbContextFactory<ModuloCadastro.Context.ModuloCadastroContext>
                (
                    optionsBuilder => optionsBuilder.UseMySql(ModuloConfiguracoes.ConfiguracoesGerais.stringConexaoDB + "AllowLoadLocalInfile=true;",
                    new MySqlServerVersion(new Version(5, 7)),  // Versão minima suportada
                    options => options.EnableRetryOnFailure()) // Configuraçoes adicionais);
                );

            return service;
        }
    }

    //APENAS PARA O MIGRATIONS CONSEGUIR MONTAR O CONTEXTO
    public class ModuloCadastroContextFactory : IDesignTimeDbContextFactory<ModuloCadastroContext>
    {
        public ModuloCadastroContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ModuloCadastroContext>();

            optionsBuilder.UseMySql(ModuloConfiguracoes.ConfiguracoesGerais.stringConexaoDB + "AllowLoadLocalInfile=true;",
                    new MySqlServerVersion(new Version(5, 7)),  // Versão minima suportada
                    options => options.EnableRetryOnFailure());

            return new ModuloCadastroContext(optionsBuilder.Options);
        }
    }
}
