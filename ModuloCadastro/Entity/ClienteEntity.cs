using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_cliente")]
    public class ClienteEntity : BaseEntity<ClienteEntity>
    {
        [Key, Display(Name = "ID", Description = "")]
        public int id { get; set; }
        [Display(Name = "Razão Social", Description = "")]
        public string razaoSocial { get; set; }
        [Display(Name = "Fantasia", Description = "")]
        public string fantasia { get; set; }
        [Display(Name = "Limite Crédito", Description = "")]
        public decimal limiteCredito { get; set; }
        [Display(Name = "Rua", Description = "")]
        public string end_nomeRua { get; set; }
        [Display(Name = "Bairro", Description = "")]
        public string end_bairro { get; set; }
        [Display(Name = "N°", Description = "")]
        public string end_numero { get; set; }
        [Display(Name = "Logradouro", Description = "")]
        public string end_logradouro { get; set; }
        [Display(Name = "UF", Description = "")]
        public string end_uf { get; set; }
        [Display(Name = "ID Cidade", Description = "")]
        public string end_cidade { get; set; }
        [Display(Name = "Dta. Cadastro", Description = "")]
        public DateTime dataCadastro { get; set; }
        [Display(Name = "Dta. Atualização", Description = "")]
        public DateTime dataAtualizacao { get; set; }
        [Display(Name = "Excluído", Description = "")]
        public bool excluido { get; set; }
        [Display(Name = "Dta. Exclusão", Description = "")]
        public DateTime dataExclusao { get; set; }

        [NotMapped]
        public string enderecoCompleto
        {
            get { return $"{end_logradouro} {end_nomeRua} {end_numero},{end_cidade} - {end_uf}"; }
        }
    }
}
