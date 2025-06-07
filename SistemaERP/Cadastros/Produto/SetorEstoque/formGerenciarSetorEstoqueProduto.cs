using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;
using SistemaERP.Extensions;
using System.Data;

namespace SistemaERP.Cadastros.Produto.SetorEstoque
{
    public partial class formGerenciarSetorEstoqueProduto : Form
    {
        public formGerenciarSetorEstoqueProduto()
        {
            InitializeComponent();
            CarregaSetores();
            this.ConfiguraTabIndex();
        }

        private void CarregaSetores()
        {
            List<SetorEstoqueEntity> _listaDataSource = new ModuloCadastro.Service.SetorEstoqueService().GetList()
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
                new ModuloCadastro.Service.SetorEstoqueService().Insert(row);
            }
            else
            {
                new ModuloCadastro.Service.SetorEstoqueService().Update(row);
            }
            CarregaSetores();
        }
    }
}
