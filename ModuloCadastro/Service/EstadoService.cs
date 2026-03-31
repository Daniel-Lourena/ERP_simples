using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class EstadoService
    {
        private readonly ModuloCadastroContext _db_context;
        public EstadoService(ModuloCadastroContext db_context) => _db_context = db_context;
        public EstadoEntity Get(int cuf)
        {
            return _db_context.Estados.AsNoTracking().FirstOrDefault(x => x.Cuf.Equals(cuf))!;
        }
        public EstadoEntity Get(string uf)
        {
            return _db_context.Estados.AsNoTracking().FirstOrDefault(x => x.Uf.Equals(uf))!;
        }
        public List<EstadoEntity> GetList()
        {
            return _db_context.Estados.AsNoTracking().ToList();
        }
    }
}
