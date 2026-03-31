using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;

namespace SistemaERP.Cadastros.Produto.Estoque
{
    public partial class formModificarEstoque : Form
    {
        private readonly EstoqueService _serviceEstoque;
        private EstoqueViewModel _produto;
        private string _funcao;

        public formModificarEstoque(EstoqueService serviceEstoque,EstoqueViewModel produto, string funcao)
        {
            _serviceEstoque = serviceEstoque;
            InitializeComponent();
            _funcao = funcao;
            _produto = produto;
        }

        private void formModificarEstoque_Load(object sender, EventArgs e)
        {
            lblProduto.Text = _produto.Codigo_SKU.ToString();
            txtEstoque.Text = _produto.QuantidadeEstoque.ToString();
            txtPedido.Text = _produto.QuantidadePedidoVenda.ToString();
            txtSaldo.Text = _produto.QuantidadeEstoqueSaldoDisponivel.ToString();
            btnModificar.Text = _funcao == "+" ? "SOMAR" : "SUBTRAIR";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (nudQtd.Value <= 0)
            {
                MessageBox.Show($"Quantidade inválida.", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Deseja {btnModificar.Text} (Qtd: {nudQtd.Value}) no estoque do item ?", "Sistema ERP",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var produtoEstoque = _serviceEstoque.Get(_produto.IdProduto, _produto.IdSetorEstoque);

            if (_funcao == "+")
            {
                _serviceEstoque.UpdateParcial(new ModuloCadastro.Entity.EstoqueEntity
                {
                    ProdutoId = produtoEstoque.IdProduto,
                    SetorEstoqueId = produtoEstoque.IdSetorEstoque,
                    Quantidade = produtoEstoque.QuantidadeEstoque + nudQtd.Value
                },
                new() { nameof(EstoqueEntity.Quantidade) });
            }
            else if (_funcao == "-")
            {
                if ((produtoEstoque.QuantidadeEstoque - nudQtd.Value) == 0)
                {
                    _serviceEstoque.Delete(new ModuloCadastro.Entity.EstoqueEntity
                    {
                        ProdutoId = produtoEstoque.IdProduto,
                        SetorEstoqueId = produtoEstoque.IdSetorEstoque,
                    });
                }
                else
                {
                    _serviceEstoque.UpdateParcial(new ModuloCadastro.Entity.EstoqueEntity
                    {
                        ProdutoId = produtoEstoque.IdProduto,
                        SetorEstoqueId = produtoEstoque.IdSetorEstoque,
                        Quantidade = produtoEstoque.QuantidadeEstoque - nudQtd.Value
                    },
                    new() { nameof(EstoqueEntity.Quantidade) });
                }
            }

            this.Close();
        }
    }
}
