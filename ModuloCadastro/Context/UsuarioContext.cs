using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    public class UsuarioContext : ModuloCadastroContext
    {
        private ModuloCadastro.Context.ModuloCadastroContext _db_context;
        public UsuarioContext(ModuloCadastroContext db_context) => _db_context = db_context;
        public UsuarioEntity Get(int id)
        {
            return new ModuloCadastroContext().Usuarios.FirstOrDefault(x => x.id.Equals(id))!;
        }
        public List<UsuarioEntity> GetList()
        {
            return _db_context.Usuarios.ToList();
        }

        public void Insert(UsuarioEntity usuarioEntity)
        {
            var _context = new ModuloCadastroContext();
            _context.Usuarios.Add(usuarioEntity);
            _context.SaveChanges();
        }
        public void Update(UsuarioEntity usuarioEntity)
        {
            var _context = new ModuloCadastroContext();
            _context.Usuarios.Update(usuarioEntity);
            _context.SaveChanges();
        }

        public void UpdateParcial(UsuarioEntity entity,List<string> listaPropriedadesAtualizar)
        {
            ContextMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
