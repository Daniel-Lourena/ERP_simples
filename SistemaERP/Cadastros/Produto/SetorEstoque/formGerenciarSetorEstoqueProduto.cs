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
using System.Data;

namespace SistemaERP.Cadastros.Produto.SetorEstoque
{
    public partial class formGerenciarSetorEstoqueProduto : Form
    {
        private readonly SetorEstoqueService _service;

        public formGerenciarSetorEstoqueProduto(SetorEstoqueService service)
        {
            _service = service;
            InitializeComponent();
            CarregaSetores();
            this.ConfiguraTabIndex();
        }

        private void CarregaSetores()
        {
            List<SetorEstoqueEntity> _listaDataSource = _service.GetList()
            .Select(x => new SetorEstoqueEntity
            {
                Id = x.Id,
                Descricao = x.Descricao
            }).ToList();

            dgvSetorEstoque.CriarColunasDataGridView(_listaDataSource, new()
            {
                (nameof(SetorEstoqueEntity.Id), true,false), (nameof(SetorEstoqueEntity.Descricao), false,true)
            });
        }

        private void dgvSetorEstoque_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SetorEstoqueEntity row = dgvSetorEstoque.Rows[e.RowIndex].DataBoundItem as SetorEstoqueEntity;

            if (row.Id == 0)
            {
                _service.Insert(row);
            }
            else
            {
                _service.Update(row);
            }
            CarregaSetores();
        }
    }
}
