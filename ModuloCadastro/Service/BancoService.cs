using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class BancoService : IService<BancoEntity>
    {
        private ModuloCadastroContext _db_context;

        public BancoService(ModuloCadastroContext db_context) => _db_context = db_context;
        public BancoEntity Get(int id)
        {
            return new ModuloCadastroContext().Bancos.FirstOrDefault(x => x.id.Equals(id))!;
        }
        public List<BancoEntity> GetList()
        {
            return _db_context.Bancos.AsNoTracking().ToList();
        }

        public int Insert(BancoEntity entity)
        {
            int insert = 0;
            using (var autoNumeradorContext = new Service.AutoNumeradorService(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.idBanco++;
                entity.id = numerador.idBanco;
                var _context = new ModuloCadastroContext();
                _context.Bancos.Add(entity);
                _context.SaveChanges();
                ServiceMethods.UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.idBanco) });
                insert = entity.id;
            }
            return insert;
        }
        public void Update(BancoEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.Bancos.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateParcial(BancoEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
