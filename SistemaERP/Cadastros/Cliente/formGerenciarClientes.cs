using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;
using SistemaERP.Cadastros.Extensions;
using System.ComponentModel;
using System.Data;

namespace SistemaERP.Cadastros.Cliente
{
    public partial class formGerenciarClientes : Form
    {
        ModuloCadastro.Context.ModuloCadastroContext _db_context;
        public formGerenciarClientes(ModuloCadastroContext db_context)
        {
            _db_context = db_context;
            InitializeComponent();
            CarregaClientes();
        }

        private void CarregaClientes()
        {
            List<ClienteViewModel> listaDataSource = new();
            if (ckeOcultaExcluidos.Checked)
            {
                listaDataSource = new ModuloCadastro.Service.ClienteService(_db_context)
                .GetList()
                .Where(x => !x.excluido)
                .Select(x => new ClienteViewModel
                { id = x.id, fantasia = x.fantasia, DadosCidade = x.DadosCidade, excluido = x.excluido }).ToList();
            }
            else
            {
                listaDataSource = new ModuloCadastro.Service.ClienteService(_db_context)
                .GetList()
                .Select(x => new ClienteViewModel
                { id = x.id, fantasia = x.fantasia, DadosCidade = x.DadosCidade,excluido = x.excluido }).ToList();
            }

            dgvClientes.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(ClienteViewModel.id),true,true), (nameof(ClienteViewModel.fantasia),true,true),
                (nameof(ClienteViewModel.DadosCidade.cuf),true,true),(nameof(ClienteViewModel.DadosCidade.dmunicipio),true,true),
                (nameof(ClienteViewModel.excluido),true,false)
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesCliente().ShowDialog();

            CarregaClientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                new formDetalhesCliente(Convert.ToInt32(dgvClientes.CurrentRow.Cells[nameof(ClienteViewModel.id)].Value)).ShowDialog();

                CarregaClientes();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir os clientes selecionados?", String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (var cliente in (BindingList<ClienteViewModel>)dgvClientes.DataSource)
                {
                    new ModuloCadastro.Service.ClienteService(new ModuloCadastroContext()).UpdateParcial(new ClienteEntity
                    {
                        id = cliente.id,
                        dataExclusao = DateTime.Now,
                        excluido = true
                    }, new List<string>() { nameof(ClienteViewModel.dataExclusao), nameof(ClienteViewModel.excluido) });
                }

                MessageBox.Show("Exclusão realizada", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregaClientes();
            }
        }

        private void ckeOcultaExcluidos_CheckedChanged(object sender, EventArgs e)
        {
            CarregaClientes();
        }

        private void dgvClientes_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            ClienteViewModel row = dgvClientes.Rows[e.RowIndex].DataBoundItem as ClienteViewModel;

            if (row.excluido)
            {
                dgvClientes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
            }
        }
    }
}
