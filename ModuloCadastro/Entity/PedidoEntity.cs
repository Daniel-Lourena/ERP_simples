using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_pedidos")]
    public class PedidoEntity:BaseEntity<PedidoEntity>
    {
        public int id { get; set; }
        public int idCliente { get; set; }
        public int idCriador { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime dataAtualizacao { get; set; }
        public int usuarioAtualizacao { get; set; }
        public bool excluido { get; set; }
        public DateTime? dataExclusao { get; set; }

        public ClienteEntity DadosCliente { get; set; }
        public List<ProdutoPedidoEntity> listaProdutosPedido { get; set; }
    }
}
