using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class CategoriaService
    {
        private readonly ModuloCadastroContext _db_context;
        public CategoriaService(ModuloCadastroContext db_context) => _db_context = db_context;

        public List<CategoriaEntity> GetList()
        {
            return _db_context.Categorias
                .AsNoTracking()
                .ToList();
        }

        public void Insert(CategoriaEntity entity)
        {
            using (var _context = _db_context)
            {
                _context.Categorias.Add(entity);
                _context.SaveChanges();
            }
        }

        public void Update(CategoriaEntity entity)
        {
            using (var _context = _db_context)
            {
                _context.Categorias.Update(entity);
                _context.SaveChanges();
            }
        }
    }
}
