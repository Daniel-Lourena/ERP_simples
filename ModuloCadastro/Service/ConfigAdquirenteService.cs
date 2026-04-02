using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Service
{
    public class ConfigAdquirenteService
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;
        public ConfigAdquirenteService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;

        public ConfigAdquirenteEntity Get(int id)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.ConfigAdquirentes.AsNoTracking()
                .FirstOrDefault(x => x.Id == id)!;
        }
        public IQueryable<ConfigAdquirenteEntity> GetList()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.ConfigAdquirentes.AsNoTracking();
        }

        public int Insert(ConfigAdquirenteEntity entity)
        {
            var _db_context = _factory.CreateDbContext();

            int insert = 0;
            var autoNumeradorContext = new Service.AutoNumeradorService(_factory);
            AutoNumeradorEntity numerador = autoNumeradorContext.Get();
            numerador.IdAdquirente++;
            entity.Id = numerador.IdAdquirente;
            var _context = _db_context;
            _context.ConfigAdquirentes.Add(entity);
            _context.SaveChanges();
            new ServiceMethods(_context).UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdAdquirente) });
            insert = entity.Id;
            return insert;
        }
        public void Update(ConfigAdquirenteEntity entity)
        {
            var _db_context = _factory.CreateDbContext();

            _db_context.ConfigAdquirentes.Update(entity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(ConfigAdquirenteEntity entity, List<string> listaPropriedadesAtualizar)
        {
            var _db_context = _factory.CreateDbContext();
            new ServiceMethods(_db_context).UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
