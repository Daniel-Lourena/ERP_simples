using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using SistemaERP.Cadastros.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP.Cadastros.Usuario
{
    public partial class formGerenciarUsuarios : Form
    {
        private ModuloCadastro.Context.ModuloCadastroContext _db_context;

        public formGerenciarUsuarios(ModuloCadastroContext db_context)
        {
            _db_context = db_context;
            InitializeComponent();
            CarregaUsuarios();
        }

        private void CarregaUsuarios()
        {
            var listaDataSource = new ModuloCadastro.Service.UsuarioService(_db_context).GetList().Select(x => new UsuarioEntity { id = x.id, nome = x.nome, cargo = x.cargo }).ToList();

            dgvUsuarios.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(UsuarioEntity.id),true,true), (nameof(UsuarioEntity.nome),true,true),
                (nameof(UsuarioEntity.cargo),true,true)
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesUsuario().ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                new formDetalhesUsuario(Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[nameof(UsuarioEntity.id)].Value)).ShowDialog();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir os usuários selecionados?", String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new ModuloCadastro.Service.UsuarioService(new ModuloCadastroContext()).UpdateParcial(new UsuarioEntity()
                {
                    dataExclusao = DateTime.Now,
                    excluido = true
                }, new List<string>() { nameof(UsuarioEntity.dataExclusao), nameof(UsuarioEntity.excluido) });

                CarregaUsuarios();
            }
        }
    }
}
