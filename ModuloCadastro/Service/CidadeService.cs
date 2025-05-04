using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class CidadeService
    {
        public CidadeEntity Get(int id)
        {
            return new ModuloCadastroContext().Cidades.FirstOrDefault(x => x.id.Equals(id))!;
        }
        public List<CidadeEntity> GetList()
        {
            return new ModuloCadastroContext().Cidades.ToList();
        }
        public List<CidadeEntity> GetListByEstado(int cuf)
        {
            return new ModuloCadastroContext().Cidades.ToList().Where(x => x.cuf.Equals(cuf)).ToList();
        }
    }
}
