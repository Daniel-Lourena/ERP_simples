using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class EstadoService
    {
        public EstadoEntity Get(int cuf)
        {
            return new ModuloCadastroContext().Estados.FirstOrDefault(x => x.cuf.Equals(cuf))!;
        }
        public EstadoEntity Get(string uf)
        {
            return new ModuloCadastroContext().Estados.FirstOrDefault(x => x.uf.Equals(uf))!;
        }
        public List<EstadoEntity> GetList()
        {
            return new ModuloCadastroContext().Estados.ToList();
        }
    }
}
