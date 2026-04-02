using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Tests.Factory
{
    public class DbContextFactoryFake : IDbContextFactory<ModuloCadastroContext>
    {
        private readonly DbContextOptions<ModuloCadastroContext> _options;

        public DbContextFactoryFake(DbContextOptions<ModuloCadastroContext> options)
        {
            _options = options;
        }

        public ModuloCadastroContext CreateDbContext()
        {
            return new ModuloCadastroContext(_options);
        }
    }
}
