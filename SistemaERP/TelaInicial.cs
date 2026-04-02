using Microsoft.Extensions.DependencyInjection;
using SistemaERP.Cadastros.Produto.SetorEstoque;
using SistemaERP.Extensions;
using SistemaERP.Factory;

namespace SistemaERP
{
    public partial class TelaInicial : Form
    {
        private readonly IFormFactory _formFactory;

        public TelaInicial(IFormFactory formFactory)
        {
            _formFactory = formFactory;
            InitializeComponent();
            this.ConfiguraTabIndex();
        }

        private void AbrirForm<T>(params object[] parameters) where T : Form
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is T)
                {
                    f.Activate();
                    return;
                }
            }

            var form = _formFactory.Criar<T>(parameters);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void gerenciarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm<Cadastros.Produto.formGerenciarProdutos>();
        }

        private void gerenciarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm<Cadastros.Usuario.formGerenciarUsuarios>();
        }

        private void gerenciarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm<Cadastros.Cliente.formGerenciarClientes>();
        }

        private void gerenciarBancosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirForm<Cadastros.Banco.formGerenciarBancos>();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm<Venda.formGerenciarVendas>();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm<Cadastros.Produto.Categoria.formGerenciarCategoriasProduto>();
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm<Cadastros.Produto.Estoque.formGerenciar>();
        }

        private void setoresEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm<Cadastros.Produto.SetorEstoque.formGerenciarSetorEstoqueProduto>();
        }

        private void gerenciarMaquininhasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm<Cadastros.Maquininha.formGerenciarMaquininhas>();
        }

        private void adquirentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm<Cadastros.Adquirente.formGerenciarAdquirentes>();
        }

        private void TelaInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja sair do sistema?", "Sistema ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}