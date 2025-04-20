namespace SistemaERP
{
    partial class TelaInicial
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            usuáriosToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            produtosToolStripMenuItem = new ToolStripMenuItem();
            bancosToolStripMenuItem = new ToolStripMenuItem();
            vendasToolStripMenuItem = new ToolStripMenuItem();
            pedidosToolStripMenuItem = new ToolStripMenuItem();
            pedidosFinalizadosToolStripMenuItem = new ToolStripMenuItem();
            financeiroToolStripMenuItem = new ToolStripMenuItem();
            movimentaçãoBancáriaToolStripMenuItem = new ToolStripMenuItem();
            gerenciarProdutosToolStripMenuItem = new ToolStripMenuItem();
            gerenciarUsuáriosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem, vendasToolStripMenuItem, financeiroToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usuáriosToolStripMenuItem, clientesToolStripMenuItem, produtosToolStripMenuItem, bancosToolStripMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(71, 20);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // usuáriosToolStripMenuItem
            // 
            usuáriosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gerenciarUsuáriosToolStripMenuItem });
            usuáriosToolStripMenuItem.Name = "usuáriosToolStripMenuItem";
            usuáriosToolStripMenuItem.Size = new Size(180, 22);
            usuáriosToolStripMenuItem.Text = "Usuários";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(180, 22);
            clientesToolStripMenuItem.Text = "Clientes";
            // 
            // produtosToolStripMenuItem
            // 
            produtosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gerenciarProdutosToolStripMenuItem });
            produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            produtosToolStripMenuItem.Size = new Size(180, 22);
            produtosToolStripMenuItem.Text = "Produtos";
            // 
            // bancosToolStripMenuItem
            // 
            bancosToolStripMenuItem.Name = "bancosToolStripMenuItem";
            bancosToolStripMenuItem.Size = new Size(180, 22);
            bancosToolStripMenuItem.Text = "Bancos";
            // 
            // vendasToolStripMenuItem
            // 
            vendasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pedidosToolStripMenuItem, pedidosFinalizadosToolStripMenuItem });
            vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            vendasToolStripMenuItem.Size = new Size(56, 20);
            vendasToolStripMenuItem.Text = "Vendas";
            // 
            // pedidosToolStripMenuItem
            // 
            pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            pedidosToolStripMenuItem.Size = new Size(177, 22);
            pedidosToolStripMenuItem.Text = "Pedidos";
            // 
            // pedidosFinalizadosToolStripMenuItem
            // 
            pedidosFinalizadosToolStripMenuItem.Name = "pedidosFinalizadosToolStripMenuItem";
            pedidosFinalizadosToolStripMenuItem.Size = new Size(177, 22);
            pedidosFinalizadosToolStripMenuItem.Text = "Pedidos Finalizados";
            // 
            // financeiroToolStripMenuItem
            // 
            financeiroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { movimentaçãoBancáriaToolStripMenuItem });
            financeiroToolStripMenuItem.Name = "financeiroToolStripMenuItem";
            financeiroToolStripMenuItem.Size = new Size(74, 20);
            financeiroToolStripMenuItem.Text = "Financeiro";
            // 
            // movimentaçãoBancáriaToolStripMenuItem
            // 
            movimentaçãoBancáriaToolStripMenuItem.Name = "movimentaçãoBancáriaToolStripMenuItem";
            movimentaçãoBancáriaToolStripMenuItem.Size = new Size(202, 22);
            movimentaçãoBancáriaToolStripMenuItem.Text = "Movimentação Bancária";
            // 
            // gerenciarProdutosToolStripMenuItem
            // 
            gerenciarProdutosToolStripMenuItem.Name = "gerenciarProdutosToolStripMenuItem";
            gerenciarProdutosToolStripMenuItem.Size = new Size(180, 22);
            gerenciarProdutosToolStripMenuItem.Text = "Gerenciar Produtos";
            gerenciarProdutosToolStripMenuItem.Click += gerenciarProdutosToolStripMenuItem_Click;
            // 
            // gerenciarUsuáriosToolStripMenuItem
            // 
            gerenciarUsuáriosToolStripMenuItem.Name = "gerenciarUsuáriosToolStripMenuItem";
            gerenciarUsuáriosToolStripMenuItem.Size = new Size(180, 22);
            gerenciarUsuáriosToolStripMenuItem.Text = "Gerenciar Usuários";
            gerenciarUsuáriosToolStripMenuItem.Click += gerenciarUsuáriosToolStripMenuItem_Click;
            // 
            // TelaInicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "TelaInicial";
            Text = "Sistema ERP";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStripMenuItem usuáriosToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem produtosToolStripMenuItem;
        private ToolStripMenuItem bancosToolStripMenuItem;
        private ToolStripMenuItem vendasToolStripMenuItem;
        private ToolStripMenuItem pedidosToolStripMenuItem;
        private ToolStripMenuItem pedidosFinalizadosToolStripMenuItem;
        private ToolStripMenuItem financeiroToolStripMenuItem;
        private ToolStripMenuItem movimentaçãoBancáriaToolStripMenuItem;
        private ToolStripMenuItem gerenciarProdutosToolStripMenuItem;
        private ToolStripMenuItem gerenciarUsuáriosToolStripMenuItem;
    }
}