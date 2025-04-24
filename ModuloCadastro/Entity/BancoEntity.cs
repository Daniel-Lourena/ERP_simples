using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloCadastro.Enum;

namespace ModuloCadastro.Entity
{
    [Table("tb_bancos")]
    public class BancoEntity : BaseEntity<BancoEntity>
    {
        [Key, Display(Name = "ID", Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Display(Name = "Nome", Description = ""), Column(TypeName = "varchar(100)")]
        public string nome { get; set; }
        [Display(Name = "Código", Description = ""), Column(TypeName = "varchar(5)")]
        public string codigo { get; set; }
        [Display(Name = "N° Agência", Description = ""), Column(TypeName = "varchar(5)")]
        public string agencia { get; set; }       
        [Display(Name = "Dígito agência", Description = ""), Column(TypeName = "varchar(1)")]
        public string agenciaDigito { get; set; } 
        [Display(Name = "N° Conta", Description = ""), Column(TypeName = "varchar(5)")]
        public string conta { get; set; }         
        [Display(Name = "Dígito conta", Description = ""), Column(TypeName = "varchar(1)")]
        public string contaDigito { get; set; }   
        [Display(Name = "Tipo", Description = ""), Column(TypeName = "int")]
        public int tipoConta { get; set; }
        [Display(Name = "Nome titular", Description = ""), Column(TypeName = "varchar(100)")]
        public string titularNome { get; set; }
        [Display(Name = "Documento titular", Description = ""), Column(TypeName = "varchar(14)")]
        public string titularDocumento { get; set; } 
        [Display(Name = "Chave pix", Description = ""), Column(TypeName = "varchar(100)")]
        public string? pixChave { get; set; }           
        [Display(Name = "Tipo pix", Description = ""), Column(TypeName = "int")]
        public int pixTipoChave { get; set; }       
        [Display(Name = "Internacional", Description = ""), Column(TypeName = "tinyint(1)")]
        public bool contaInternacional { get; set; }
        [Display(Name = "Ativo", Description = ""), Column(TypeName = "tinyint(1)")]
        public bool inativo { get; set; } = true;
        [Display(Name = "Cadastro", Description = ""), Column(TypeName = "datetime")]
        public DateTime dataCadastro { get; set; }
        [Display(Name = "Atualização", Description = ""), Column(TypeName = "datetime")]
        public DateTime dataAtualizacao { get; set; }

        [Display(Name = "IBAN", Description = ""), Column(TypeName = "varchar(50)")]
        public string iban { get; set; } // Se for conta no exterior
        [Display(Name = "SWIFT/BIC", Description = ""), Column(TypeName = "varchar(15)")]
        public string swiftCode { get; set; } // SWIFT/BIC
    }
}
