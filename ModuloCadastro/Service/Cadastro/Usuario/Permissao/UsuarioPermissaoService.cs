using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity.Cadastro.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Service.Cadastro.Usuario.Permissao
{
    public class UsuarioPermissaoService 
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;
        public UsuarioPermissaoService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;

        public IQueryable<UsuarioPermissaoEntity> GetPermissoesByUsuarioId(int usuarioId)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.UsuariosPermissoes.Where(x => x.UsuarioId == usuarioId)!;
        }
    }
}
