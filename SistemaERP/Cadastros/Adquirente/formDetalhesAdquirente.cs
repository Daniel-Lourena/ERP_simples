using ModuloCadastro.Context;
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

namespace SistemaERP.Cadastros.Adquirente
{
    public partial class formDetalhesAdquirente : Form
    {
        private int _id = 0;
        private ConfigAdquirenteEntity _adquirente;
        private ConfigAdquirenteService _service;

        public formDetalhesAdquirente(ConfigAdquirenteService service)
        {
            _service = service;
            InitializeComponent();
            CarregarAdquirentes();
            this.ConfiguraTabIndex();
        }

        public formDetalhesAdquirente(ConfigAdquirenteService service, int id) : this(service)
        {
            _id = id;
        }

        private void ConfigurarDataBinding()
        {
            _adquirente = _adquirente ?? new ConfigAdquirenteEntity();
            cbAdquirente.DataBindings.Add(nameof(cbAdquirente.SelectedValue), _adquirente, nameof(_adquirente.AdquirenteId));
            txtNome.DataBindings.Add(nameof(txtNome.Text), _adquirente, nameof(_adquirente.NomeInstituicao));
            txtCnpj.DataBindings.Add(nameof(txtCnpj.Text), _adquirente, nameof(_adquirente.Cnpj));
            nudTaxaDebito.DataBindings.Add(nameof(nudTaxaDebito.Value), _adquirente, nameof(_adquirente.TaxaDebito), formattingEnabled: true, updateMode: DataSourceUpdateMode.OnPropertyChanged);
            nudParcelas.DataBindings.Add(nameof(nudParcelas.Value), _adquirente, nameof(_adquirente.NroPacelas), formattingEnabled: true, updateMode: DataSourceUpdateMode.OnPropertyChanged);
            nudTaxaCreditoAVista.DataBindings.Add(nameof(nudTaxaCreditoAVista.Value), _adquirente, nameof(_adquirente.TaxaCreditoAVista), formattingEnabled: true, updateMode: DataSourceUpdateMode.OnPropertyChanged);
            nudTaxaCreditoParcelado.DataBindings.Add(nameof(nudTaxaCreditoParcelado.Value), _adquirente, nameof(_adquirente.TaxaCreditoParcelado), formattingEnabled: true, updateMode: DataSourceUpdateMode.OnPropertyChanged);
            nudTaxaAntecipacao.DataBindings.Add(nameof(nudTaxaAntecipacao.Value), _adquirente, nameof(_adquirente.TaxaAntecipacao), formattingEnabled: true, updateMode: DataSourceUpdateMode.OnPropertyChanged);
        }

        private void CarregarAdquirentes()
        {
            cbAdquirente.PreencherComboBoxEnum<EAdquirenteMaquininha>();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                _adquirente.Id = _service.Insert(_adquirente);
                _id = _adquirente.Id;
                this.Text = $"REGISTRO [{_adquirente.Id}]";
            }
            else
            {
                _service.Update(_adquirente);
            }
            MessageBox.Show("Salvo com sucesso", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formDetalhesAdquirente_Load(object sender, EventArgs e)
        {
            if (_id > 0) MostraAdquirente();

            ConfigurarDataBinding();
        }

        private void MostraAdquirente()
        {
            _adquirente = _service.Get(_id);
            this.Text = $"REGISTRO [{_adquirente.Id}]";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcAdquirente_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tabPage = tcAdquirente.TabPages[e.Index];
            Rectangle tabBounds = tcAdquirente.GetTabRect(e.Index);

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.TranslateTransform(tabBounds.Left + tabBounds.Width / 2, tabBounds.Top + tabBounds.Height / 2);

                g.DrawString(tabPage.Text, this.Font, SystemBrushes.ControlText, 0, 0, sf);

                g.ResetTransform(); // Reseta a rotação pra não afetar o resto
            }
        }
    }
}
