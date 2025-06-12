using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;
using SistemaERP.Extensions;
using System.Data;
using System.Dynamic;

namespace SistemaERP.Cadastros.Adquirente
{
    public partial class formGerenciarAdquirentes : Form
    {
        public formGerenciarAdquirentes()
        {
            InitializeComponent();
            CarregaAdquirentes();
            this.ConfiguraTabIndex();
        }

        private void CarregaAdquirentes()
        {
            List<ConfigAdquirenteEntity> listaDataSource = new ModuloCadastro.Service.ConfigAdquirenteService().GetList()
                .Select(x => new ConfigAdquirenteEntity { Id = x.Id, AdquirenteId = x.AdquirenteId,
                    NroPacelas = x.NroPacelas ,TaxaDebito = x.TaxaDebito, 
                    TaxaCreditoAVista = x.TaxaCreditoAVista,TaxaCreditoParcelado = x.TaxaCreditoParcelado,
                    TaxaAntecipacao = x.TaxaAntecipacao}).ToList();

            dgvAdquirentes.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(ConfigAdquirenteEntity.Id),true,true), (nameof(ConfigAdquirenteEntity.AdquirenteId),true,true),
                (nameof(ConfigAdquirenteEntity.NomeInstituicao),true,true),(nameof(ConfigAdquirenteEntity.Cnpj),true,true),
                (nameof(ConfigAdquirenteEntity.NroPacelas),true,true),(nameof(ConfigAdquirenteEntity.TaxaDebito),true,true),
                (nameof(ConfigAdquirenteEntity.TaxaCreditoAVista),true,true),(nameof(ConfigAdquirenteEntity.TaxaCreditoParcelado),true,true),
                (nameof(ConfigAdquirenteEntity.TaxaAntecipacao),true,true),(nameof(ConfigAdquirenteEntity.TaxaCreditoParcelado),true,true),
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesAdquirente().ShowDialog();
            CarregaAdquirentes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAdquirentes.CurrentRow != null)
            {
                new formDetalhesAdquirente(Convert.ToInt32(dgvAdquirentes.CurrentRow.Cells[nameof(ConfigAdquirenteEntity.Id)].Value)).ShowDialog();
                CarregaAdquirentes();
            }
        }
    }
}
