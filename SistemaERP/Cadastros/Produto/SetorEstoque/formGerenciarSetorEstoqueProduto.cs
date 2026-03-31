using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
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
