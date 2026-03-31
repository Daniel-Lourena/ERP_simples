using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
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

            _estoqueService.Insert(new ModuloCadastro.Entity.EstoqueEntity
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
