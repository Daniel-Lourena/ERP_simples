using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using MySqlConnector;
using SistemaERP.Cadastros.Extensions;
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
    public partial class formTransferenciaEstoque : Form
    {
        private EstoqueViewModel _produtoTransferir;
        public formTransferenciaEstoque(EstoqueViewModel produtoEstoque)
        {
            InitializeComponent();
            _produtoTransferir = produtoEstoque;
            txtProduto.Text = _produtoTransferir.DescricaoProduto;
            txtSetorOrigem.Text = _produtoTransferir.DescricaoSetorEstoque;
            txtSaldo.Text = _produtoTransferir.QuantidadeEstoqueSaldoDisponivel.ToString();
            CarregaSetorEstoque();
        }


        private void CarregaSetorEstoque()
        {
            cbSetorDestino.PreencherComboBoxList(
                new SetorEstoqueService().GetList().Where(x => x.Id != _produtoTransferir.IdSetorEstoque).ToList(), nameof(SetorEstoqueEntity.Id), nameof(SetorEstoqueEntity.Descricao));
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            if (nudQtd.Value == 0)
            {
                MessageBox.Show($"Quantidade a transferir não pode ser zerada", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Deseja transferir estoque para o item {txtProduto.Text} - {cbSetorDestino.Text} (Qtd: {nudQtd.Value}) ?", "Sistema ERP",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var produtoEnviado = new EstoqueService().Get(_produtoTransferir.IdProduto, _produtoTransferir.IdSetorEstoque);
            var produtoRecebido = new EstoqueService().Get(_produtoTransferir.IdProduto, Convert.ToInt32(cbSetorDestino.SelectedValue));

            if (nudQtd.Value > produtoEnviado.QuantidadeEstoqueSaldoDisponivel)
            {
                MessageBox.Show($"Quantidade a transferir não pode ser maior que saldo disponível", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((produtoEnviado.QuantidadeEstoque - nudQtd.Value) == 0)
            {
                new EstoqueService().Delete(new ModuloCadastro.Entity.EstoqueEntity
                {
                    ProdutoId = produtoEnviado.IdProduto,
                    SetorEstoqueId = produtoEnviado.IdSetorEstoque
                });
            }
            else
            {
                new EstoqueService().UpdateParcial(new ModuloCadastro.Entity.EstoqueEntity
                {
                    ProdutoId = produtoEnviado.IdProduto,
                    SetorEstoqueId = produtoEnviado.IdSetorEstoque,
                    Quantidade = produtoEnviado.QuantidadeEstoque - nudQtd.Value
                },
                new() { nameof(EstoqueEntity.Quantidade) });
            }


            if (produtoRecebido.IdProduto == 0)
            {
                new EstoqueService().Insert(new ModuloCadastro.Entity.EstoqueEntity
                {
                    ProdutoId = _produtoTransferir.IdProduto,
                    SetorEstoqueId = Convert.ToInt32(cbSetorDestino.SelectedValue),
                    Quantidade = nudQtd.Value
                });
            }
            else
            {
                new EstoqueService().UpdateParcial(new ModuloCadastro.Entity.EstoqueEntity
                {
                    ProdutoId = produtoRecebido.IdProduto,
                    SetorEstoqueId = produtoRecebido.IdSetorEstoque,
                    Quantidade = produtoRecebido.QuantidadeEstoque + nudQtd.Value
                },
                new() { nameof(EstoqueEntity.Quantidade) });
            }


            MessageBox.Show($"Transferência realizada com sucesso", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
