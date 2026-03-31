using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class SetorEstoqueService
    {
        private readonly ModuloCadastroContext _db_context;
        public SetorEstoqueService(ModuloCadastroContext db_context) => _db_context = db_context;

        public List<SetorEstoqueEntity> GetList()
        {
            return _db_context.SetoresEstoque.AsNoTracking().ToList();
        }
        public void Insert(SetorEstoqueEntity entity)
        {
            _db_context.SetoresEstoque.Add(entity);
            _db_context.SaveChanges();
        }
        public void Update(SetorEstoqueEntity entity)
        {
            _db_context.SetoresEstoque.Update(entity);
            _db_context.SaveChanges();
        }
    }
}
