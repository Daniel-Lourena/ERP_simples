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
        private readonly ModuloCadastroContext _db_context;
        public MaquininhaService(ModuloCadastroContext db_context) => this._db_context = db_context;
        public MaquininhaEntity Get(int id)
        {
            return _db_context.Maquininhas.AsNoTracking()
                .FirstOrDefault(x => x.Id.Equals(id))!;
        }
        public IQueryable<MaquininhaEntity> GetList()
        {
            return _db_context.Maquininhas.AsNoTracking();
        }

        public int Insert(MaquininhaEntity entity)
        {
            int insert = 0;
            using (var autoNumeradorContext = new Service.AutoNumeradorService(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.IdMaquininha++;
                entity.Id = numerador.IdMaquininha;
                _db_context.Maquininhas.Add(entity);
                _db_context.SaveChanges();
                ServiceMethods.UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdMaquininha) });
                insert = entity.Id;
            }
            return insert;
        }
        public void Update(MaquininhaEntity entity)
        {
            _db_context.Maquininhas.Update(entity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(MaquininhaEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
