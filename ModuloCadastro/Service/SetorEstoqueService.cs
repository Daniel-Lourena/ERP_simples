using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class SetorEstoqueService
    {
        public List<SetorEstoqueEntity> GetList()
        {
            return new ModuloCadastroContext().SetoresEstoque.AsNoTracking().ToList();
        }
        public void Insert(SetorEstoqueEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.SetoresEstoque.Add(entity);
            _context.SaveChanges();
        }
        public void Update(SetorEstoqueEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.SetoresEstoque.Update(entity);
            _context.SaveChanges();
        }
    }
}
