using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using SistemaERP.Cadastros.Extensions;
using System.Data;

namespace SistemaERP.Venda
{
    public partial class formGerenciarVendas : Form
    {
        public formGerenciarVendas()
        {
            InitializeComponent();
            CarregaVendas();
            this.ConfiguraTabIndex();
        }

        private void CarregaVendas()
        {
            var listaDataSource = new ModuloCadastro.Service.PedidoVendaService(new ModuloCadastroContext())
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
            if (new ClienteService(new ModuloCadastroContext()).GetList().Count() == 0)
            {
                MessageBox.Show("Para seguir com a criação do pedido, cadastre um cliente", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            new formDetalhesVenda().ShowDialog();
            CarregaVendas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVendas.CurrentRow != null)
            {
                new formDetalhesVenda(Convert.ToInt32(dgvVendas.CurrentRow.Cells[nameof(PedidoVendaEntity.Id)].Value)).ShowDialog();
                CarregaVendas();
            }
        }
    }
}
