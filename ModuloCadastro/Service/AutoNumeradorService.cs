using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Service
{
    public class AutoNumeradorService : IDisposable
    {
        ModuloCadastroContext _db_context;
        public AutoNumeradorService(ModuloCadastroContext db_context) => _db_context = db_context;

        public void Dispose()
        {
            _db_context.Dispose();
        }

        public AutoNumeradorEntity Get()
        {
            return _db_context.AutoNumeradores.FirstOrDefault(x => x.id.Equals(1));
        }
    }
}
