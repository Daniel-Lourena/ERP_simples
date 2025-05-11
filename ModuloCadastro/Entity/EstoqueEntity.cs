using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloCadastro.Entity
{
    [Table("tb_estoque")]
    public class EstoqueEntity : BaseEntity<EstoqueEntity>
    {
        [Display(Name = "ProdutoId", Description = ""), Column(TypeName = "int")]
        public int ProdutoId { get; set; }
        [Display(Name = "quantidade", Description = ""), Column(TypeName = "decimal(10,2)")]
        public decimal Quantidade { get; set; }
        [Display(Name = "setorEstoque", Description = ""), Column(TypeName = "int")]
        public int SetorEstoqueId { get; set; }

        public SetorEstoqueEntity SetorEstoque { get; set; }
        public ProdutoEntity Produto { get; set; }
    }
}
