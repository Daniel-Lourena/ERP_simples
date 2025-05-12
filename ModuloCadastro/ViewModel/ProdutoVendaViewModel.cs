using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Qtde.", Description = ""), DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal quantidade { get; set; }
        [Display(Name = "Valor", Description = ""), DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal valor { get; set; }
    }
}
