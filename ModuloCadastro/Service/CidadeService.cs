using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class CidadeService
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;
        public CidadeService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;

        public CidadeEntity Get(int id)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Cidades.AsNoTracking().FirstOrDefault(x => x.Id == id)!;
        }
        public List<CidadeEntity> GetList()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Cidades.AsNoTracking().ToList();
        }
        public List<CidadeEntity> GetListByEstado(int cuf)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Cidades.AsNoTracking().Where(x => x.Cuf == cuf).ToList();
        }
    }
}
