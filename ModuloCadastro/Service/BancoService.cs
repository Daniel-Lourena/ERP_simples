using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class BancoService : IService<BancoEntity>
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;

        public BancoService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;
        public BancoEntity Get(int id)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Bancos.FirstOrDefault(x => x.Id == id)!;
        }
        public IQueryable<BancoEntity> GetList()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Bancos.AsNoTracking();
        }

        public int Insert(BancoEntity entity)
        {
            var _db_context = _factory.CreateDbContext();

            int insert = 0;
            var autoNumeradorContext = new Service.AutoNumeradorService(_factory);
            AutoNumeradorEntity numerador = autoNumeradorContext.Get();
            numerador.IdBanco++;
            entity.Id = numerador.IdBanco;
            _db_context.Bancos.Add(entity);
            _db_context.SaveChanges();
            new ServiceMethods(_db_context).UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdBanco) });
            insert = entity.Id;
            return insert;
        }
        public void Update(BancoEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.Bancos.Update(entity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(BancoEntity entity, List<string> listaPropriedadesAtualizar)
        {
            var _db_context = _factory.CreateDbContext();
            new ServiceMethods(_db_context).UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
