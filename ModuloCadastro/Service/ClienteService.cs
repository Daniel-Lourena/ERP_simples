using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class ClienteService : IService<ClienteEntity>
    {
        private readonly ModuloCadastroContext _db_context;

        public ClienteService(ModuloCadastroContext db_context) => _db_context = db_context;

        public ClienteEntity Get(int id)
        {
            return _db_context.Clientes.AsNoTracking()
                .Include(c => c.Cidade).ThenInclude(c => c.DadosEstado)
                .FirstOrDefault(x => x.Id.Equals(id))!;
        }
        public IQueryable<ClienteEntity> GetList()
        {
            return _db_context.Clientes.AsNoTracking()
                .Include(c => c.Cidade).ThenInclude(c => c.DadosEstado);
        }

        public int Insert(ClienteEntity entity)
        {
            int insert = 0;
            using (var autoNumeradorContext = new Service.AutoNumeradorService(_db_context))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.IdCliente++;
                entity.Id = numerador.IdCliente;
                _db_context.Clientes.Add(entity);
                _db_context.SaveChanges();
                ServiceMethods.UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdCliente) });
                insert = entity.Id;
            }
            return insert;
        }

        public void Update(ClienteEntity clienteEntity)
        {
            _db_context.Clientes.Update(clienteEntity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(ClienteEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
