using ModuloCadastro.Service.Cadastro.Cliente;
using ModuloCadastro.ViewModel.Cadastro.Cliente;
using SistemaERP.Extensions;

namespace SistemaERP.Generico
{
    public partial class formAdicionarClientes : Form
    {
        private readonly ClienteService _serviceCliente;
        public int _idClienteSelecionado = 0;
        public formAdicionarClientes(ClienteService serviceCliente)
        {
            _serviceCliente = serviceCliente;

            InitializeComponent();
            CarregarClientes();
            this.ConfiguraTabIndex();
        }

        private void CarregarClientes()
        {
            var listaClientes = _serviceCliente.GetList()
                .Select(x => new ClienteViewModel { id = x.Id, fantasia = x.Fantasia }).ToList();

            dgvClientes.CriarColunasDataGridView<ClienteViewModel>
                (
                    listaClientes,
                    new()
                    {
                        (nameof(ClienteViewModel.id),true,true),
                        (nameof(ClienteViewModel.fantasia),true,true)
                    }
                );
        }


        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            if (dgvClientes.Rows.Count == 0) return;

            if (dgvClientes.CurrentRow != null)
            {
                _idClienteSelecionado = Convert.ToInt32(dgvClientes.CurrentRow.Cells[nameof(ClienteViewModel.id)].Value);
                this.Close();
            }
        }
    }
}
