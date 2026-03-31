using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using SistemaERP.Extensions;
using SistemaERP.Factory;
using System.Data;

namespace SistemaERP.Cadastros.Produto.Estoque
{
    public partial class formGerenciar : Form
    {
        private readonly IFormFactory _formFactory;
        private readonly EstoqueService _serviceEstoque;

        public formGerenciar(EstoqueService serviceEstoque)
        {
            _serviceEstoque = serviceEstoque;

            InitializeComponent();
            CarregaEstoque();
            this.ConfiguraTabIndex();
        }

        private void CarregaEstoque()
        {
            List<EstoqueViewModel> listaDataSource = _serviceEstoque
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
                _formFactory.Criar<formModificarEstoque>(produto, "+").ShowDialog();
                CarregaEstoque();
            }
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                EstoqueViewModel produto = dgvProdutos.CurrentRow.DataBoundItem as EstoqueViewModel;
                _formFactory.Criar<formModificarEstoque>(produto, "-").ShowDialog();
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
            _formFactory.Criar<formAdicionarEstoque>().ShowDialog();
            CarregaEstoque();
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                EstoqueViewModel produto = dgvProdutos.CurrentRow.DataBoundItem as EstoqueViewModel;
                _formFactory.Criar<formTransferenciaEstoque>(produto).ShowDialog();
                CarregaEstoque();
            }
        }
    }
}
