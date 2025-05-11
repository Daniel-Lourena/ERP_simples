using System.ComponentModel.DataAnnotations;

namespace ModuloCadastro.ViewModel
{
    public class EstoqueViewModel
    {
        [Display(Name = "ID Produto", Description = "")]
        public int idProduto { get; set; }
        [Display(Name = "Descrição", Description = "")]
        public string descricaoProduto { get; set; }
        [Display(Name = "Estoque", Description = "")]
        public decimal quantidadeEstoque { get; set; } 
        [Display(Name = "Qtd. Venda", Description = "")]
        public decimal quantidadePedidoVenda { get; set; }
        [Display(Name = "Saldo", Description = "")]
        public decimal quantidadeEstoqueSaldoDisponivel => quantidadeEstoque - quantidadePedidoVenda;
        [Display(Name = "Setor Estoque", Description = "")]
        public string descricaoSetorEstoque { get; set; }
    }
}
