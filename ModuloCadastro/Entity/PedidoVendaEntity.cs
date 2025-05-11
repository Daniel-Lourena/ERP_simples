using ModuloCadastro.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloCadastro.Entity
{
    [Table("tb_vendas")]
    public class PedidoVendaEntity : BaseEntity<PedidoVendaEntity>
    {
        [Key, Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Column(TypeName = "int")]
        public int ClienteId { get; set; }
        [Column(TypeName = "int")]
        public int UsuarioCriacaoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column(TypeName = "int")]
        public int UsuarioAtualizacaoId { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public bool Excluido { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
        [Column(TypeName = "int")]
        public int? UsuarioFechamentoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataFechamento { get; set; }

        public ClienteEntity Cliente { get; set; }
        public UsuarioEntity UsuarioCriacao { get; set; }
        public UsuarioEntity UsuarioAtualizacao { get; set; }
        public UsuarioEntity? UsuarioFechamento { get; set; }
        public List<ProdutoVendaEntity> ListaProdutosVenda { get; set; }

        public PedidoVendaViewModel ToViewModel()
        {
            return new PedidoVendaViewModel
            {
                id = this.Id,
                idCliente = this.ClienteId,
                idCriador = this.UsuarioCriacaoId,
                dataCriacao = this.DataCriacao, 
                dataAtualizacao = this.DataAtualizacao,
            };
        }
    }
}
