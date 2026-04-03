using ModuloCadastro.Entity;
using ModuloCadastro.Entity.Financeiro;
using ModuloCadastro.Entity.Cadastro.Produto;
using ModuloCadastro.Entity.Cadastro.Cliente;
using ModuloCadastro.Entity.Cadastro.Localizacao;
using ModuloCadastro.Entity.Cadastro.Usuario;
using ModuloCadastro.Entity.Venda;
using ModuloCadastro.Enum;
using ModuloCadastro.Service;
using ModuloCadastro.Service.Financeiro;
using ModuloCadastro.Service.Cadastro.Produto;
using ModuloCadastro.Service.Cadastro.Cliente;
using ModuloCadastro.Service.Cadastro.Localizacao;
using ModuloCadastro.Service.Cadastro.Usuario;
using ModuloCadastro.Service.Venda;
using ModuloCadastro.ViewModel;
using ModuloCadastro.ViewModel.Financeiro;
using ModuloCadastro.ViewModel.Cadastro.Produto;
using ModuloCadastro.ViewModel.Cadastro.Cliente;
using ModuloCadastro.ViewModel.Cadastro.Usuario;
using ModuloCadastro.ViewModel.Venda;
using SistemaERP.Extensions;

namespace SistemaERP.Generico
{
    public partial class formAdicionarProdutosPedido : Form
    {
        private ETipoPedido _tipoPedido;
        private int _idPedido = 0;
        private readonly EstoqueService _serviceEstoque;
        private readonly ProdutoVendaService _serviceProdutoVenda;
        public formAdicionarProdutosPedido(EstoqueService serviceEstoque, ProdutoVendaService serviceProdutoVenda,ETipoPedido tipoPedido, int idPedido)
        {
            _tipoPedido = tipoPedido;
            _idPedido = idPedido;
            _serviceEstoque = serviceEstoque;
            _serviceProdutoVenda = serviceProdutoVenda;
            InitializeComponent();
            CarregarProdutos();
            this.ConfiguraTabIndex();
        }

        private void CarregarProdutos()
        {
            var listaEstoque = _serviceEstoque.GetListEstoqueDisponivel();
            dgvProdutos.CriarColunasDataGridView<EstoqueViewModel>
                (
                    listaEstoque,
                    new()
                    {
                        (nameof(EstoqueViewModel.IdProduto),true,true),
                        (nameof(EstoqueViewModel.Codigo_SKU),true,true),
                        (nameof(EstoqueViewModel.DescricaoProduto),true,true),
                        (nameof(EstoqueViewModel.IdSetorEstoque),false,false),
                        (nameof(EstoqueViewModel.DescricaoSetorEstoque),true,true),
                        (nameof(EstoqueViewModel.QuantidadeEstoque),true,true),
                        (nameof(EstoqueViewModel.QuantidadePedidoVenda),true,true),
                        (nameof(EstoqueViewModel.QuantidadeEstoqueSaldoDisponivel),true,true)
                    }
                );
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (nudQtd.Value == 0)
            {
                MessageBox.Show("Insira uma quantidade válida", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (_tipoPedido)
            {
                case ETipoPedido.VENDA:
                    _serviceProdutoVenda.Insert
                        (
                            new ProdutoVendaEntity()
                            {
                                ProdutoId = Convert.ToInt32(dgvProdutos.CurrentRow.Cells[nameof(EstoqueViewModel.IdProduto)].Value),
                                PedidoVendaId = _idPedido,
                                Quantidade = nudQtd.Value,
                                SetorEstoqueId = Convert.ToInt32(dgvProdutos.CurrentRow.Cells[nameof(EstoqueViewModel.IdSetorEstoque)].Value)
                            }
                        );
                    break;
                case ETipoPedido.COMPRA:
                    break;
            }
            
            panelProduto.Visible = false;
            CarregarProdutos();
        }

        private void dgvProdutos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvProdutos.Rows.Count == 0) return;

            panelProduto.Visible = true;
            nudQtd.Value = 0;

            if (dgvProdutos.CurrentRow != null)
            {
                lblProduto.Text = dgvProdutos.CurrentRow.Cells[nameof(EstoqueViewModel.IdProduto)].Value.ToString();
                txtEstoque.Text = dgvProdutos.CurrentRow.Cells[nameof(EstoqueViewModel.QuantidadeEstoque)].Value.ToString();
                txtPedido.Text = dgvProdutos.CurrentRow.Cells[nameof(EstoqueViewModel.QuantidadePedidoVenda)].Value.ToString();
                txtSaldo.Text = dgvProdutos.CurrentRow.Cells[nameof(EstoqueViewModel.QuantidadeEstoqueSaldoDisponivel)].Value.ToString();
            }
        }

        private void formAdicionarProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                panelProduto.Visible = false;
                nudQtd.Value = 0;
            }
        }
    }
}
