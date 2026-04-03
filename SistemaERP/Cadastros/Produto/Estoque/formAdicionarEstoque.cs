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
using SistemaERP.Extensions;

namespace SistemaERP.Cadastros.Produto.Estoque
{
    public partial class formAdicionarEstoque : Form
    {
        private readonly ProdutoService _produtoService;
        private readonly SetorEstoqueService _setorEstoqueService;
        private readonly EstoqueService _estoqueService;

        public formAdicionarEstoque(ProdutoService produtoService, SetorEstoqueService setorEstoqueService, EstoqueService estoqueService)
        {
            _produtoService = produtoService;
            _setorEstoqueService = setorEstoqueService;
            _estoqueService = estoqueService;

            InitializeComponent();
            CarregaProdutos();
            CarregaSetorEstoque();
        }

        private void CarregaProdutos()
        {
            cbProdutos.PreencherComboBoxList(
                _produtoService.GetList().Where(x => !x.Inativo)
                    .Select(y => new ProdutoEntity { Id = y.Id, CodigoEstoque_SKU = y.CodigoEstoque_SKU }).ToList(),
                nameof(ProdutoEntity.Id), nameof(ProdutoEntity.CodigoEstoque_SKU));
        }

        private void CarregaSetorEstoque()
        {
            cbSetores.PreencherComboBoxList(
                _setorEstoqueService.GetList(), nameof(SetorEstoqueEntity.Id), nameof(SetorEstoqueEntity.Descricao));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (nudQtd.Value <= 0)
            {
                MessageBox.Show($"Quantidade inválida.", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Deseja incluir estoque para o item {cbProdutos.Text} - {cbSetores.Text} (Qtd: {nudQtd.Value}) ?", "Sistema ERP",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _estoqueService.Insert(new EstoqueEntity
            {
                ProdutoId = Convert.ToInt32(cbProdutos.SelectedValue),
                SetorEstoqueId = Convert.ToInt32(cbSetores.SelectedValue),
                Quantidade = nudQtd.Value
            });

            MessageBox.Show($"Inclusão realizada com sucesso", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
