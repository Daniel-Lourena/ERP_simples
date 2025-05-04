using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using SistemaERP.Cadastros.Extensions;
using System.Data;

namespace SistemaERP.Cadastros.Produto
{
    public partial class formDetalhesProduto : Form
    {
        private int _id = 0;
        private ProdutoEntity _produto;

        public formDetalhesProduto()
        {
            InitializeComponent();
            CarregaOrigem();
            CarregaCST();
            CarregaCategoria();
            CarregaUnidade();
        }
        public formDetalhesProduto(int id) : this()
        {
            _id = id;
        }

        private void CarregaOrigem()
        {
            cbOrigem.PreencherComboBoxEnum<ModuloCadastro.Enum.EOrigemProduto>();
        }
        private void CarregaCST()
        {
            cbCST.PreencherComboBoxEnum<ModuloCadastro.Enum.ECst>();
        }
        private void CarregaUnidade()
        {
            cbUnidade.PreencherComboBoxEnum<ModuloCadastro.Enum.EUnidadeProduto>();
        }

        private void CarregaCategoria()
        {
            List<CategoriaViewModel> categorias = new ModuloCadastro.Service.CategoriaService(new ModuloCadastroContext()).GetList().Select(x => new CategoriaViewModel { id = x.id, descricao = x.descricao }).ToList();
            cbCategoria.PreencherComboBoxList(categorias, nameof(CategoriaViewModel.id), nameof(CategoriaViewModel.descricao), true);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ProdutoEntity produto = new()
            {
                codigoEstoque_SKU = txtCodigoSKU.Text,
                descricao = txtDescricao.Text,
                ncm = txtNCM.Text,
                cest = txtCEST.Text,
                dataCadastro = DateTime.Now,
                dataAtualizacao = DateTime.Now,
                cst_csosn = cbCST.SelectedValue.ToString(),
                origem = (EOrigemProduto)cbOrigem.SelectedValue,
                categoria = cbCategoria.SelectedValue == null ? 0 : (int)cbCategoria.SelectedValue,
                inativo = ckeInativo.Checked,
                estoqueMinimo = nudEstoqueMinimo.Value
            };

            if (_id == 0)
            {
                new ModuloCadastro.Service.ProdutoService(new ModuloCadastroContext()).Insert(produto);
            }
            else
            {
                produto.dataCadastro = _produto.dataCadastro;
                new ModuloCadastro.Service.ProdutoService(new ModuloCadastroContext()).Update(produto);
            }
        }

        private void formDetalhesProduto_Load(object sender, EventArgs e)
        {
            if (_id > 0) MostraProduto();
        }

        private void MostraProduto()
        {
            _produto = new ProdutoService(new ModuloCadastroContext()).Get(_id);
            txtCodigoSKU.Text = _produto.codigoEstoque_SKU;
            txtDescricao.Text = _produto.descricao;
            txtNCM.Text = _produto.ncm;
            txtCEST.Text = _produto.cest;
            txtCadastro.Text = _produto.dataCadastro.ToString();
            txtAtualizacao.Text = _produto.dataAtualizacao.ToString();
            cbCST.SelectedValue = _produto.cst_csosn;
            cbOrigem.SelectedValue = _produto.origem;
            cbCategoria.SelectedValue = _produto.categoria;
            ckeInativo.Checked = _produto.inativo;
            nudEstoqueMinimo.Value = _produto.estoqueMinimo;

            this.Text = $"REGISTRO [{_produto.id}]";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcProduto_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tabPage = tcProduto.TabPages[e.Index];
            Rectangle tabBounds = tcProduto.GetTabRect(e.Index);

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.TranslateTransform(tabBounds.Left + tabBounds.Width / 2, tabBounds.Top + tabBounds.Height / 2);

                g.DrawString(tabPage.Text, this.Font, SystemBrushes.ControlText, 0, 0, sf);

                g.ResetTransform(); // Reseta a rotação pra não afetar o resto
            }
        }
    }
}
