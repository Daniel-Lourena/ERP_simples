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
    public class MaquininhaService : IService<MaquininhaEntity>
    {
        public MaquininhaEntity Get(int id)
        {
            return new ModuloCadastroContext().Maquininhas.AsNoTracking()
                .FirstOrDefault(x => x.Id.Equals(id))!;
        }
        public IQueryable<MaquininhaEntity> GetList()
        {
            return new ModuloCadastroContext().Maquininhas.AsNoTracking();
        }

        public int Insert(MaquininhaEntity entity)
        {
            int insert = 0;
            using (var autoNumeradorContext = new Service.AutoNumeradorService(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.IdMaquininha++;
                entity.Id = numerador.IdMaquininha;
                var _context = new ModuloCadastroContext();
                _context.Maquininhas.Add(entity);
                _context.SaveChanges();
                ServiceMethods.UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdMaquininha) });
                insert = entity.Id;
            }
            return insert;
        }
        public void Update(MaquininhaEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.Maquininhas.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateParcial(MaquininhaEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
