using ModuloCadastro.Context;
using ModuloCadastro.ViewModel;
using SistemaERP.Cadastros.Extensions;
using System.Data;

namespace SistemaERP.Cadastros.Banco
{
    public partial class formGerenciarBancos : Form
    {
        ModuloCadastro.Context.ModuloCadastroContext _db_context;
        public formGerenciarBancos(ModuloCadastroContext db_context)
        {
            _db_context = db_context;
            InitializeComponent();
            CarregaBancos();
        }

        private void CarregaBancos()
        {
            List<BancoViewModel> listaDataSource = new();
            if (ckeOcultaInativos.Checked)
            {
                listaDataSource = new ModuloCadastro.Service.BancoService(_db_context).GetList()
                .Where(x => !x.inativo)
                .Select(x => new BancoViewModel { id = x.id, nome = x.nome,inativo = x.inativo }).ToList();
            }
            else
            {
                listaDataSource = new ModuloCadastro.Service.BancoService(_db_context).GetList()
                .Select(x => new BancoViewModel { id = x.id, nome = x.nome, inativo = x.inativo }).ToList();
            }
                dgvBancos.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(BancoViewModel.id),true,true), (nameof(BancoViewModel.nome),true,true),
                (nameof(BancoViewModel.inativo),true,false),
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesBanco().ShowDialog();
            CarregaBancos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvBancos.CurrentRow != null)
            {
                new formDetalhesBanco(Convert.ToInt32(dgvBancos.CurrentRow.Cells[nameof(BancoViewModel.id)].Value)).ShowDialog();
                CarregaBancos();
            }
        }
        private void ckeOcultaInativos_CheckedChanged(object sender, EventArgs e)
        {
            CarregaBancos();
        }

        private void dgvBancos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            BancoViewModel row = dgvBancos.Rows[e.RowIndex].DataBoundItem as BancoViewModel;

            if (row.inativo)
            {
                dgvBancos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
            }
        }
    }
}
