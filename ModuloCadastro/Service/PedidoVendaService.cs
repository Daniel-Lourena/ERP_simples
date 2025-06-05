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
            return new ModuloCadastroContext().PedidosVendas
                .AsNoTracking()
                .Include(x => x.UsuarioCriacao)
                .Include(x => x.UsuarioAtualizacao)
                .Include(x => x.Cliente).ThenInclude(x => x.Cidade).ThenInclude(x => x.DadosEstado)
                .FirstOrDefault(x => x.Id.Equals(id))!;
        }
        public IQueryable<PedidoVendaEntity> GetList()
        {
            return _db_context.PedidosVendas.AsNoTracking()
                .Include(x => x.Cliente)
                .Include(x => x.UsuarioCriacao);
        }

        public int Insert(PedidoVendaEntity entity)
        {
            int insert = 0;
            using (var autoNumeradorContext = new Service.AutoNumeradorService(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.IdPedidoVenda++;
                entity.Id = numerador.IdPedidoVenda;
                var _context = new ModuloCadastroContext();
                _context.PedidosVendas.Add(entity);
                _context.SaveChanges();
                ServiceMethods.UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdPedidoVenda) });
                insert = entity.Id;
            }
            return insert;
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