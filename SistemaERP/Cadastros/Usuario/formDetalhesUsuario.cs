using ModuloCadastro.Context;
using ModuloCadastro.Service;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using SistemaERP.Cadastros.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModuloCadastro.ViewModel;

namespace SistemaERP.Cadastros.Usuario
{
    public partial class formDetalhesUsuario : Form
    {
        private int _id = 0;
        private UsuarioViewModel _usuario;
        public formDetalhesUsuario()
        {
            InitializeComponent();
            CarregaCargo();
        }

        public formDetalhesUsuario(int id) : this()
        {
            _id = id;
        }

        private void ConfigurarDataBinding()
        {
            _usuario = _usuario ?? new UsuarioViewModel();
            txtNome.DataBindings.Add(nameof(txtNome.Text),_usuario,nameof(_usuario.nome));
            txtCadastro.DataBindings.Add(nameof(txtCadastro.Text),_usuario,nameof(_usuario.dataCadastro));
            txtAtualizacao.DataBindings.Add(nameof(txtAtualizacao.Text), _usuario, nameof(_usuario.dataAtualizacao));
            cbCargo.DataBindings.Add(nameof(cbCargo.SelectedValue),_usuario,nameof(_usuario.cargo));
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
                _usuario.id = new ModuloCadastro.Service.UsuarioService(new ModuloCadastroContext()).Insert(usuario);
                _id = _usuario.id;
                this.Text = $"REGISTRO [{_usuario.id}]";
            }
            else
            {
                _usuario.dataAtualizacao = DateTime.Now;
                new ModuloCadastro.Service.UsuarioService(new ModuloCadastroContext()).Update(_usuario.ToEntity());

            }
            MessageBox.Show("Salvo com sucesso", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formDetalhesUsuario_Load(object sender, EventArgs e)
        {
            if (_id > 0) MostraUsuario();
            ConfigurarDataBinding();
        }

        private void MostraUsuario()
        {
            _usuario = new UsuarioService(new ModuloCadastroContext()).Get(_id).ToViewModel();
            this.Text = $"REGISTRO [{_usuario.id}]";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
