using ModuloCadastro.Context;
using ModuloCadastro.ViewModel;
using SistemaERP.Cadastros.Extensions;
using System.Data;

namespace SistemaERP.Vendas
{
    public partial class formGerenciarVendas : Form
    {
        private ModuloCadastro.Context.ModuloCadastroContext _db_context;

        public formGerenciarVendas(ModuloCadastroContext db_context)
        {
            _db_context = db_context;
            InitializeComponent();
            CarregaVendas();
        }

        private void CarregaVendas()
        {
            var listaDataSource = new ModuloCadastro.Service.PedidoVendaService(_db_context)
                .GetList()
                .Select(x => new PedidoVendaViewModel { id = x.id, idCliente = x.idCliente, dataCriacao = x.dataCriacao, nomeUsuarioCriador = x.DadosUsuarioCriador.nome }).ToList();

            dgvVendas.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(PedidoVendaViewModel.id),true,true), (nameof(PedidoVendaViewModel.idCliente),true,true),
                (nameof(PedidoVendaViewModel.dataCriacao),true,true),(nameof(PedidoVendaViewModel.nomeUsuarioCriador),true,true)
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesVenda().ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVendas.CurrentRow != null)
            {
                new formDetalhesVenda(Convert.ToInt32(dgvVendas.CurrentRow.Cells[nameof(PedidoVendaViewModel.id)].Value)).ShowDialog();
            }
        }
    }
}
