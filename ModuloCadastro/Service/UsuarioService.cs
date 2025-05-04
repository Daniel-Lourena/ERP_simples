using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Service
{
    public class UsuarioService : IService<UsuarioEntity>
    {
        private ModuloCadastroContext _db_context;
        public UsuarioService(ModuloCadastroContext db_context) => _db_context = db_context;
        public UsuarioEntity Get(int id)
        {
            return new ModuloCadastroContext().Usuarios.FirstOrDefault(x => x.id.Equals(id))!;
        }
        public List<UsuarioEntity> GetList()
        {
            return _db_context.Usuarios
                .AsNoTracking().ToList();
        }

        public int Insert(UsuarioEntity entity)
        {
            int insert = 0;
            using (var autoNumeradorContext = new Service.AutoNumeradorService(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.idUsuario++;
                entity.id = numerador.idUsuario;
                var _context = new ModuloCadastroContext();
                _context.Usuarios.Add(entity);
                _context.SaveChanges();
                ServiceMethods.UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.idUsuario) });
                insert = entity.id;
            }
            return insert;
        }
        public void Update(UsuarioEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.Usuarios.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateParcial(UsuarioEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
