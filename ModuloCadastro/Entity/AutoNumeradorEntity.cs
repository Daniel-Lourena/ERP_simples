using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_autonumerador")]
    public class AutoNumeradorEntity : BaseEntity<AutoNumeradorEntity>
    {
        [Key,Display(Name = "ID",Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "ID Cliente",Description = ""), Column(TypeName = "int")]
        public int idCliente { get; set; }
        [Display(Name = "ID Usuário",Description = ""), Column(TypeName = "int")]
        public int idUsuario { get; set; }
        [Display(Name = "ID Produto", Description = ""), Column(TypeName = "int")]
        public int idProduto { get; set; }
        [Display(Name = "ID Banco", Description = ""), Column(TypeName = "int")]
        public int idBanco { get; set; }
        [Display(Name = "ID Pedido", Description = ""), Column(TypeName = "int")]
        public int idPedido { get; set; }
    }
}
