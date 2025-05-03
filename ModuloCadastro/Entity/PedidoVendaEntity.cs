using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_vendas")]
    public class PedidoVendaEntity:BaseEntity<PedidoVendaEntity>
    {
        [Key,Display(Name = "id",Description = ""),Column(TypeName = "int"),DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Display(Name = "idCliente",Description = ""),Column(TypeName = "int")]
        public int idCliente { get; set; }
        [Display(Name = "idCriador", Description = ""),Column(TypeName = "int")]
        public int idCriador { get; set; }
        [Display(Name = "dataCriacao", Description = ""),Column(TypeName = "datetime")]
        public DateTime dataCriacao { get; set; }
        [Display(Name = "dataAtualizacao", Description = ""),Column(TypeName = "datetime")]
        public DateTime dataAtualizacao { get; set; }
        [Display(Name = "usuarioAtualizacao", Description = ""),Column(TypeName = "int")]
        public int usuarioAtualizacao { get; set; }
        [Display(Name = "excluido", Description = ""),Column(TypeName = "tinyint(1)")]
        public bool excluido { get; set; }
        [Display(Name = "dataExclusao", Description = ""),Column(TypeName = "datetime")]
        public DateTime? dataExclusao { get; set; }
        [Display(Name = "usuarioFechamento", Description = ""),Column(TypeName = "int")]
        public int usuarioFechamento { get; set; }
        [Display(Name = "dataFechamento", Description = ""),Column(TypeName = "datetime")]
        public DateTime? dataFechamento { get; set; }

        public ClienteEntity DadosCliente { get; set; }
        public UsuarioEntity DadosUsuarioCriador { get; set; }
        public UsuarioEntity DadosUsuarioAtualizacao { get; set; }
        public UsuarioEntity? DadosUsuarioFechamento { get; set; }
        public List<ProdutoVendaEntity> listaProdutosVenda { get; set; }
    }
}
