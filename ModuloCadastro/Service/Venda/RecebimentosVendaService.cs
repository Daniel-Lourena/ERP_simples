using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity.Venda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Service.Venda
{
    public class RecebimentosVendaService : IService<RecebimentoVendaEntity>
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;
        public RecebimentosVendaService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;

        public RecebimentoVendaEntity Get(int id)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.RecebimentosVenda
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id)!;
        }

        public IQueryable<RecebimentoVendaEntity> GetList()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.RecebimentosVenda.AsNoTracking();
        }

        public int Insert(RecebimentoVendaEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.RecebimentosVenda.Add(entity);
            _db_context.SaveChanges();

            return entity.Id;
        }
        public void Update(RecebimentoVendaEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.RecebimentosVenda.Update(entity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(RecebimentoVendaEntity entity, List<string> listaPropriedadesAtualizar)
        {
            var _db_context = _factory.CreateDbContext();
            new ServiceMethods(_db_context).UpdateParcial(entity, listaPropriedadesAtualizar);
        }
        public void Delete(RecebimentoVendaEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.RecebimentosVenda.Remove(new RecebimentoVendaEntity { Id = entity.Id });
            _db_context.SaveChanges();
        }
    }
}
