using System.ComponentModel.DataAnnotations;

namespace ModuloCadastro.ViewModel.Cadastro.Produto
{
    public class EstoqueViewModel
    {
        [Display(Name = "ID Produto", Description = "")]
        public int IdProduto { get; set; }
        [Display(Name = "Código SKU", Description = "")]
        public string Codigo_SKU { get; set; }
        [Display(Name = "Descrição", Description = "")]
        public string DescricaoProduto { get; set; }
        [Display(Name = "Estoque", Description = "")]
        public decimal QuantidadeEstoque { get; set; } 
        [Display(Name = "Qtd. Venda", Description = "")]
        public decimal QuantidadePedidoVenda { get; set; }
        [Display(Name = "Saldo", Description = "")]
        public decimal QuantidadeEstoqueSaldoDisponivel => QuantidadeEstoque - QuantidadePedidoVenda;
        [Display(Name = "Setor Estoque", Description = "")]
        public string DescricaoSetorEstoque { get; set; }
        [Display(Name = "ID Setor Estoque", Description = "")]
        public int IdSetorEstoque { get; set; }
        [Display(Name = "Inativo", Description = "")]
        public bool inativo { get; set; }
    }
}
