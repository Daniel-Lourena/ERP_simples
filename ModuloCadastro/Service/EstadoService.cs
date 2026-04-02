using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class EstadoService
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;
        public EstadoService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;

        public EstadoEntity Get(int cuf)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Estados.AsNoTracking().FirstOrDefault(x => x.Cuf.Equals(cuf))!;
        }
        public EstadoEntity Get(string uf)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Estados.AsNoTracking().FirstOrDefault(x => x.Uf.Equals(uf))!;
        }
        public List<EstadoEntity> GetList()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Estados.AsNoTracking().ToList();
        }
    }
}
