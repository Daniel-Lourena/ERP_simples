using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    public class ClienteContext 
    {
        public ClienteEntity Get(int id)
        {
            return new ModuloCadastroContext().Clientes.FirstOrDefault(x => x.id.Equals(id))!;
        }
        public List<ClienteEntity> GetList()
        {
            return new ModuloCadastroContext().Clientes.ToList();
        }

        public void Insert(ClienteEntity clienteEntity)
        {
            var _context = new ModuloCadastroContext();
            _context.Clientes.Add(clienteEntity);
            _context.SaveChanges();
        }
        
        public void Update(ClienteEntity clienteEntity)
        {
            var _context = new ModuloCadastroContext();
            _context.Clientes.Update(clienteEntity);
            _context.SaveChanges();
        }

        public void UpdateParcial(ClienteEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ContextMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
