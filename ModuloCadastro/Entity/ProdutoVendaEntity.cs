using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloCadastro.Entity
{
    [Table("tb_produtosvenda")]
    public class ProdutoVendaEntity : BaseEntity<ProdutoVendaEntity>
    {
        [Key, Display(Name = "ID", Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "ID Pedido", Description = ""), Column(TypeName = "int")]
        public int PedidoVendaId { get; set; }
        [Display(Name = "ID Produto", Description = ""), Column(TypeName = "int")]
        public int ProdutoId { get; set; }
        [Display(Name = "Qtde.", Description = ""), Column(TypeName = "decimal(10,2)")]
        public decimal Quantidade { get; set; } = 0;
        [Display(Name = "Valor", Description = ""), Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        [Display(Name = "ID Setor Estoque", Description = ""), Column(TypeName = "int")]
        public int SetorEstoqueId { get; set; }

        public SetorEstoqueEntity SetorEstoque { get; set; }
        public ProdutoEntity Produto { get; set; }
        public PedidoVendaEntity PedidoVenda { get; set; }
    }
}
