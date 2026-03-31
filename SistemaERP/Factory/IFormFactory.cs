using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaERP.Factory
{
    public interface IFormFactory
    {
        T Criar<T>(params object[] parameters) where T : Form;
    }
}
