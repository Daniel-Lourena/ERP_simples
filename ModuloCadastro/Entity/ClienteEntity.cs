using ModuloCadastro.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloCadastro.Entity
{
    [Table("tb_clientes")]
    public class ClienteEntity : BaseEntity<ClienteEntity>
    {
        [Key, Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string RazaoSocial { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Fantasia { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal LimiteCredito { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string End_nomeRua { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string End_bairro { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string End_numero { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string End_logradouro { get; set; }
        [Column(TypeName = "int")]
        public int EstadoId { get; set; }
        [Column(TypeName = "int")]
        public int CidadeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCadastro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public bool Excluido { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }

        public CidadeEntity Cidade { get; set; }

        public ClienteViewModel ToViewModel()
        {
            return new ClienteViewModel
            {
                id = this.Id,
                razaoSocial = this.RazaoSocial,
                fantasia = this.Fantasia,
                limiteCredito = this.LimiteCredito,
                end_nomeRua = this.End_nomeRua,
                end_bairro = this.End_bairro,
                end_numero = this.End_numero,
                end_logradouro = this.End_logradouro,
                end_uf = this.EstadoId,
                end_cidade = this.CidadeId,
                dataCadastro = this.DataCadastro,
                dataAtualizacao = this.DataAtualizacao,
                excluido = this.Excluido,
                dataExclusao = this.DataExclusao,
                DadosCidade = this.Cidade
            };
        }
    }
}
