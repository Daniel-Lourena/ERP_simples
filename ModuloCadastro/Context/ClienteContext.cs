using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    public class ClienteContext : IContext<ClienteEntity>
    {
        ModuloCadastro.Context.ModuloCadastroContext _db_context;

        public ClienteContext(ModuloCadastroContext db_context) => _db_context = db_context;

        public ClienteEntity Get(int id)
        {
            return _db_context.Clientes.FirstOrDefault(x => x.id.Equals(id))!;
        }
        public List<ClienteEntity> GetList()
        {
            return _db_context.Clientes
                .Include(c => c.DadosCidade)
                .ThenInclude(c => c.DadosEstado)
                .AsNoTracking()
                .ToList();
        }

        public void Insert(ClienteEntity clienteEntity)
        {
            using (var autoNumeradorContext = new ModuloCadastro.Context.AutoNumeradorContext(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.idCliente++;
                clienteEntity.id = numerador.idCliente;
                var _context = new ModuloCadastroContext();
                _context.Clientes.Add(clienteEntity);
                _context.SaveChanges();
                ContextMethods.UpdateParcial<AutoNumeradorEntity>(numerador, new List<string>() { nameof(AutoNumeradorEntity.idCliente) });
            }
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
