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
        [Key,Display(Name = "Id", Description = "")]
        public int id { get; set; }
        [Display(Name = "Descrição", Description = "")]
        public string descricao { get; set; }
        [Display(Name = "UN", Description = "")]
        public string idUnidade { get; set; }
        [Display(Name = "Setor Estoque", Description = "")]
        public int setorEstoque { get; set; }
        [Display(Name = "CEST", Description = "")]
        public string cest { get; set; }
        [Display(Name = "NCM", Description = "")]
        public string ncm { get; set; }
        [Display(Name = "Cód. Estoque", Description = "")]
        public string codigoEstoque_SKU { get; set; }
        [Display(Name = "Categoria", Description = "")]
        public int categoria { get; set; }
        [Display(Name = "Est. Mínimo", Description = "")]
        public decimal estoqueMinimo { get; set; }
        [Display(Name = "Origem", Description = "")]
        public int origem { get; set; }
        [Display(Name = "CST/CSOSN", Description = "")]
        public string cst_csosn { get; set; }
        [Display(Name = "Inativo", Description = "")]
        public bool inativo { get; set; }
        [Display(Name = "Usuário Cadastro", Description = "")]
        public int usuarioCadastro { get; set; }
        [Display(Name = "Dta. Cadastro", Description = "")]
        public DateTime dataCadastro { get; set; }
        [Display(Name = "Dta. Atualização", Description = "")]
        public DateTime dataAtualizacao { get; set; }
    }
}
