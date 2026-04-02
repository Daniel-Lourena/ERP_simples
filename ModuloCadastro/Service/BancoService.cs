using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class BancoService : IService<BancoEntity>
    {
        private readonly ModuloCadastroContext _db_context;

        public BancoService(ModuloCadastroContext db_context) => _db_context = db_context;
        public BancoEntity Get(int id)
        {
            return _db_context.Bancos.FirstOrDefault(x => x.Id.Equals(id))!;
        }
        public IQueryable<BancoEntity> GetList()
        {
            return _db_context.Bancos.AsNoTracking();
        }

        public int Insert(BancoEntity entity)
        {
            int insert = 0;
            var autoNumeradorContext = new Service.AutoNumeradorService(_db_context);
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
            _db_context.Bancos.Update(entity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(BancoEntity entity, List<string> listaPropriedadesAtualizar)
        {
            new ServiceMethods(_db_context).UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
