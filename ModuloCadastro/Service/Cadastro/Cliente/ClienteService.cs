using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Entity.Cadastro.Cliente;
using ModuloCadastro.Entity.Cadastro.Localizacao;

namespace ModuloCadastro.Service.Cadastro.Cliente
{
    public class ClienteService : IService<ClienteEntity>
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;
        public ClienteService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;

        public ClienteEntity Get(int id)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Clientes.AsNoTracking()
                .Include(c => c.Cidade).ThenInclude(c => c.DadosEstado)
                .FirstOrDefault(x => x.Id == id)!;
        }
        public IQueryable<ClienteEntity> GetList()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Clientes.AsNoTracking()
                .Include(c => c.Cidade).ThenInclude(c => c.DadosEstado);
        }

        public int Insert(ClienteEntity entity)
        {
            var _db_context = _factory.CreateDbContext();

            int insert = 0;
            var autoNumeradorContext = new Service.AutoNumeradorService(_factory);
            AutoNumeradorEntity numerador = autoNumeradorContext.Get();
            numerador.IdCliente++;
            entity.Id = numerador.IdCliente;
            _db_context.Clientes.Add(entity);
            _db_context.SaveChanges();
            new ServiceMethods(_db_context).UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdCliente) });
            insert = entity.Id;
            return insert;
        }

        public void Update(ClienteEntity clienteEntity)
        {
            var _db_context = _factory.CreateDbContext();

            _db_context.Clientes.Update(clienteEntity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(ClienteEntity entity, List<string> listaPropriedadesAtualizar)
        {
            var _db_context = _factory.CreateDbContext();
            new ServiceMethods(_db_context).UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
