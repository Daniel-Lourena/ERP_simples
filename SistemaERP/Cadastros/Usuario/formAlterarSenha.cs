using ModuloCadastro.Entity.Cadastro.Usuario;
using ModuloCadastro.Service.Cadastro.Usuario;

namespace SistemaERP.Cadastros.Usuario
{
    public partial class formAlterarSenha : Form
    {
        private readonly UsuarioService _service;
        private readonly int _usuarioId;
        private string? _senhaHashAtual;

        public DateTime? _dataAtualizacao { get; private set; }

        public formAlterarSenha(UsuarioService service, int usuarioId)
        {
            _service = service;
            _usuarioId = usuarioId;
            InitializeComponent();
        }

        private void formAlterarSenha_Load(object sender, EventArgs e)
        {
            UsuarioEntity usuario = _service.Get(_usuarioId);
            _senhaHashAtual = usuario.Senha;

            if (string.IsNullOrWhiteSpace(_senhaHashAtual))
            {
                txtSenhaAtual.Enabled = false;
                btnValidarSenha.Enabled = false;
                txtNovaSenha.Enabled = true;
                txtNovaSenhaConfirma.Enabled = true;
                btnSalvarNovaSenha.Enabled = true;
            }
        }

        private void btnValidarSenha_Click(object sender, EventArgs e)
        {
            if (BCrypt.Net.BCrypt.Verify(txtSenhaAtual.Text, _senhaHashAtual))
            {
                txtSenhaAtual.Enabled = false;
                txtNovaSenha.Enabled = true;
                txtNovaSenhaConfirma.Enabled = true;
                btnSalvarNovaSenha.Enabled = true;
            }
            else
            {
                MessageBox.Show("Senha atual incorreta.", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalvarNovaSenha_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNovaSenha.Text))
            {
                MessageBox.Show("A nova senha não pode ser vazia.", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNovaSenha.Text != txtNovaSenhaConfirma.Text)
            {
                MessageBox.Show("As senhas não conferem.", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _dataAtualizacao = DateTime.Now;

            UsuarioEntity entity = _service.Get(_usuarioId);
            entity.Senha = BCrypt.Net.BCrypt.HashPassword(txtNovaSenha.Text);
            entity.DataAtualizacao = _dataAtualizacao;
            _service.UpdateParcial(entity, new List<string> { nameof(UsuarioEntity.Senha), nameof(UsuarioEntity.DataAtualizacao) });

            MessageBox.Show("Senha alterada com sucesso.", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
