using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;
using SistemaERP.Cadastros.Extensions;
using System.Data;

namespace SistemaERP.Cadastros.Produto.Estoque
{
    public partial class formGerenciar : Form
    {
        private ModuloCadastro.Context.ModuloCadastroContext _db_context;

        public formGerenciar(ModuloCadastroContext db_context)
        {
            _db_context = db_context;
            InitializeComponent();
            CarregaEstoque();
            this.ConfiguraTabIndex();
        }

        private void CarregaEstoque()
        {
            List<EstoqueViewModel> listaDataSource = new();
            
            listaDataSource = new ModuloCadastro.Service.EstoqueService().GetListEstoqueDisponivel()
           .Select(x => new EstoqueViewModel
           { idProduto = x.idProduto,descricaoProduto = x.descricaoProduto }).ToList();

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
            CarregaEstoque();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                new formDetalhesProduto(Convert.ToInt32(dgvProdutos.CurrentRow.Cells[nameof(ProdutoViewModel.id)].Value)).ShowDialog();
                CarregaEstoque();
            }
        }

        private void ckeOcultaInativos_CheckedChanged(object sender, EventArgs e)
        {
            CarregaEstoque();
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
