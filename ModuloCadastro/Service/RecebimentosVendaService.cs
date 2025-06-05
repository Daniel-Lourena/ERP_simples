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
        public RecebimentoVendaEntity Get(int id)
        {
            return new ModuloCadastroContext().RecebimentosVenda
                .AsNoTracking()
                .FirstOrDefault(x => x.Id.Equals(id))!;
        }

        public IQueryable<RecebimentoVendaEntity> GetList()
        {
            return new ModuloCadastroContext().RecebimentosVenda.AsNoTracking();
        }

        public int Insert(RecebimentoVendaEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.RecebimentosVenda.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }
        public void Update(RecebimentoVendaEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.RecebimentosVenda.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateParcial(RecebimentoVendaEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
