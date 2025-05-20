using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP.Cadastros.Produto.Estoque
{
    public partial class formModificarEstoque : Form
    {
        private EstoqueViewModel _produto;
        private string _funcao;

        public formModificarEstoque(EstoqueViewModel produto, string funcao)
        {
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

            var produtoEstoque = new EstoqueService()
                .Get(_produto.IdProduto, _produto.IdSetorEstoque);

            if (_funcao == "+")
            {
                new EstoqueService().UpdateParcial(new ModuloCadastro.Entity.EstoqueEntity
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
                    new EstoqueService().Delete(new ModuloCadastro.Entity.EstoqueEntity
                    {
                        ProdutoId = produtoEstoque.IdProduto,
                        SetorEstoqueId = produtoEstoque.IdSetorEstoque,
                    });
                }
                else
                {
                    new EstoqueService().UpdateParcial(new ModuloCadastro.Entity.EstoqueEntity
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
