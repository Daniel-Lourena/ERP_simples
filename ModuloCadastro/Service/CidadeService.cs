using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class CidadeService
    {
        private readonly ModuloCadastroContext _db_context;
        public CidadeService(ModuloCadastroContext db_context) => _db_context = db_context;

        public CidadeEntity Get(int id)
        {
            return _db_context.Cidades.AsNoTracking().FirstOrDefault(x => x.Id.Equals(id))!;
        }
        public List<CidadeEntity> GetList()
        {
            return _db_context.Cidades.AsNoTracking().ToList();
        }
        public List<CidadeEntity> GetListByEstado(int cuf)
        {
            return _db_context.Cidades.AsNoTracking().ToList().Where(x => x.Cuf.Equals(cuf)).ToList();
        }
    }
}
