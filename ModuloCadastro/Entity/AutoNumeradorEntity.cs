using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloCadastro.Entity
{
    [Table("tb_autonumerador")]
    public class AutoNumeradorEntity : BaseEntity<AutoNumeradorEntity>
    {
        [Key, Display(Name = "ID", Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "ID Cliente", Description = ""), Column(TypeName = "int")]
        public int IdCliente { get; set; }
        [Display(Name = "ID Usuário", Description = ""), Column(TypeName = "int")]
        public int IdUsuario { get; set; }
        [Display(Name = "ID Produto", Description = ""), Column(TypeName = "int")]
        public int IdProduto { get; set; }
        [Display(Name = "ID Banco", Description = ""), Column(TypeName = "int")]
        public int IdBanco { get; set; }
        [Display(Name = "ID Pedido Venda", Description = ""), Column(TypeName = "int")]
        public int IdPedidoVenda { get; set; }
    }
}
