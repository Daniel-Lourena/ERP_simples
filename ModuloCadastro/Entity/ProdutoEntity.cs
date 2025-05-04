using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModuloCadastro.Enum;
using ModuloCadastro.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloCadastro.Entity
{
    [Table("tb_produtos")]
    public class ProdutoEntity : BaseEntity<ProdutoEntity>
    {
        [Key, Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string descricao { get; set; }
        [Column(TypeName = "int")]
        public EUnidadeProduto idUnidade { get; set; }
        [Column(TypeName = "varchar(7)")]
        public string cest { get; set; }
        [Column(TypeName = "varchar(8)")]
        public string ncm { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string codigoEstoque_SKU { get; set; }
        [Column(TypeName = "int")]
        public int categoria { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal estoqueMinimo { get; set; }
        [Column(TypeName = "int")]
        public EOrigemProduto origem { get; set; }
        [Column(TypeName = "varchar(5)")]
        public ECst cst_csosn { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public bool inativo { get; set; }
        [Column(TypeName = "int")]
        public int usuarioCadastro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dataCadastro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dataAtualizacao { get; set; }

        public CategoriaEntity DadosCategoria { get; set; }


        public ProdutoViewModel ToViewModel()
        {
            return new ProdutoViewModel
            {
                id = this.id,
                descricao = this.descricao,
                idUnidade = this.idUnidade,
                cest = this.cest,
                ncm = this.ncm,
                codigoEstoque_SKU = this.codigoEstoque_SKU,
                categoria = this.categoria,
                estoqueMinimo = this.estoqueMinimo,
                origem = this.origem,
                cst_csosn = this.cst_csosn,
                inativo = this.inativo,
                usuarioCadastro = this.usuarioCadastro,
                dataCadastro = this.dataCadastro,
                dataAtualizacao = this.dataAtualizacao,
                DadosCategoria = this.DadosCategoria
            };
        }
    }
}
