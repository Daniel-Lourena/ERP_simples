using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;
using SistemaERP.Cadastros.Extensions;
using System.Data;

namespace SistemaERP.Cadastros.Produto
{
    public partial class formGerenciarProdutos : Form
    {
        private ModuloCadastro.Context.ModuloCadastroContext _db_context;

        public formGerenciarProdutos(ModuloCadastroContext db_context)
        {
            _db_context = db_context;
            InitializeComponent();
            CarregaProdutos();
        }

        private void CarregaProdutos()
        {
            var listaDataSource = new ModuloCadastro.Service.ProdutoService(_db_context).GetList()
                .Select(x => new ProdutoViewModel
                { id = x.id, descricao = x.descricao, DadosCategoria = x.DadosCategoria, idUnidade = x.idUnidade }).ToList();
            dgvProdutos.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(ProdutoViewModel.id), true,true), (nameof(ProdutoViewModel.descricao), true,true),
                (nameof(ProdutoViewModel.descricaoCategoria), true,true), (nameof(ProdutoViewModel.descricaoUnidade), true,true)
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesProduto().ShowDialog();
            CarregaProdutos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                new formDetalhesProduto(Convert.ToInt32(dgvProdutos.CurrentRow.Cells[nameof(ProdutoViewModel.id)].Value)).ShowDialog();
                CarregaProdutos();
            }
        }
    }
}
