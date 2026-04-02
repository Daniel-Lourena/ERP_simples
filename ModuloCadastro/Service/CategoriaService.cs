using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class CategoriaService
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;
        public CategoriaService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;

        public List<CategoriaEntity> GetList()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Categorias
                .AsNoTracking()
                .ToList();
        }

        public void Insert(CategoriaEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.Categorias.Add(entity);
            _db_context.SaveChanges();
        }

        public void Update(CategoriaEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.Categorias.Update(entity);
            _db_context.SaveChanges();
        }
    }
}
