using ModuloCadastro.Context;
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

namespace SistemaERP.Cadastros.Usuario
{
    public partial class formDetalhesUsuario : Form
    {
        private readonly UsuarioService _service;

        private int _id = 0;
        private UsuarioViewModel _usuario;
        public formDetalhesUsuario(UsuarioService service)
        {
            _service = service;

            InitializeComponent();
            CarregaCargo();
            this.ConfiguraTabIndex();
        }

        public formDetalhesUsuario(UsuarioService service, int id) : this(service)
        {
            _id = id;
        }

        private void ConfigurarDataBindings()
        {
            _usuario = _usuario ?? new UsuarioViewModel();
            txtNome.DataBindings.Add(nameof(txtNome.Text), _usuario, nameof(_usuario.nome));
            txtCadastro.DataBindings.Add(nameof(txtCadastro.Text), _usuario, nameof(_usuario.dataCadastro));
            txtAtualizacao.DataBindings.Add(nameof(txtAtualizacao.Text), _usuario, nameof(_usuario.dataAtualizacao));
            cbCargo.DataBindings.Add(nameof(cbCargo.SelectedValue), _usuario, nameof(_usuario.cargo));
        }

        private void CarregaCargo()
        {
            cbCargo.PreencherComboBoxEnum<ModuloCadastro.Enum.ECargo>();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_usuario.id == 0)
            {
                _usuario.dataCadastro = DateTime.Now;
                _usuario.dataAtualizacao = DateTime.Now;
                UsuarioEntity usuario = _usuario.ToEntity();
                _usuario.id = _service.Insert(usuario);
                _id = _usuario.id;
                this.Text = $"REGISTRO [{_usuario.id}]";
            }
            else
            {
                _usuario.dataAtualizacao = DateTime.Now;
                _service.Update(_usuario.ToEntity());

            }
            MessageBox.Show("Salvo com sucesso", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formDetalhesUsuario_Load(object sender, EventArgs e)
        {
            if (_id > 0) MostraUsuario();
            ConfigurarDataBindings();
        }

        private void MostraUsuario()
        {
            _usuario = _service.Get(_id).ToViewModel();
            this.Text = $"REGISTRO [{_usuario.id}]";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
