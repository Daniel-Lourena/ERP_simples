using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class UsuarioService : IService<UsuarioEntity>
    {
        private ModuloCadastroContext _db_context;
        public UsuarioService(ModuloCadastroContext db_context) => _db_context = db_context;
        public UsuarioEntity Get(int id)
        {
            return new ModuloCadastroContext().Usuarios.FirstOrDefault(x => x.Id.Equals(id))!;
        }
        public IQueryable<UsuarioEntity> GetList()
        {
            return _db_context.Usuarios.AsNoTracking();
        }

        public int Insert(UsuarioEntity entity)
        {
            int insert = 0;
            using (var autoNumeradorContext = new Service.AutoNumeradorService(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.IdUsuario++;
                entity.Id = numerador.IdUsuario;
                var _context = new ModuloCadastroContext();
                _context.Usuarios.Add(entity);
                _context.SaveChanges();
                ServiceMethods.UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdUsuario) });
                insert = entity.Id;
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
