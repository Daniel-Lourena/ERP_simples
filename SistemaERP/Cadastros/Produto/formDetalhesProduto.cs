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

namespace SistemaERP.Cadastros.Produto
{
    public partial class formDetalhesProduto : Form
    {
        private int _id = 0;
        private ProdutoEntity _produto;

        public formDetalhesProduto()
        {
            InitializeComponent();
            CarregaSetorEstoque();
            CarregaOrigem();
            CarregaCST();
            CarregaCategoria();
        }
        public formDetalhesProduto(int id) : this()
        {
            _id = id;
        }

        private void CarregaSetorEstoque()
        {
            List<SetorEstoqueEntity> setoresEstoque = new ModuloCadastro.Context.SetorEstoqueContext().GetList();
            cbSetorEstoque.GetList(setoresEstoque, nameof(SetorEstoqueEntity.id), nameof(SetorEstoqueEntity.descricao),true);
        }
        private void CarregaOrigem()
        {
            cbOrigem.GetListEnum<ModuloCadastro.Enum.EOrigemProduto>();
        }
        private void CarregaCST()
        {
            cbCST.GetListEnum<ModuloCadastro.Enum.ECst>();
        }

        private void CarregaCategoria()
        {
            List<CategoriaEntity> categorias = new ModuloCadastro.Context.CategoriaContext().GetList();
            cbCategoria.GetList(categorias,nameof(CategoriaEntity.id), nameof(CategoriaEntity.descricao),true);
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
                cst_csosn = cbCST.SelectedValue as string,
                origem = (int)cbOrigem.SelectedValue,
                categoria = (int)cbCategoria.SelectedValue,
                setorEstoque = (int)cbSetorEstoque.SelectedValue,
                inativo = ckeInativo.Checked,
            };

            if (_id == 0)
            {
                new ModuloCadastro.Context.ProdutoContext().Insert(produto);
            }
            else
            {
                produto.dataCadastro = _produto.dataCadastro;
                new ModuloCadastro.Context.ProdutoContext().Update(produto);
            }
        }

        private void formDetalhesProduto_Load(object sender, EventArgs e)
        {
            if (_id > 0) MostraProduto();
        }

        private void MostraProduto()
        {
            _produto = new ProdutoContext().Get(_id);
            txtCodigoSKU.Text = _produto.codigoEstoque_SKU;
            txtDescricao.Text = _produto.descricao;
            txtNCM.Text = _produto.ncm;
            txtCEST.Text = _produto.cest;
            txtCadastro.Text = _produto.dataCadastro.ToString();
            txtAtualizacao.Text = _produto.dataAtualizacao.ToString();
            cbCST.SelectedValue = _produto.cst_csosn;
            cbOrigem.SelectedValue = _produto.origem;
            cbCategoria.SelectedValue = _produto.categoria;
            cbSetorEstoque.SelectedValue = _produto.setorEstoque;
            ckeInativo.Checked = _produto.inativo;

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
                g.RotateTransform(-90); // Rotaciona 90° no sentido anti-horário

                g.DrawString(tabPage.Text, this.Font, SystemBrushes.ControlText, 0, 0, sf);

                g.ResetTransform(); // Reseta a rotação pra não afetar o resto
            }
        }
    }
}
