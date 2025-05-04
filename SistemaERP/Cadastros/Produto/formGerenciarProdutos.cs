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
            List<ProdutoViewModel> listaDataSource = new();
            if (ckeOcultaInativos.Checked)
            {
                listaDataSource = new ModuloCadastro.Service.ProdutoService(_db_context).GetList()
                .Where(x => !x.inativo)
                .Select(x => new ProdutoViewModel
                { id = x.id, descricao = x.descricao, DadosCategoria = x.DadosCategoria, idUnidade = x.idUnidade, inativo = x.inativo }).ToList();
            }
            else
            {
                listaDataSource = new ModuloCadastro.Service.ProdutoService(_db_context).GetList()
               .Select(x => new ProdutoViewModel
               { id = x.id, descricao = x.descricao, DadosCategoria = x.DadosCategoria, idUnidade = x.idUnidade, inativo = x.inativo }).ToList();
            }

            dgvProdutos.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(ProdutoViewModel.id), true,true), (nameof(ProdutoViewModel.descricao), true,true),
                (nameof(ProdutoViewModel.descricaoCategoria), true,true), (nameof(ProdutoViewModel.descricaoUnidade), true,true),
                (nameof(ProdutoViewModel.inativo), true,false)
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

        private void ckeOcultaInativos_CheckedChanged(object sender, EventArgs e)
        {
            CarregaProdutos();
        }

        private void dgvProdutos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            ProdutoViewModel row = dgvProdutos.Rows[e.RowIndex].DataBoundItem as ProdutoViewModel;

            if (row.inativo)
            {
                dgvProdutos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
            }
        }
    }
}
