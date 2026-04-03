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
using SistemaERP.Factory;
using System.Data;

namespace SistemaERP.Cadastros.Maquininha
{
    public partial class formGerenciarMaquininhas : Form
    {
        private readonly IFormFactory _formFactory;
        private readonly MaquininhaService _service;

        public formGerenciarMaquininhas(IFormFactory formFactory, MaquininhaService service)
        {
            _formFactory = formFactory;
            _service = service;
            InitializeComponent();
            CarregaMaquininhas();
            this.ConfiguraTabIndex();
        }

        private void CarregaMaquininhas()
        {
            List<MaquininhaEntity> listaDataSource = _service.GetList()
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
            _formFactory.Criar<formDetalhesMaquininha>().ShowDialog();
            CarregaMaquininhas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMaquininhas.CurrentRow != null)
            {
                _formFactory.Criar<formDetalhesMaquininha>(Convert.ToInt32(dgvMaquininhas.CurrentRow.Cells[nameof(MaquininhaEntity.Id)].Value)).ShowDialog();
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
