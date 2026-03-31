using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using MySqlConnector;
using SistemaERP.Extensions;

namespace SistemaERP.Cadastros.Produto.Estoque
{
    public partial class formTransferenciaEstoque : Form
    {
        private readonly EstoqueService _estoqueService;
        private readonly SetorEstoqueService _setorEstoqueService;
        private EstoqueViewModel _produtoTransferir;

        public formTransferenciaEstoque(EstoqueService estoqueService, SetorEstoqueService setorEstoqueService, EstoqueViewModel produtoEstoque)
        {
            _estoqueService = estoqueService;
            _setorEstoqueService = setorEstoqueService;

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
                _setorEstoqueService.GetList().Where(x => x.Id != _produtoTransferir.IdSetorEstoque).ToList(),
                nameof(SetorEstoqueEntity.Id), nameof(SetorEstoqueEntity.Descricao));
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            if (nudQtd.Value <= 0)
            {
                MessageBox.Show($"Quantidade inválida", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Deseja transferir estoque para o item {txtProduto.Text} - {cbSetorDestino.Text} (Qtd: {nudQtd.Value}) ?", "Sistema ERP",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var produtoEnviado = _estoqueService.Get(_produtoTransferir.IdProduto, _produtoTransferir.IdSetorEstoque);
            var produtoRecebido = _estoqueService.Get(_produtoTransferir.IdProduto, Convert.ToInt32(cbSetorDestino.SelectedValue));

            if (nudQtd.Value > produtoEnviado.QuantidadeEstoqueSaldoDisponivel)
            {
                MessageBox.Show($"Quantidade a transferir não pode ser maior que saldo disponível", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((produtoEnviado.QuantidadeEstoque - nudQtd.Value) == 0)
            {
                _estoqueService.Delete(new ModuloCadastro.Entity.EstoqueEntity
                {
                    ProdutoId = produtoEnviado.IdProduto,
                    SetorEstoqueId = produtoEnviado.IdSetorEstoque
                });
            }
            else
            {
                _estoqueService.UpdateParcial(new ModuloCadastro.Entity.EstoqueEntity
                {
                    ProdutoId = produtoEnviado.IdProduto,
                    SetorEstoqueId = produtoEnviado.IdSetorEstoque,
                    Quantidade = produtoEnviado.QuantidadeEstoque - nudQtd.Value
                },
                new() { nameof(EstoqueEntity.Quantidade) });
            }

            if (produtoRecebido.IdProduto == 0)
            {
                _estoqueService.Insert(new ModuloCadastro.Entity.EstoqueEntity
                {
                    ProdutoId = _produtoTransferir.IdProduto,
                    SetorEstoqueId = Convert.ToInt32(cbSetorDestino.SelectedValue),
                    Quantidade = nudQtd.Value
                });
            }
            else
            {
                _estoqueService.UpdateParcial(new ModuloCadastro.Entity.EstoqueEntity
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
