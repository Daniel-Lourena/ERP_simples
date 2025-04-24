using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    public class BancoContext : IContext<BancoEntity>
    {
        private ModuloCadastro.Context.ModuloCadastroContext _db_context;

        public BancoContext (ModuloCadastroContext db_context) => _db_context = db_context;
        public BancoEntity Get(int id)
        {
            return new ModuloCadastroContext().Bancos.FirstOrDefault(x => x.id.Equals(id))!;
        }
        public List<BancoEntity> GetList()
        {
            return _db_context.Bancos.ToList();
        }

        public void Insert(BancoEntity entity)
        {
            using (var autoNumeradorContext = new ModuloCadastro.Context.AutoNumeradorContext(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.idBanco++;
                entity.id = numerador.idBanco;
                var _context = new ModuloCadastroContext();
                _context.Bancos.Add(entity);
                _context.SaveChanges();
                ContextMethods.UpdateParcial<AutoNumeradorEntity>(numerador, new List<string>() { nameof(AutoNumeradorEntity.idBanco) });
            }
        }
        public void Update(BancoEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.Bancos.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateParcial(BancoEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ContextMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
