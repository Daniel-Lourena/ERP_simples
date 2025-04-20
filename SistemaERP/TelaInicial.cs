using SistemaERP.Cadastros.Usuario;

namespace SistemaERP
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void gerenciarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gerenciarUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Cadastros.Usuario.formGerenciarUsuarios))
                {
                    f.Activate();
                    return;
                }
            }
            Cadastros.Usuario.formGerenciarUsuarios childForm = new();
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
}