using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_produtospedido")]
    public class ProdutoPedidoEntity : BaseEntity<ProdutoPedidoEntity>
    {
        public int id { get; set; }
        public int idPedido { get; set; }
        public int idProduto { get; set; }
        public ProdutoEntity DadosProduto { get; set; }
    }
}
