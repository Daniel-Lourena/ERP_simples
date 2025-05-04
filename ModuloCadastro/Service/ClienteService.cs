using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class ClienteService : IService<ClienteEntity>
    {
        ModuloCadastroContext _db_context;

        public ClienteService(ModuloCadastroContext db_context) => _db_context = db_context;

        public ClienteEntity Get(int id)
        {
            return _db_context.Clientes.FirstOrDefault(x => x.id.Equals(id))!;
        }
        public List<ClienteEntity> GetList()
        {
            return _db_context.Clientes
                .AsNoTracking()
                .Include(c => c.DadosCidade)
                .ThenInclude(c => c.DadosEstado)
                .ToList();
        }

        public int Insert(ClienteEntity entity)
        {
            int insert = 0;
            using (var autoNumeradorContext = new Service.AutoNumeradorService(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.idCliente++;
                entity.id = numerador.idCliente;
                var _context = new ModuloCadastroContext();
                _context.Clientes.Add(entity);
                _context.SaveChanges();
                ServiceMethods.UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.idCliente) });
                insert = entity.id;
            }
            return insert;
        }

        public void Update(ClienteEntity clienteEntity)
        {
            var _context = new ModuloCadastroContext();
            _context.Clientes.Update(clienteEntity);
            _context.SaveChanges();
        }

        public void UpdateParcial(ClienteEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
