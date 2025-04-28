using ModuloCadastro.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_produtos")]
    public class ProdutoEntity : BaseEntity<ProdutoEntity>
    {
        [Key, Display(Name = "ID", Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Display(Name = "Descrição", Description = ""), Column(TypeName = "varchar(150)")]
        public string descricao { get; set; }
        [Display(Name = "idUnidade", Description = ""), Column(TypeName = "int")]
        public EUnidadeProduto idUnidade { get; set; }
        [Display(Name = "CEST", Description = ""), Column(TypeName = "varchar(7)")]
        public string cest { get; set; }
        [Display(Name = "NCM", Description = ""), Column(TypeName = "varchar(8)")]
        public string ncm { get; set; }
        [Display(Name = "Cód. Estoque", Description = ""), Column(TypeName = "varchar(100)")]
        public string codigoEstoque_SKU { get; set; }
        [Display(Name = "Categoria", Description = ""), Column(TypeName = "int")]
        public int categoria { get; set; }
        [Display(Name = "Est. Mínimo", Description = ""), Column(TypeName = "decimal(10,2)")]
        public decimal estoqueMinimo { get; set; }
        [Display(Name = "Origem", Description = ""), Column(TypeName = "int")]
        public EOrigemProduto origem { get; set; }
        [Display(Name = "CST/CSOSN", Description = ""), Column(TypeName = "varchar(5)")]
        public string cst_csosn { get; set; }
        [Display(Name = "Inativo", Description = ""), Column(TypeName = "tinyint(1)")]
        public bool inativo { get; set; }
        [Display(Name = "Usuário Cadastro", Description = ""), Column(TypeName = "int")]
        public int usuarioCadastro { get; set; }
        [Display(Name = "Dta. Cadastro", Description = ""), Column(TypeName = "datetime")]
        public DateTime dataCadastro { get; set; }
        [Display(Name = "Dta. Atualização", Description = ""), Column(TypeName = "datetime")]
        public DateTime dataAtualizacao { get; set; }

        public CategoriaEntity DadosCategoria { get; set; }
    }
}
