using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.ViewModel
{
    public class ProdutoVendaViewModel
    {
        [Key, Display(Name = "ID", Description = "")]
        public int id { get; set; }
        [Display(Name = "ID Pedido", Description = "")]
        public int idPedido { get; set; }
        [Display(Name = "ID Produto", Description = "")]
        public int idProduto { get; set; }
        [Display(Name = "Descrição", Description = "")]
        public string descricaoProduto { get; set; }
        [Display(Name = "Qtde.", Description = "")]
        public decimal quantidade { get; set; }
        [Display(Name = "Valor", Description = "")]
        public decimal valor { get; set; }
    }
}
