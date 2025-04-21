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

namespace SistemaERP.Cadastros.Produto
{
    public partial class formGerenciarProdutos : Form
    {
        public formGerenciarProdutos()
        {
            InitializeComponent();
            CarregaProdutos();
        }

        private void CarregaProdutos()
        {
            var listaDataSource = new ModuloCadastro.Context.ProdutoContext().GetList().Select(x => new ProdutoEntity { id = x.id, descricao = x.descricao, categoria = x.categoria, idUnidade = x.idUnidade, setorEstoque = x.setorEstoque }).ToList();
            CriarColunasDataGridView(listaDataSource);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesProduto().ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                new formDetalhesProduto(Convert.ToInt32(dgvProdutos.CurrentRow.Cells[nameof(ProdutoEntity.id)].Value)).ShowDialog();
            }
        }

        private void CriarColunasDataGridView<T>(List<T> listaDataSource)
        {
            dgvProdutos.Columns.Clear();
            dgvProdutos.Refresh();

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

                dgvProdutos.Columns.Add(coluna);
            }

            foreach (var item in listaDataSource)
            {
                var valores = propriedades.Select(p => p.GetValue(item)?.ToString() ?? String.Empty).ToArray();
                dgvProdutos.Rows.Add(valores);
            }

            dgvProdutos.Refresh();
        }
    }
}
