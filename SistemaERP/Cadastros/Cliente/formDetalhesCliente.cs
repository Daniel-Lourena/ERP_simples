using ModuloCadastro.Context;
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
using SistemaERP.Cadastros.Helper;
using SistemaERP.Extensions;
using SistemaERP.Factory;

namespace SistemaERP.Cadastros.Cliente
{
    public partial class formDetalhesCliente : Form
    {
        private readonly ClienteService _serviceCliente;
        private readonly EstadoService _serviceEstado;
        private readonly CidadeService _serviceCidade;

        private int _id = 0;
        private ClienteViewModel _cliente;

        public formDetalhesCliente(ClienteService serviceCliente, EstadoService serviceEstado, CidadeService serviceCidade)
        {
            _serviceCliente = serviceCliente;
            _serviceEstado = serviceEstado;
            _serviceCidade = serviceCidade;

            InitializeComponent();
            CarregaEstado();
            this.ConfiguraTabIndex();
        }
        public formDetalhesCliente(ClienteService serviceCliente, EstadoService serviceEstado,CidadeService serviceCidade ,int id) : this(serviceCliente, serviceEstado,serviceCidade)
        {
            _id = id;
        }

        private void ConfigurarDataBinding()
        {
            _cliente = _cliente ?? new ClienteViewModel();
            txtFantasia.DataBindings.Add(nameof(txtFantasia.Text), _cliente, nameof(_cliente.fantasia));
            txtRazaoSocial.DataBindings.Add(nameof(txtRazaoSocial.Text), _cliente, nameof(_cliente.razaoSocial));
            txtLogradouro.DataBindings.Add(nameof(txtLogradouro.Text), _cliente, nameof(_cliente.end_logradouro));
            txtRua.DataBindings.Add(nameof(txtRua.Text), _cliente, nameof(_cliente.end_nomeRua));
            txtNro.DataBindings.Add(nameof(txtNro.Text), _cliente, nameof(_cliente.end_numero));
            txtBairro.DataBindings.Add(nameof(txtBairro.Text), _cliente, nameof(_cliente.end_bairro));
            txtCadastro.DataBindings.Add(nameof(txtCadastro.Text), _cliente, nameof(_cliente.dataCadastro));
            txtAtualizacao.DataBindings.Add(nameof(txtAtualizacao.Text), _cliente, nameof(_cliente.dataAtualizacao));
            cbEstados.DataBindings.Add(nameof(cbEstados.SelectedValue), _cliente, nameof(_cliente.end_uf));
            cbCidades.DataBindings.Add(nameof(cbCidades.SelectedValue), _cliente, nameof(_cliente.end_cidade));
        }

        private void CarregaEstado()
        {
            cbEstados.GetListEstados(_serviceEstado);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                _cliente.dataCadastro = DateTime.Now;
                _cliente.dataAtualizacao = DateTime.Now;
                _cliente.id = _serviceCliente.Insert(_cliente.ToEntity());
                _id = _cliente.id;
                this.Text = $"REGISTRO [{_cliente.id}]";
            }
            else
            {
                _cliente.dataAtualizacao = DateTime.Now;
                _serviceCliente.Update(_cliente.ToEntity());
            }

            MessageBox.Show("Salvo com sucesso", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formDetalhesCliente_Load(object sender, EventArgs e)
        {
            if (_id > 0) MostraCliente();
            ConfigurarDataBinding();
        }

        private void MostraCliente()
        {
            _cliente = _serviceCliente.Get(_id).ToViewModel();

            if (_cliente.excluido)
            {
                lblDataExclusao.Visible = true;
                txtExclusao.Visible = true;
            }

            this.Text = $"REGISTRO [{_cliente.id}]";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcCliente_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tabPage = tcCliente.TabPages[e.Index];
            Rectangle tabBounds = tcCliente.GetTabRect(e.Index);

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.TranslateTransform(tabBounds.Left + tabBounds.Width / 2, tabBounds.Top + tabBounds.Height / 2);

                g.DrawString(tabPage.Text, this.Font, SystemBrushes.ControlText, 0, 0, sf);

                g.ResetTransform(); // Reseta a rotação pra não afetar o resto
            }
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstados.SelectedValue != null)
                cbCidades.GetListCidades(_serviceCidade,(int)cbEstados.SelectedValue);
        }
    }
}
