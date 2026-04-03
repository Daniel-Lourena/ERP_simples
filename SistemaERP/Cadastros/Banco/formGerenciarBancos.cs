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

namespace SistemaERP.Cadastros.Banco
{
    public partial class formGerenciarBancos : Form
    {
        private readonly IFormFactory _formFactory;
        private readonly BancoService _service;

        public formGerenciarBancos(IFormFactory formFactory,BancoService service)
        {
            _formFactory = formFactory;
            _service = service;
            InitializeComponent();
            CarregaBancos();
            this.ConfiguraTabIndex();
        }

        private void CarregaBancos()
        {
            List<BancoViewModel> listaDataSource = new();
            if (ckeOcultaInativos.Checked)
            {
                listaDataSource = _service.GetList()
                .Where(x => !x.Inativo)
                .Select(x => new BancoViewModel { id = x.Id, nome = x.Nome, inativo = x.Inativo }).ToList();
            }
            else
            {
                listaDataSource = _service.GetList()
                .Select(x => new BancoViewModel { id = x.Id, nome = x.Nome, inativo = x.Inativo }).ToList();
            }

            dgvBancos.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(BancoViewModel.id),true,true), (nameof(BancoViewModel.nome),true,true),
                (nameof(BancoViewModel.inativo),true,false),
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            _formFactory.Criar<formDetalhesBanco>().ShowDialog();
            CarregaBancos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvBancos.CurrentRow != null)
            {
                _formFactory.Criar<formDetalhesBanco>(Convert.ToInt32(dgvBancos.CurrentRow.Cells[nameof(BancoViewModel.id)].Value)).ShowDialog();
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
