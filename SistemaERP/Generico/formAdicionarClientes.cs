using ModuloCadastro.Entity;
using ModuloCadastro.Entity.Financeiro;
using ModuloCadastro.Entity.Cadastro.Produto;
using ModuloCadastro.Entity.Cadastro.Cliente;
using ModuloCadastro.Entity.Cadastro.Localizacao;
using ModuloCadastro.Entity.Cadastro.Usuario;
using ModuloCadastro.Entity.Venda;
using ModuloCadastro.Enum;
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
