using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using SistemaERP.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP.Cadastros.Produto.Estoque
{
    public partial class formAdicionarEstoque : Form
    {
        public formAdicionarEstoque()
        {
            InitializeComponent();
            CarregaProdutos();
            CarregaSetorEstoque();
        }

        private void CarregaProdutos()
        {
            cbProdutos.PreencherComboBoxList(
                new ProdutoService(new ModuloCadastro.Context.ModuloCadastroContext())
                    .GetList().Where(x => !x.Inativo)
                    .Select(y => new ProdutoEntity { Id = y.Id, CodigoEstoque_SKU = y.CodigoEstoque_SKU }).ToList(),
                nameof(ProdutoEntity.Id), nameof(ProdutoEntity.CodigoEstoque_SKU));
        }
        private void CarregaSetorEstoque()
        {
            cbSetores.PreencherComboBoxList(
                new SetorEstoqueService().GetList(), nameof(SetorEstoqueEntity.Id), nameof(SetorEstoqueEntity.Descricao));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(nudQtd.Value <= 0)
            {
                MessageBox.Show($"Quantidade inválida.", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Deseja incluir estoque para o item {cbProdutos.Text} - {cbSetores.Text} (Qtd: {nudQtd.Value}) ?", "Sistema ERP",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            new EstoqueService().Insert(new ModuloCadastro.Entity.EstoqueEntity
            {
                ProdutoId = Convert.ToInt32(cbProdutos.SelectedValue),
                SetorEstoqueId = Convert.ToInt32(cbSetores.SelectedValue),
                Quantidade = nudQtd.Value
            });

            MessageBox.Show($"Inclusão realizada com sucesso", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
