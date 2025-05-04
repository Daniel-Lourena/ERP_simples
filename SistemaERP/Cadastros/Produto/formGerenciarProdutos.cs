using ModuloCadastro.Context;
using ModuloCadastro.Entity;
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
            var listaDataSource = new ModuloCadastro.Service.ProdutoService(_db_context).GetList().Select(x => new ProdutoEntity { id = x.id, descricao = x.descricao, categoria = x.categoria, idUnidade = x.idUnidade }).ToList();
            dgvProdutos.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(ProdutoEntity.id), true,true), (nameof(ProdutoEntity.descricao), true,true),
                (nameof(ProdutoEntity.categoria), true,true), (nameof(ProdutoEntity.idUnidade), true,true)
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesProduto().ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                new formDetalhesProduto(Convert.ToInt32(dgvProdutos.CurrentRow.Cells[nameof(ProdutoEntity.id)].Value)).ShowDialog();
            }
        }
    }
}
