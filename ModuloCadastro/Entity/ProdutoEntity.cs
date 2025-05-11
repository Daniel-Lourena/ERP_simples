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
        public int Id { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Descricao { get; set; }
        [Column(TypeName = "int")]
        public EUnidadeProduto UnidadeId { get; set; }
        [Column(TypeName = "varchar(7)")]
        public string Cest { get; set; }
        [Column(TypeName = "varchar(8)")]
        public string Ncm { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CodigoEstoque_SKU { get; set; }
        [Column(TypeName = "int")]
        public int CategoriaId { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal EstoqueMinimo { get; set; }
        [Column(TypeName = "int")]
        public EOrigemProduto Origem { get; set; }
        [Column(TypeName = "varchar(5)")]
        public ECst Cst_csosn { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public bool Inativo { get; set; }
        [Column(TypeName = "int")]
        public int UsuarioCadastroId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCadastro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }

        public CategoriaEntity Categoria { get; set; }


        public ProdutoViewModel ToViewModel()
        {
            return new ProdutoViewModel
            {
                id = this.Id,
                descricao = this.Descricao,
                idUnidade = this.UnidadeId,
                cest = this.Cest,
                ncm = this.Ncm,
                codigoEstoque_SKU = this.CodigoEstoque_SKU,
                categoria = this.CategoriaId,
                estoqueMinimo = this.EstoqueMinimo,
                origem = this.Origem,
                cst_csosn = this.Cst_csosn,
                inativo = this.Inativo,
                usuarioCadastro = this.UsuarioCadastroId,
                dataCadastro = this.DataCadastro,
                dataAtualizacao = this.DataAtualizacao,
                DadosCategoria = this.Categoria
            };
        }
    }
}
