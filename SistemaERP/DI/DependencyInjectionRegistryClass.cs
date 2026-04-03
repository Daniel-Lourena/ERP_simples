using Microsoft.Extensions.DependencyInjection;
using ModuloCadastro.Service;
using ModuloCadastro.Service.Financeiro;
using ModuloCadastro.Service.Cadastro.Produto;
using ModuloCadastro.Service.Cadastro.Cliente;
using ModuloCadastro.Service.Cadastro.Localizacao;
using ModuloCadastro.Service.Cadastro.Usuario;
using ModuloCadastro.Service.Venda;
using SistemaERP.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaERP.DI
{
    internal static class DependencyInjectionRegistryClass
    {
        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            var assembly = typeof(IService<>).Assembly; // ou outro assembly se necessário

            var types = assembly.GetTypes()
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.GetInterfaces().Any(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IService<>)
                    ));

            foreach (var implementation in types)
            {
                services.AddTransient(implementation);

                var interfaces = implementation.GetInterfaces()
                    .Where(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IService<>)
                    );

                foreach (var serviceInterface in interfaces)
                {
                    services.AddTransient(serviceInterface, implementation);
                }
            }

            return services;
        }

        public static IServiceCollection AddForms(this IServiceCollection services)
        {
            var assembly = typeof(TelaInicial).Assembly;

            var formTypes = assembly.GetTypes()
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    typeof(Form).IsAssignableFrom(t)
                );

            foreach (var form in formTypes)
            {
                services.AddTransient(form);
            }

            services.AddSingleton<IFormFactory, FormFactory>();

            return services;
        }
    }
}
