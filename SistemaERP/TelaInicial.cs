using Microsoft.EntityFrameworkCore;
using SistemaERP.Cadastros.Produto;
using SistemaERP.Cadastros.Usuario;

namespace SistemaERP
{
    public partial class TelaInicial : Form
    {
        ModuloCadastro.Context.ModuloCadastroContext db_context = new();
        public TelaInicial()
        {
            InitializeComponent();
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
    }
}