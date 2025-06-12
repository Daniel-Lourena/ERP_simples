using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;
using SistemaERP.Extensions;
using System.Data;

namespace SistemaERP.Cadastros.Maquininha
{
    public partial class formGerenciarMaquininhas : Form
    {
        public formGerenciarMaquininhas()
        {
            InitializeComponent();
            CarregaMaquininhas();
            this.ConfiguraTabIndex();
        }

        private void CarregaMaquininhas()
        {
            List<MaquininhaEntity> listaDataSource = new ModuloCadastro.Service.MaquininhaService().GetList()
                .Where(x => (ckeOcultaInativos.Checked ? x.Inativo == false : true))
                .Select(x => new MaquininhaEntity { Id = x.Id, Nome = x.Nome, Inativo = x.Inativo }).ToList();

            dgvMaquininhas.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(MaquininhaEntity.Id),true,true), (nameof(MaquininhaEntity.Nome),true,true),
                (nameof(MaquininhaEntity.Inativo),true,false),(nameof(MaquininhaEntity.TipoMaquininha),true,false),
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesMaquininha().ShowDialog();
            CarregaMaquininhas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMaquininhas.CurrentRow != null)
            {
                new formDetalhesMaquininha(Convert.ToInt32(dgvMaquininhas.CurrentRow.Cells[nameof(MaquininhaEntity.Id)].Value)).ShowDialog();
                CarregaMaquininhas();
            }
        }
        private void ckeOcultaInativos_CheckedChanged(object sender, EventArgs e)
        {
            CarregaMaquininhas();
        }

        private void dgvMaquininhas_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            MaquininhaEntity row = dgvMaquininhas.Rows[e.RowIndex].DataBoundItem as MaquininhaEntity;

            if (row.Inativo)
            {
                dgvMaquininhas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
            }
        }
    }
}
