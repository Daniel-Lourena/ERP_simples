using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ModuloCadastro.Enum;
using ModuloCadastro.ViewModel;

namespace ModuloCadastro.Entity
{
    [Table("tb_bancos")]
    public class BancoEntity : BaseEntity<BancoEntity>
    {
        [Key, Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string nome { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string codigo { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string agencia { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string agenciaDigito { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string conta { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string contaDigito { get; set; }
        [Column(TypeName = "int")]
        public ETipoContaBanco tipoConta { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string titularNome { get; set; }
        [Column(TypeName = "varchar(14)")]
        public string titularDocumento { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string pixChave { get; set; }
        [Column(TypeName = "int")]
        public ETipoChavePix pixTipoChave { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public bool contaInternacional { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public bool  inativo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime dataCadastro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime dataAtualizacao { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string iban { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string swiftCode { get; set; }

        public BancoViewModel ToViewModel()
        {
            return new BancoViewModel
            {
                id = this.id,
                nome = this.nome,
                codigo = this.codigo,
                agencia = this.agencia,
                agenciaDigito = this.agenciaDigito,
                conta = this.conta,
                contaDigito = this.contaDigito,
                tipoConta = this.tipoConta,
                titularNome = this.titularNome,
                titularDocumento = this.titularDocumento,
                pixChave = this.pixChave,
                pixTipoChave = this.pixTipoChave,
                contaInternacional = this.contaInternacional,
                inativo = this.inativo,
                dataCadastro = this.dataCadastro,
                dataAtualizacao = this.dataAtualizacao,
                iban = this.iban,
                swiftCode = this.swiftCode
            };
        }
    }
}
