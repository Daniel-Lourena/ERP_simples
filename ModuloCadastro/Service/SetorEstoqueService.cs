using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class SetorEstoqueService
    {
        public List<SetorEstoqueEntity> GetList()
        {
            return new ModuloCadastroContext().SetoresEstoque.ToList();
        }
    }
}
