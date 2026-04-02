using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class SetorEstoqueService
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;
        public SetorEstoqueService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;

        public List<SetorEstoqueEntity> GetList()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.SetoresEstoque.AsNoTracking().ToList();
        }
        public void Insert(SetorEstoqueEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.SetoresEstoque.Add(entity);
            _db_context.SaveChanges();
        }
        public void Update(SetorEstoqueEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.SetoresEstoque.Update(entity);
            _db_context.SaveChanges();
        }
    }
}
