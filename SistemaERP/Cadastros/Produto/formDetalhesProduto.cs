using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using SistemaERP.Extensions;
using System.Data;

namespace SistemaERP.Cadastros.Produto
{
    public partial class formDetalhesProduto : Form
    {
        private int _id = 0;
        private ProdutoViewModel _produto;
        private readonly ProdutoService _serviceProduto;
        private readonly CategoriaService _serviceCategoria;

        public formDetalhesProduto(ProdutoService serviceProduto, CategoriaService serviceCategoria)
        {
            _serviceProduto = serviceProduto;
            _serviceCategoria = serviceCategoria;
            
            InitializeComponent();
            CarregaOrigem();
            CarregaCST();
            CarregaCategoria();
            CarregaUnidade();
            this.ConfiguraTabIndex();
        }
        public formDetalhesProduto(ProdutoService serviceProduto, CategoriaService serviceCategoria,int id) : this(serviceProduto,serviceCategoria)
        {
            _id = id;
        }

        private void ConfigurarDataBinding()
        {
            _produto = _produto ?? new ProdutoViewModel();
            txtCodigoSKU.DataBindings.Add(nameof(txtCodigoSKU.Text), _produto, nameof(_produto.codigoEstoque_SKU));
            txtDescricao.DataBindings.Add(nameof(txtDescricao.Text), _produto, nameof(_produto.descricao));
            txtNCM.DataBindings.Add(nameof(txtNCM.Text), _produto, nameof(_produto.ncm));
            txtCEST.DataBindings.Add(nameof(txtCEST.Text), _produto, nameof(_produto.cest));
            txtCadastro.DataBindings.Add(nameof(txtCadastro.Text), _produto, nameof(_produto.dataCadastro));
            txtAtualizacao.DataBindings.Add(nameof(txtAtualizacao.Text), _produto, nameof(_produto.dataAtualizacao));
            cbCST.DataBindings.Add(nameof(cbCST.SelectedValue), _produto, nameof(_produto.cst_csosn));
            cbOrigem.DataBindings.Add(nameof(cbOrigem.SelectedValue), _produto, nameof(_produto.origem));
            cbCategoria.DataBindings.Add(nameof(cbCategoria.SelectedValue), _produto, nameof(_produto.categoria));
            ckeInativo.DataBindings.Add(nameof(ckeInativo.Checked), _produto, nameof(_produto.inativo));
            nudEstoqueMinimo.DataBindings.Add(nameof(nudEstoqueMinimo.Value), _produto, nameof(_produto.estoqueMinimo));
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
            List<CategoriaViewModel> categorias = _serviceCategoria.GetList().Select(x => new CategoriaViewModel { id = x.Id, descricao = x.Descricao }).ToList();
            cbCategoria.PreencherComboBoxList(categorias, nameof(CategoriaViewModel.id), nameof(CategoriaViewModel.descricao), true);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                _produto.dataCadastro = DateTime.Now;
                _produto.dataAtualizacao = DateTime.Now;
                _produto.id = _serviceProduto.Insert(_produto.ToEntity());
                _id = _produto.id;
                this.Text = $"REGISTRO [{_produto.id}]";
            }
            else
            {
                _produto.dataAtualizacao = _produto.dataAtualizacao;
                _serviceProduto.Update(_produto.ToEntity());
            }

            MessageBox.Show("Salvo com sucesso", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formDetalhesProduto_Load(object sender, EventArgs e)
        {
            if (_id > 0) MostraProduto();
            ConfigurarDataBinding();
        }

        private void MostraProduto()
        {
            _produto = _serviceProduto.Get(_id).ToViewModel();
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
