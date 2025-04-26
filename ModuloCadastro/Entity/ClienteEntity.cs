using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_clientes")]
    public class ClienteEntity : BaseEntity<ClienteEntity>
    {
        [Key, Display(Name = "ID", Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Display(Name = "Razão Social", Description = ""), Column(TypeName = "varchar(255)")]
        public string razaoSocial { get; set; }
        [Display(Name = "Fantasia", Description = ""), Column(TypeName = "varchar(100)")]
        public string fantasia { get; set; }
        [Display(Name = "Limite Crédito", Description = ""), Column(TypeName = "decimal(10,2)")]
        public decimal limiteCredito { get; set; }
        [Display(Name = "Rua", Description = ""), Column(TypeName = "varchar(255)")]
        public string end_nomeRua { get; set; }
        [Display(Name = "Bairro", Description = ""), Column(TypeName = "varchar(100)")]
        public string end_bairro { get; set; }
        [Display(Name = "N°", Description = ""), Column(TypeName = "varchar(20)")]
        public string end_numero { get; set; }
        [Display(Name = "Logradouro", Description = ""), Column(TypeName = "varchar(10)")]
        public string end_logradouro { get; set; }
        [Display(Name = "UF", Description = ""), Column(TypeName = "int")]
        public int end_uf { get; set; }
        [Display(Name = "ID Cidade", Description = ""), Column(TypeName = "int")]
        public int end_cidade { get; set; }
        [Display(Name = "Dta. Cadastro", Description = ""), Column(TypeName = "datetime")]
        public DateTime dataCadastro { get; set; }
        [Display(Name = "Dta. Atualização", Description = ""), Column(TypeName = "datetime")]
        public DateTime dataAtualizacao { get; set; }
        [Display(Name = "Excluído", Description = ""), Column(TypeName = "tinyint(1)")]
        public bool excluido { get; set; }
        [Display(Name = "Dta. Exclusão", Description = ""), Column(TypeName = "datetime")]
        public DateTime? dataExclusao { get; set; }

        public CidadeEntity DadosCidade { get; set; }

        [NotMapped]
        public string enderecoCompleto
        {
            get { return $"{end_logradouro} {end_nomeRua} {end_numero},{end_cidade} - {end_uf}"; }
        }
    }
}
