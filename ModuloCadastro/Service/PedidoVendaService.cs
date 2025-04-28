using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class PedidoVendaService : IService<PedidoVendaEntity>
    {
        private ModuloCadastroContext _db_context;

        public PedidoVendaService(ModuloCadastroContext db_context)
        {
            _db_context = db_context;
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
            using (var autoNumeradorContext = new Service.AutoNumeradorService(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.idPedidoVenda++;
                entity.id = numerador.idUsuario;
                var _context = new ModuloCadastroContext();
                _context.PedidosVendas.Add(entity);
                _context.SaveChanges();
                ServiceMethods.UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.idUsuario) });
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
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}