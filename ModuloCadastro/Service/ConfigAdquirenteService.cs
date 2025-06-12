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
        public ConfigAdquirenteEntity Get(int id)
        {
            return new ModuloCadastroContext().ConfigAdquirentes.AsNoTracking()
                .FirstOrDefault(x => x.Id.Equals(id))!;
        }
        public IQueryable<ConfigAdquirenteEntity> GetList()
        {
            return new ModuloCadastroContext().ConfigAdquirentes.AsNoTracking();
        }

        public int Insert(ConfigAdquirenteEntity entity)
        {
            int insert = 0;
            using (var autoNumeradorContext = new Service.AutoNumeradorService(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.IdAdquirente++;
                entity.Id = numerador.IdAdquirente;
                var _context = new ModuloCadastroContext();
                _context.ConfigAdquirentes.Add(entity);
                _context.SaveChanges();
                ServiceMethods.UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdAdquirente) });
                insert = entity.Id;
            }
            return insert;
        }
        public void Update(ConfigAdquirenteEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.ConfigAdquirentes.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateParcial(ConfigAdquirenteEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
