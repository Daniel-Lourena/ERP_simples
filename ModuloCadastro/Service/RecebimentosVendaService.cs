using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Service
{
    public class RecebimentosVendaService : IService<RecebimentoVendaEntity>
    {
        private readonly ModuloCadastroContext _db_context;
        public RecebimentosVendaService(ModuloCadastroContext db_context) => this._db_context = db_context;

        public RecebimentoVendaEntity Get(int id)
        {
            return _db_context.RecebimentosVenda
                .AsNoTracking()
                .FirstOrDefault(x => x.Id.Equals(id))!;
        }

        public IQueryable<RecebimentoVendaEntity> GetList()
        {
            return _db_context.RecebimentosVenda.AsNoTracking();
        }

        public int Insert(RecebimentoVendaEntity entity)
        {
            _db_context.RecebimentosVenda.Add(entity);
            _db_context.SaveChanges();

            return entity.Id;
        }
        public void Update(RecebimentoVendaEntity entity)
        {
            _db_context.RecebimentosVenda.Update(entity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(RecebimentoVendaEntity entity, List<string> listaPropriedadesAtualizar)
        {
            new ServiceMethods(_db_context).UpdateParcial(entity, listaPropriedadesAtualizar);
        }
        public void Delete(RecebimentoVendaEntity entity)
        {
            _db_context.RecebimentosVenda.Remove(new RecebimentoVendaEntity { Id = entity.Id });
            _db_context.SaveChanges();
        }
    }
}
