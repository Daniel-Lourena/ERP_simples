using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Context
{
    public class PedidoVendaContext : IContext<PedidoVendaEntity>
    {
        private ModuloCadastroContext _db_context;

        public PedidoVendaContext(ModuloCadastroContext db_context)
        {
            this._db_context = db_context;
        }

        public PedidoVendaEntity Get(int id)
        {
            return new ModuloCadastroContext().PedidosVendas.FirstOrDefault(x => x.id.Equals(id))!;
        }
        public List<PedidoVendaEntity> GetList()
        {
            return _db_context.PedidosVendas
                .AsNoTracking().ToList();
        }

        public void Insert(PedidoVendaEntity entity)
        {
            using (var autoNumeradorContext = new ModuloCadastro.Context.AutoNumeradorContext(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.idPedidoVenda++;
                entity.id = numerador.idUsuario;
                var _context = new ModuloCadastroContext();
                _context.PedidosVendas.Add(entity);
                _context.SaveChanges();
                ContextMethods.UpdateParcial<AutoNumeradorEntity>(numerador, new List<string>() { nameof(AutoNumeradorEntity.idUsuario) });
            }
        }
        public void Update(PedidoVendaEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.PedidosVendas.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateParcial(PedidoVendaEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ContextMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}