using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class UsuarioService : IService<UsuarioEntity>
    {
        private readonly ModuloCadastroContext _db_context;

        public UsuarioService(ModuloCadastroContext db_context) => _db_context = db_context;
        public UsuarioEntity Get(int id)
        {
            return _db_context.Usuarios.FirstOrDefault(x => x.Id.Equals(id))!;
        }
        public IQueryable<UsuarioEntity> GetList()
        {
            return _db_context.Usuarios.AsNoTracking();
        }

        public int Insert(UsuarioEntity entity)
        {
            int insert = 0;
            using (var autoNumeradorContext = new Service.AutoNumeradorService(_db_context))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.IdUsuario++;
                entity.Id = numerador.IdUsuario;
                _db_context.Usuarios.Add(entity);
                _db_context.SaveChanges();
                ServiceMethods.UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdUsuario) });
                insert = entity.Id;
            }
            return insert;
        }
        public void Update(UsuarioEntity entity)
        {
            _db_context.Usuarios.Update(entity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(UsuarioEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
