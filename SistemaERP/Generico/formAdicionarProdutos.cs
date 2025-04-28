using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using ModuloCadastro.ViewModel;
using SistemaERP.Cadastros.Extensions;
using SistemaERP.Cadastros.Produto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP.Generico
{
    public partial class formAdicionarProdutosPedido : Form
    {
        private ETipoPedido _tipoPedido;
        private int _idPedido = 0;
        public formAdicionarProdutosPedido(ETipoPedido tipoPedido, int idPedido)
        {
            _tipoPedido = tipoPedido;
            _idPedido = idPedido;
            InitializeComponent();
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            var listaEstoque = new EstoqueContext().GetListEstoqueDisponivel();
            dgvProdutos.CriarColunasDataGridView<EstoqueViewModel>
                (
                    listaEstoque,
                    new List<(string nomeColuna, bool readOnly)>()
                    {
                        (nameof(EstoqueViewModel.idProduto),true),
                        (nameof(EstoqueViewModel.descricaoProduto),true),
                        (nameof(EstoqueViewModel.descricaoSetorEstoque),true),
                        (nameof(EstoqueViewModel.quantidadePedidoVenda),true),
                        (nameof(EstoqueViewModel.quantidadeEstoqueSaldoDisponivel),true)
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
                    new ProdutoVendaContext().Insert
                        (
                            new ProdutoVendaEntity()
                            {
                                idProduto = Convert.ToInt32(dgvProdutos.CurrentRow.Cells[nameof(EstoqueViewModel.idProduto)].Value),
                                idPedido = _idPedido,
                                quantidade = nudQtd.Value
                            }
                        );
                    break;
                case ETipoPedido.COMPRA:
                    break;
            }
        }

        private void dgvProdutos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvProdutos.Rows.Count == 0) return;

            panelProduto.Visible = true;
            nudQtd.Value = 0;

            if (dgvProdutos.CurrentRow != null)
            {
                lblProduto.Text = dgvProdutos.CurrentRow.Cells[nameof(EstoqueViewModel.idProduto)].Value.ToString();
                txtEstoque.Text = dgvProdutos.CurrentRow.Cells[nameof(EstoqueViewModel.quantidadeEstoque)].Value.ToString();
                txtPedido.Text = dgvProdutos.CurrentRow.Cells[nameof(EstoqueViewModel.quantidadePedidoVenda)].Value.ToString();
                txtSaldo.Text = dgvProdutos.CurrentRow.Cells[nameof(EstoqueViewModel.quantidadeEstoqueSaldoDisponivel)].Value.ToString();
            }
        }

        private void formAdicionarProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                panelProduto.Visible = false;
            }
        }
    }
}
