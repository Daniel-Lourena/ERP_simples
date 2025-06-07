using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;
using SistemaERP.Extensions;
using System.Data;

namespace SistemaERP.Cadastros.Produto.Estoque
{
    public partial class formGerenciar : Form
    {
        public formGerenciar()
        {
            InitializeComponent();
            CarregaEstoque();
            this.ConfiguraTabIndex();
        }

        private void CarregaEstoque()
        {
            List<EstoqueViewModel> listaDataSource = new();

            listaDataSource = new ModuloCadastro.Service.EstoqueService()
                .GetListEstoquePosicaoItem().Where(x => !x.inativo).ToList();

            dgvProdutos.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(EstoqueViewModel.IdProduto), true,true), (nameof(EstoqueViewModel.Codigo_SKU), true,true), (nameof(EstoqueViewModel.DescricaoProduto), true,true),
                (nameof(EstoqueViewModel.DescricaoSetorEstoque), true,true),(nameof(EstoqueViewModel.QuantidadeEstoque), true,true),
                (nameof(EstoqueViewModel.QuantidadePedidoVenda), true,true),(nameof(EstoqueViewModel.QuantidadeEstoqueSaldoDisponivel), true,true)
            });
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                EstoqueViewModel produto = dgvProdutos.CurrentRow.DataBoundItem as EstoqueViewModel;
                new formModificarEstoque(produto, "+").ShowDialog();
                CarregaEstoque();
            }
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                EstoqueViewModel produto = dgvProdutos.CurrentRow.DataBoundItem as EstoqueViewModel;
                new formModificarEstoque(produto, "-").ShowDialog();
                CarregaEstoque();
            }
        }


        private void dgvProdutos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //ProdutoViewModel row = dgvProdutos.Rows[e.RowIndex].DataBoundItem as ProdutoViewModel;

            //if (row.inativo)
            //{
            //    dgvProdutos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
            //}
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            new formAdicionarEstoque().ShowDialog();
            CarregaEstoque();
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                EstoqueViewModel produto = dgvProdutos.CurrentRow.DataBoundItem as EstoqueViewModel;
                new formTransferenciaEstoque(produto).ShowDialog();
                CarregaEstoque();
            }
        }
    }
}
