using ModuloCadastro.Enum.Usuario.Perfil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity.Cadastro.Usuario
{
    [Table("tb_usuario_permissao")]
    public class UsuarioPermissaoEntity : BaseEntity<UsuarioPermissaoEntity>
    {
        [Key,Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsuarioId { get; set; }
        [Key, Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Permissao PermissaoId { get; set; }

        #region Navegacao
        public UsuarioEntity Usuario { get; set; }
        #endregion
    }
}
