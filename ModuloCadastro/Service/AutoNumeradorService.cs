using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class AutoNumeradorService 
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory ;
        public AutoNumeradorService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;

        public AutoNumeradorEntity Get()
        {
            var _context = _factory.CreateDbContext();
            return _context.AutoNumeradores.AsNoTracking().FirstOrDefault(x => x.Id.Equals(1));
        }
    }
}
