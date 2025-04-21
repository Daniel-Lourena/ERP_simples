using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
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
        public formGerenciarUsuarios()
        {
            InitializeComponent();
            CarregaUsuarios();
        }

        private void CarregaUsuarios()
        {
            var listaDataSource = new ModuloCadastro.Context.UsuarioContext().GetList().Select(x => new UsuarioEntity { id = x.id, nome = x.nome, cargo = x.cargo }).ToList();
            CriarColunasDataGridView(listaDataSource);
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
            if (MessageBox.Show("Deseja realmente excluir os usuários selecionados?",String.Empty,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new ModuloCadastro.Context.UsuarioContext().UpdateParcial(new UsuarioEntity()
                {
                    dataExclusao = DateTime.Now,
                    excluido = true
                }, new List<string>() { nameof(UsuarioEntity.dataExclusao), nameof(UsuarioEntity.excluido) });
                
                CarregaUsuarios();
            }
        }

        private void CriarColunasDataGridView<T>(List<T> listaDataSource)
        {
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.Refresh();

            PropertyInfo[]? propriedades = typeof(T).GetProperties();

            foreach (var prop in propriedades)
            {
                DataGridViewTextBoxColumn coluna = new()
                {
                    DataPropertyName = prop.Name,
                    ReadOnly = true,
                    Name = prop.Name,
                    HeaderText = prop.GetCustomAttribute<DisplayAttribute>().Name ?? prop.Name
                };

                dgvUsuarios.Columns.Add(coluna);
            }

            foreach (var item in listaDataSource)
            {
                var valores = propriedades.Select(p => p.GetValue(item)?.ToString() ?? String.Empty).ToArray();
                dgvUsuarios.Rows.Add(valores);
            }

            dgvUsuarios.Refresh();
        }
    }
}
