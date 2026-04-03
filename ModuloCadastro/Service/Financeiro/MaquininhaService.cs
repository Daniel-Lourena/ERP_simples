using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Entity.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Service.Financeiro
{
    public class MaquininhaService : IService<MaquininhaEntity>
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;
        public MaquininhaService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;

        public MaquininhaEntity Get(int id)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Maquininhas.AsNoTracking()
                .FirstOrDefault(x => x.Id == id)!;
        }
        public IQueryable<MaquininhaEntity> GetList()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Maquininhas.AsNoTracking();
        }

        public int Insert(MaquininhaEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            int insert = 0;
            var autoNumeradorContext = new Service.AutoNumeradorService(_factory);
            AutoNumeradorEntity numerador = autoNumeradorContext.Get();
            numerador.IdMaquininha++;
            entity.Id = numerador.IdMaquininha;
            _db_context.Maquininhas.Add(entity);
            _db_context.SaveChanges();
            new ServiceMethods(_db_context).UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdMaquininha) });
            insert = entity.Id;
            return insert;
        }
        public void Update(MaquininhaEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.Maquininhas.Update(entity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(MaquininhaEntity entity, List<string> listaPropriedadesAtualizar)
        {
            var _db_context = _factory.CreateDbContext();
            new ServiceMethods(_db_context).UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
