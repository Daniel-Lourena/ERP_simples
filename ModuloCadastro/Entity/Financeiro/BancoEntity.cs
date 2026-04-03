using ModuloCadastro.Enum;
using ModuloCadastro.ViewModel.Financeiro;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloCadastro.Entity.Financeiro
{
    [Table("tb_bancos")]
    public class BancoEntity : BaseEntity<BancoEntity>
    {
        [Key, Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string Codigo { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string Agencia { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string AgenciaDigito { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string Conta { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string ContaDigito { get; set; }
        [Column(TypeName = "int")]
        public ETipoContaBanco TipoConta { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string TitularNome { get; set; }
        [Column(TypeName = "varchar(14)")]
        public string TitularDocumento { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string PixChave { get; set; }
        [Column(TypeName = "int")]
        public ETipoChavePix PixTipoChave { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public bool ContaInternacional { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public bool Inativo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataAtualizacao { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Iban { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string? SwiftCode { get; set; }

        public BancoViewModel ToViewModel()
        {
            return new BancoViewModel
            {
                id = this.Id,
                nome = this.Nome,
                codigo = this.Codigo,
                agencia = this.Agencia,
                agenciaDigito = this.AgenciaDigito,
                conta = this.Conta,
                contaDigito = this.ContaDigito,
                tipoConta = this.TipoConta,
                titularNome = this.TitularNome,
                titularDocumento = this.TitularDocumento,
                pixChave = this.PixChave,
                pixTipoChave = this.PixTipoChave,
                contaInternacional = this.ContaInternacional,
                inativo = this.Inativo,
                dataCadastro = this.DataCadastro,
                dataAtualizacao = this.DataAtualizacao,
                iban = this.Iban,
                swiftCode = this.SwiftCode
            };
        }
    }
}
