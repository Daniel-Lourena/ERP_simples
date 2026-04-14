using ModuloCadastro.Entity.Cadastro.Usuario;
using ModuloCadastro.Enum.Usuario;
using ModuloCadastro.Enum.Usuario.Departamento;
using ModuloCadastro.Enum.Usuario.Perfil;
using ModuloCadastro.Service.Cadastro.Usuario;
using ModuloCadastro.ViewModel.Cadastro.Usuario;
using SistemaERP.Extensions;
using SistemaERP.Factory;

namespace SistemaERP.Cadastros.Usuario
{
    public partial class formDetalhesUsuario : Form
    {
        private readonly UsuarioService _service;
        private readonly IFormFactory _formFactory;

        private int _id = 0;
        private UsuarioViewModel _usuario;

        public formDetalhesUsuario(UsuarioService service, IFormFactory formFactory)
        {
            _service = service;
            _formFactory = formFactory;

            InitializeComponent();
            CarregaCargo();
            CarregaDepartamento();
            CarregaPerfilAcesso();
            this.ConfiguraTabIndex();
        }

        public formDetalhesUsuario(UsuarioService service, IFormFactory formFactory, int id) : this(service, formFactory)
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
            txtEmail.DataBindings.Add(nameof(txtEmail.Text), _usuario, nameof(_usuario.email));
            cbDepartamento.DataBindings.Add(nameof(cbDepartamento.SelectedValue), _usuario, nameof(_usuario.departamento));
            cbPerfilAcesso.DataBindings.Add(nameof(cbPerfilAcesso.SelectedValue), _usuario, nameof(_usuario.perfilAcesso));
        }

        private void CarregaCargo()
        {
            cbCargo.PreencherComboBoxEnum<ECargo>();
        }

        private void CarregaDepartamento()
        {
            cbDepartamento.PreencherComboBoxEnum<EDepartamento>();
        }

        private void CarregaPerfilAcesso()
        {
            cbPerfilAcesso.PreencherComboBoxEnum<EPerfilAcesso>();
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
                btnAlterarSenha.Enabled = true;
            }
            else
            {
                _usuario.dataAtualizacao = DateTime.Now;
                _service.UpdateParcial(_usuario.ToEntity(), new List<string>
                {
                    nameof(UsuarioEntity.Nome),
                    nameof(UsuarioEntity.DataAtualizacao),
                    nameof(UsuarioEntity.Cargo),
                    nameof(UsuarioEntity.Email),
                    nameof(UsuarioEntity.Departamento),
                    nameof(UsuarioEntity.PerfilAcesso)
                });
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
            btnAlterarSenha.Enabled = true;
        }

        private void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            var tela = _formFactory.Criar<formAlterarSenha>(_id);
            tela.ShowDialog();
            if (tela._dataAtualizacao != null)
                _usuario.dataAtualizacao = tela._dataAtualizacao;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
