using ModuloCadastro.Enum;
using ModuloCadastro.ViewModel;
using SistemaERP.Cadastros.Extensions;
using SistemaERP.Generico;

namespace SistemaERP.Vendas
{
    public partial class formDetalhesVenda : Form
    {
        private int _idPedido = 0;
        public formDetalhesVenda()
        {
            InitializeComponent();
        }
        public formDetalhesVenda(int idPedido) : this()
        {
            _idPedido = idPedido;
        }
        private void CarregarProdutos()
        {
            dgvProdutos.CriarColunasDataGridView<ProdutoVendaViewModel>
                (
                    new ModuloCadastro.Service.ProdutoVendaService().GetListProdutosPedido(_idPedido),
                    new()
                    {
                        (nameof(ProdutoVendaViewModel.idProduto),true,true),(nameof(ProdutoVendaViewModel.descricaoProduto),true, true),
                        (nameof(ProdutoVendaViewModel.descricaoProduto), true,true),(nameof(ProdutoVendaViewModel.quantidade), false,true),
                        (nameof(ProdutoVendaViewModel.valor), false,true),(nameof(ProdutoVendaViewModel.id), false,false)
                    }
                );
        }

        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            new formAdicionarProdutosPedido(ETipoPedido.VENDA, _idPedido).ShowDialog();
        }

        private void btnRemProduto_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow == null) return;

            if (MessageBox.Show($"Deseja excluir o item {dgvProdutos.CurrentRow.Cells[nameof(ProdutoVendaViewModel.idProduto)].Value} - {dgvProdutos.CurrentRow.Cells[nameof(ProdutoVendaViewModel.descricaoProduto)].Value} do pedido?", String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            new ModuloCadastro.Service.ProdutoVendaService().Delete(Convert.ToInt32(dgvProdutos.CurrentRow.Cells[nameof(ProdutoVendaViewModel.id)].Value));
        }

        private void formDetalhesVenda_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }
    }
}
