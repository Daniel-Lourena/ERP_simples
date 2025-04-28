using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_estoque")]
    public class EstoqueEntity : BaseEntity<EstoqueEntity>
    {
        [Display(Name = "idProduto", Description = ""), Column(TypeName = "int")]
        public int idProduto { get; set; }
        [Display(Name = "quantidade", Description = ""), Column(TypeName = "decimal(10,2)")]
        public decimal quantidade { get; set; }
        [Display(Name = "setorEstoque", Description = ""), Column(TypeName = "int")]
        public int setorEstoque { get; set; }

        public SetorEstoqueEntity DadosSetorEstoque { get; set; }
        public ProdutoEntity DadosProduto{ get; set; }
    }
}
