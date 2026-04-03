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
using SistemaERP.Factory;
using System.Data;

namespace SistemaERP.Cadastros.Produto.Categoria
{
    public partial class formGerenciarCategoriasProduto : Form
    {
        private readonly CategoriaService _serviceCategoria;

        public formGerenciarCategoriasProduto(CategoriaService serviceCategoria)
        {
            _serviceCategoria = serviceCategoria;
            InitializeComponent();
            CarregaCategorias();
            this.ConfiguraTabIndex();
        }

        private void CarregaCategorias()
        {
            List<CategoriaViewModel> _listaDataSource = new List<CategoriaViewModel>(_serviceCategoria.GetList()
            .Select(x => new CategoriaViewModel
            {
                id = x.Id,
                descricao = x.Descricao
            }).ToList());

            dgvCategorias.CriarColunasDataGridView(_listaDataSource, new()
            {
                (nameof(CategoriaViewModel.id), true,false), (nameof(CategoriaViewModel.descricao), false,true)
            });
        }

        private void dgvCategorias_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CategoriaViewModel row = dgvCategorias.Rows[e.RowIndex].DataBoundItem as CategoriaViewModel;

            if (row.id == 0)
            {
                _serviceCategoria.Insert(row.ToEntity());
            }
            else
            {
                _serviceCategoria.Update(row.ToEntity());
            }
            CarregaCategorias();
        }
    }
}
