using SistemaERP.Cadastros.Produto.SetorEstoque;
using SistemaERP.Extensions;

namespace SistemaERP
{
    public partial class TelaInicial : Form
    {
        ModuloCadastro.Context.ModuloCadastroContext db_context = new();
        public TelaInicial()
        {
            InitializeComponent();
            this.ConfiguraTabIndex();
        }

        private void gerenciarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Cadastros.Produto.formGerenciarProdutos))
                {
                    f.Activate();
                    return;
                }
            }
            Cadastros.Produto.formGerenciarProdutos childForm = new(db_context);
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void gerenciarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Cadastros.Usuario.formGerenciarUsuarios))
                {
                    f.Activate();
                    return;
                }
            }
            Cadastros.Usuario.formGerenciarUsuarios childForm = new(db_context);
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void gerenciarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Cadastros.Cliente.formGerenciarClientes))
                {
                    f.Activate();
                    return;
                }
            }
            Cadastros.Cliente.formGerenciarClientes childForm = new(db_context);
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void gerenciarBancosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Cadastros.Banco.formGerenciarBancos))
                {
                    f.Activate();
                    return;
                }
            }
            Cadastros.Banco.formGerenciarBancos childForm = new(db_context);
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Venda.formGerenciarVendas))
                {
                    f.Activate();
                    return;
                }
            }
            Venda.formGerenciarVendas childForm = new();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Cadastros.Produto.Categoria.formGerenciarCategoriasProduto))
                {
                    f.Activate();
                    return;
                }
            }
            Cadastros.Produto.Categoria.formGerenciarCategoriasProduto childForm = new(db_context);
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Cadastros.Produto.Categoria.formGerenciarCategoriasProduto))
                {
                    f.Activate();
                    return;
                }
            }
            Cadastros.Produto.Estoque.formGerenciar childForm = new();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void setoresEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Cadastros.Produto.SetorEstoque.formGerenciarSetorEstoqueProduto))
                {
                    f.Activate();
                    return;
                }
            }
            Cadastros.Produto.SetorEstoque.formGerenciarSetorEstoqueProduto childForm = new();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void gerenciarMaquininhasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Cadastros.Maquininha.formGerenciarMaquininhas))
                {
                    f.Activate();
                    return;
                }
            }
            Cadastros.Maquininha.formGerenciarMaquininhas childForm = new();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void adquirentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Cadastros.Adquirente.formGerenciarAdquirentes))
                {
                    f.Activate();
                    return;
                }
            }
            Cadastros.Adquirente.formGerenciarAdquirentes childForm = new();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }
    }
}