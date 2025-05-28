using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class CidadeService
    {
        public CidadeEntity Get(int id)
        {
            return new ModuloCadastroContext().Cidades.AsNoTracking().FirstOrDefault(x => x.Id.Equals(id))!;
        }
        public List<CidadeEntity> GetList()
        {
            return new ModuloCadastroContext().Cidades.AsNoTracking().ToList();
        }
        public List<CidadeEntity> GetListByEstado(int cuf)
        {
            return new ModuloCadastroContext().Cidades.AsNoTracking().ToList().Where(x => x.Cuf.Equals(cuf)).ToList();
        }
    }
}
