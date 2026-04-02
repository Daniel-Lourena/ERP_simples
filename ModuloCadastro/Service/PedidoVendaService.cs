using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class PedidoVendaService : IService<PedidoVendaEntity>
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;
        public PedidoVendaService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;


        public PedidoVendaEntity Get(int id)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.PedidosVendas
                .AsNoTracking()
                .Include(x => x.UsuarioCriacao)
                .Include(x => x.UsuarioAtualizacao)
                .Include(x => x.Cliente).ThenInclude(x => x.Cidade).ThenInclude(x => x.DadosEstado)
                .FirstOrDefault(x => x.Id == id)!;
        }
        public IQueryable<PedidoVendaEntity> GetList()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.PedidosVendas.AsNoTracking()
                .Include(x => x.Cliente)
                .Include(x => x.UsuarioCriacao);
        }

        public int Insert(PedidoVendaEntity entity)
        {
            var _db_context = _factory.CreateDbContext();

            int insert = 0;
            var autoNumeradorContext = new Service.AutoNumeradorService(_factory);
            AutoNumeradorEntity numerador = autoNumeradorContext.Get();
            numerador.IdPedidoVenda++;
            entity.Id = numerador.IdPedidoVenda;
            _db_context.PedidosVendas.Add(entity);
            _db_context.SaveChanges();
            new ServiceMethods(_db_context).UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdPedidoVenda) });
            insert = entity.Id;
            return insert;
        }
        public void Update(PedidoVendaEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.PedidosVendas.Update(entity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(PedidoVendaEntity entity, List<string> listaPropriedadesAtualizar)
        {
            var _db_context = _factory.CreateDbContext();
            new ServiceMethods(_db_context).UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}