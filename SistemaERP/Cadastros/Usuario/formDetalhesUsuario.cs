using ModuloCadastro.Context;
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

namespace SistemaERP.Cadastros.Usuario
{
    public partial class formDetalhesUsuario : Form
    {
        private int _id = 0;
        private UsuarioEntity _usuario;
        public formDetalhesUsuario()
        {
            InitializeComponent();
            CarregaCargo();
        }

        public formDetalhesUsuario(int id) : this()
        {
            _id = id;
        }

        private void CarregaCargo()
        {
            cbCargo.GetListEnum<ModuloCadastro.Enum.ECargo>();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            UsuarioEntity usuario = new()
            {
                nome = txtNome.Text,
                cargo = Convert.ToInt32(cbCargo.SelectedValue),
                dataCadastro = DateTime.Now,
                dataAtualizacao = DateTime.Now
            };

            if (_id == 0)
            {
                new ModuloCadastro.Context.UsuarioContext(new ModuloCadastroContext()).Insert(usuario);
            }
            else
            {
                usuario.dataCadastro = _usuario.dataCadastro;
                new ModuloCadastro.Context.UsuarioContext(new ModuloCadastroContext()).Update(usuario);
            }
        }

        private void formDetalhesUsuario_Load(object sender, EventArgs e)
        {
            if (_id > 0) MostraUsuario();
        }

        private void MostraUsuario()
        {
            _usuario = new UsuarioContext(new ModuloCadastroContext()).Get(_id);
            txtNome.Text = _usuario.nome;
            txtCadastro.Text = _usuario.dataCadastro.ToString();
            txtAtualizacao.Text = _usuario.dataAtualizacao.ToString();
            cbCargo.SelectedValue = _usuario.cargo;
            this.Text = $"REGISTRO [{_usuario.id}]";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
