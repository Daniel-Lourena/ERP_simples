using ModuloCadastro.ViewModel;
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
        [Key,Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string razaoSocial { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string fantasia { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal limiteCredito { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string end_nomeRua { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string end_bairro { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string end_numero { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string end_logradouro { get; set; }
        [Column(TypeName = "int")]
        public int end_uf { get; set; }
        [Column(TypeName = "int")]
        public int end_cidade { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dataCadastro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dataAtualizacao { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public bool excluido { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dataExclusao { get; set; }

        public CidadeEntity DadosCidade { get; set; }

        public ClienteViewModel ToViewModel()
        {
            return new ClienteViewModel
            {
                id = this.id,
                razaoSocial = this.razaoSocial,
                fantasia = this.fantasia,
                limiteCredito = this.limiteCredito,
                end_nomeRua = this.end_nomeRua,
                end_bairro = this.end_bairro,
                end_numero = this.end_numero,
                end_logradouro = this.end_logradouro,
                end_uf = this.end_uf,
                end_cidade = this.end_cidade,
                dataCadastro = this.dataCadastro,
                dataAtualizacao = this.dataAtualizacao,
                excluido = this.excluido,
                dataExclusao = this.dataExclusao,
                DadosCidade = this.DadosCidade
            };
        }
    }
}
