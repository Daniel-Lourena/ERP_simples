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
            var listaDataSource = new ModuloCadastro.Service.BancoService(_db_context).GetList()
                .Select(x => new BancoViewModel { id = x.id, nome = x.nome}).ToList();
            dgvBancos.CriarColunasDataGridView(listaDataSource, new()
            { 
                (nameof(BancoViewModel.id),true,true), (nameof(BancoViewModel.nome),true,true),
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesBanco().ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvBancos.CurrentRow != null)
            {
                new formDetalhesBanco(Convert.ToInt32(dgvBancos.CurrentRow.Cells[nameof(BancoViewModel.id)].Value)).ShowDialog();
            }
        }
    }
}
