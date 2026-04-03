using ModuloCadastro.Entity;
using ModuloCadastro.Entity.Financeiro;
using ModuloCadastro.Entity.Cadastro.Produto;
using ModuloCadastro.Entity.Cadastro.Cliente;
using ModuloCadastro.Entity.Cadastro.Localizacao;
using ModuloCadastro.Entity.Cadastro.Usuario;
using ModuloCadastro.Entity.Venda;
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
                _estoqueService.Delete(new EstoqueEntity
                {
                    ProdutoId = produtoEnviado.IdProduto,
                    SetorEstoqueId = produtoEnviado.IdSetorEstoque
                });
            }
            else
            {
                _estoqueService.UpdateParcial(new EstoqueEntity
                {
                    ProdutoId = produtoEnviado.IdProduto,
                    SetorEstoqueId = produtoEnviado.IdSetorEstoque,
                    Quantidade = produtoEnviado.QuantidadeEstoque - nudQtd.Value
                },
                new() { nameof(EstoqueEntity.Quantidade) });
            }

            if (produtoRecebido.IdProduto == 0)
            {
                _estoqueService.Insert(new EstoqueEntity
                {
                    ProdutoId = _produtoTransferir.IdProduto,
                    SetorEstoqueId = Convert.ToInt32(cbSetorDestino.SelectedValue),
                    Quantidade = nudQtd.Value
                });
            }
            else
            {
                _estoqueService.UpdateParcial(new EstoqueEntity
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
