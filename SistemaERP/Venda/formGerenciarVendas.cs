using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using SistemaERP.Extensions;
using SistemaERP.Factory;
using System.Data;

namespace SistemaERP.Venda
{
    public partial class formGerenciarVendas : Form
    {
        private readonly IFormFactory _formFactory;
        private readonly ClienteService _serviceCliente;
        private readonly PedidoVendaService _servicePedidoVenda;
        public formGerenciarVendas(IFormFactory formFactory, ClienteService serviceCliente, PedidoVendaService servicePedidoVenda)
        {
            _formFactory = formFactory;
            _serviceCliente = serviceCliente;
            _servicePedidoVenda = servicePedidoVenda;

            InitializeComponent();
            CarregaVendas();
            this.ConfiguraTabIndex();
        }

        private void CarregaVendas()
        {
            var listaDataSource = _servicePedidoVenda
                .GetList()
                .Where(x => !x.Excluido)
                .Select(x => new PedidoVendaViewModel { id = x.Id, clienteFantasia = x.Cliente.Fantasia, dataCriacao = x.DataCriacao, nomeUsuarioCriador = x.UsuarioCriacao.Nome }).ToList();

            dgvVendas.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(PedidoVendaViewModel.id),true,true), (nameof(PedidoVendaViewModel.clienteFantasia),true,true),
                (nameof(PedidoVendaViewModel.dataCriacao),true,true),(nameof(PedidoVendaViewModel.nomeUsuarioCriador),true,true)
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (_serviceCliente.GetList().Count() == 0)
            {
                MessageBox.Show("Para seguir com a criação do pedido, cadastre um cliente", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _formFactory.Criar<formDetalhesVenda>().ShowDialog();
            CarregaVendas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVendas.CurrentRow != null)
            {
                _formFactory.Criar<formDetalhesVenda>(Convert.ToInt32(dgvVendas.CurrentRow.Cells[nameof(PedidoVendaEntity.Id)].Value)).ShowDialog();
                CarregaVendas();
            }
        }
    }
}
