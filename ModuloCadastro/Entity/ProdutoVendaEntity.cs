using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_produtosvenda")]
    public class ProdutoVendaEntity : BaseEntity<ProdutoVendaEntity>
    {
        [Key,Display(Name = "Nome", Description = ""), Column(TypeName = "int"),DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "ID Pedido", Description = ""), Column(TypeName = "int")]
        public int idPedido { get; set; }
        [Display(Name = "ID Produto", Description = ""), Column(TypeName = "int")]
        public int idProduto { get; set; }
        [Display(Name = "Qtde.", Description = ""), Column(TypeName = "decimal(10,2)")]
        public decimal quantidade { get; set; }
        public ProdutoEntity DadosProduto { get; set; }
        public PedidoVendaEntity DadosPedidoVenda { get; set; }
    }
}
