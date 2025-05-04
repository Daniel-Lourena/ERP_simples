using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using ModuloCadastro.ViewModel;
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
            var listaDataSource = new ModuloCadastro.Service.UsuarioService(_db_context).GetList()
                .Where(x => !x.excluido)
                .Select(x => new UsuarioViewModel 
                { id = x.id, nome = x.nome, cargo = x.cargo,dataCadastro = x.dataCadastro,dataAtualizacao = x.dataAtualizacao })
                .ToList();

            dgvUsuarios.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(UsuarioViewModel.id),true,true), (nameof(UsuarioViewModel.nome),true,true),
                (nameof(UsuarioViewModel.cargo),true,true),(nameof(UsuarioViewModel.dataCadastro),true,true),
                (nameof(UsuarioViewModel.dataAtualizacao),true,true)
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesUsuario().ShowDialog();
            CarregaUsuarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                new formDetalhesUsuario(Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[nameof(UsuarioViewModel.id)].Value)).ShowDialog();
            }
            CarregaUsuarios();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir os usuários selecionados?", String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new ModuloCadastro.Service.UsuarioService(new ModuloCadastroContext()).UpdateParcial(new UsuarioEntity()
                {
                    id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[nameof(UsuarioViewModel.id)].Value),
                    dataExclusao = DateTime.Now,
                    excluido = true
                }, new List<string>() { nameof(UsuarioEntity.dataExclusao), nameof(UsuarioEntity.excluido) });

                CarregaUsuarios();
            }
        }
    }
}
