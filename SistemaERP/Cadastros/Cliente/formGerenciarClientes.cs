using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP.Cadastros.Cliente
{
    public partial class formGerenciarClientes : Form
    {
        ModuloCadastro.Context.ModuloCadastroContext _db_context;
        public formGerenciarClientes(ModuloCadastroContext db_context)
        {
            _db_context = db_context;
            InitializeComponent();
            CarregaClientes();
        }

        private void CarregaClientes()
        {
            var listaDataSource = new ModuloCadastro.Context.ClienteContext(_db_context).GetList().Select(x => new ClienteEntity { id = x.id, fantasia = x.fantasia, end_cidade = x.end_cidade, end_uf = x.end_uf }).ToList();
            CriarColunasDataGridView(listaDataSource);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesCliente().ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                new formDetalhesCliente(Convert.ToInt32(dgvClientes.CurrentRow.Cells[nameof(ClienteEntity.id)].Value)).ShowDialog();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir os clientes selecionados?", String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ModuloCadastro.Context.ClienteContext.UpdateParcial(new ClienteEntity()
                {
                    dataExclusao = DateTime.Now,
                    excluido = true
                }, new List<string>() { nameof(ClienteEntity.dataExclusao), nameof(ClienteEntity.excluido) });

                CarregaClientes();
            }
        }

        private void CriarColunasDataGridView<T>(List<T> listaDataSource)
        {
            dgvClientes.Columns.Clear();
            dgvClientes.Refresh();

            PropertyInfo[]? propriedades = typeof(T).GetProperties().Where(x=> x.GetCustomAttribute<NotMappedAttribute>() == null).ToArray();

            foreach (var prop in propriedades)
            {
                DataGridViewTextBoxColumn coluna = new()
                {
                    DataPropertyName = prop.Name,
                    ReadOnly = true,
                    Name = prop.Name,
                    HeaderText = prop.GetCustomAttribute<DisplayAttribute>().Name ?? prop.Name
                };

                dgvClientes.Columns.Add(coluna);
            }

            foreach (var item in listaDataSource)
            {
                var valores = propriedades.Select(p => p.GetValue(item)?.ToString() ?? String.Empty).ToArray();
                dgvClientes.Rows.Add(valores);
            }

            dgvClientes.Refresh();
        }
    }
}
