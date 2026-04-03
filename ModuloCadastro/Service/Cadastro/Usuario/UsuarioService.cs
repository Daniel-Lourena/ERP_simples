using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Entity.Cadastro.Usuario;

namespace ModuloCadastro.Service.Cadastro.Usuario
{
    public class UsuarioService : IService<UsuarioEntity>
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;
        public UsuarioService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;
        
        public UsuarioEntity Get(int id)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Usuarios.FirstOrDefault(x => x.Id == id)!;
        }
        public IQueryable<UsuarioEntity> GetList()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Usuarios.AsNoTracking();
        }

        public int Insert(UsuarioEntity entity)
        {
            var _db_context = _factory.CreateDbContext();

            int insert = 0;
            var autoNumeradorContext = new Service.AutoNumeradorService(_factory);
            AutoNumeradorEntity numerador = autoNumeradorContext.Get();
            numerador.IdUsuario++;
            entity.Id = numerador.IdUsuario;
            _db_context.Usuarios.Add(entity);
            _db_context.SaveChanges();
            new ServiceMethods(_db_context).UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdUsuario) });
            insert = entity.Id;
            return insert;
        }
        public void Update(UsuarioEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.Usuarios.Update(entity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(UsuarioEntity entity, List<string> listaPropriedadesAtualizar)
        {
            var _db_context = _factory.CreateDbContext();
            new ServiceMethods(_db_context).UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
