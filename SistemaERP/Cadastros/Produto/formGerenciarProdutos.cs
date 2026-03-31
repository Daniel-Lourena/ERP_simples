using Microsoft.Extensions.DependencyInjection;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using SistemaERP.Extensions;
using SistemaERP.Factory;
using System.Data;

namespace SistemaERP.Cadastros.Produto
{
    public partial class formGerenciarProdutos : Form
    {
        private readonly IFormFactory _formFactory;
        private readonly ProdutoService _service;

        public formGerenciarProdutos(IFormFactory formFactory, ProdutoService service)
        {
            _formFactory = formFactory;
            _service = service;

            InitializeComponent();
            CarregaProdutos();
            this.ConfiguraTabIndex();
        }

        private void CarregaProdutos()
        {
            List<ProdutoViewModel> listaDataSource = new();
            if (ckeOcultaInativos.Checked)
            {
                listaDataSource = _service.GetList()
                .Where(x => !x.Inativo)
                .Select(x => new ProdutoViewModel
                { id = x.Id, descricao = x.Descricao, DadosCategoria = x.Categoria, idUnidade = x.UnidadeId, inativo = x.Inativo }).ToList();
            }
            else
            {
                listaDataSource = _service.GetList()
               .Select(x => new ProdutoViewModel
               { id = x.Id, descricao = x.Descricao, DadosCategoria = x.Categoria, idUnidade = x.UnidadeId, inativo = x.Inativo }).ToList();
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
            _formFactory.Criar<formDetalhesProduto>().ShowDialog();
            CarregaProdutos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                _formFactory.Criar<formDetalhesProduto>(Convert.ToInt32(dgvProdutos.CurrentRow.Cells[nameof(ProdutoViewModel.id)].Value)).ShowDialog();
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
