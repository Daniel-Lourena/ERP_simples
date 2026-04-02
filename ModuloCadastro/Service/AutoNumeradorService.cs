using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class AutoNumeradorService 
    {
        private readonly ModuloCadastroContext _db_context;
        public AutoNumeradorService(ModuloCadastroContext db_context) => _db_context = db_context;

        public AutoNumeradorEntity Get()
        {
            return _db_context.AutoNumeradores.FirstOrDefault(x => x.Id.Equals(1));
        }
    }
}
