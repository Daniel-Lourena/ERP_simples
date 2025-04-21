namespace SistemaERP.Cadastros.Usuario
{
    partial class formDetalhesUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            dadosGeraisToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            btnSalvar = new Button();
            btnCancelar = new Button();
            label4 = new Label();
            cbCargo = new ComboBox();
            label3 = new Label();
            txtAtualizacao = new TextBox();
            label2 = new Label();
            txtCadastro = new TextBox();
            label1 = new Label();
            txtNome = new TextBox();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.Items.AddRange(new ToolStripItem[] { dadosGeraisToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(93, 209);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // dadosGeraisToolStripMenuItem
            // 
            dadosGeraisToolStripMenuItem.Name = "dadosGeraisToolStripMenuItem";
            dadosGeraisToolStripMenuItem.Size = new Size(80, 19);
            dadosGeraisToolStripMenuItem.Text = "Dados Gerais";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSalvar);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbCargo);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtAtualizacao);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtCadastro);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtNome);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(93, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(551, 209);
            panel1.TabIndex = 1;
            // 
            // btnSalvar
            // 
            btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvar.Location = new Point(457, 159);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 39);
            btnSalvar.TabIndex = 9;
            btnSalvar.Text = "SALVAR";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor = SystemColors.ButtonHighlight;
            btnCancelar.Location = new Point(376, 159);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 39);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 123);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 7;
            label4.Text = "Cargo: ";
            // 
            // cbCargo
            // 
            cbCargo.FormattingEnabled = true;
            cbCargo.Location = new Point(86, 120);
            cbCargo.Name = "cbCargo";
            cbCargo.Size = new Size(183, 23);
            cbCargo.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(285, 18);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 5;
            label3.Text = "Atualização: ";
            // 
            // txtAtualizacao
            // 
            txtAtualizacao.BackColor = SystemColors.Menu;
            txtAtualizacao.Location = new Point(365, 15);
            txtAtualizacao.Name = "txtAtualizacao";
            txtAtualizacao.ReadOnly = true;
            txtAtualizacao.Size = new Size(167, 23);
            txtAtualizacao.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 18);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 3;
            label2.Text = "Cadastro: ";
            // 
            // txtCadastro
            // 
            txtCadastro.BackColor = SystemColors.Menu;
            txtCadastro.Location = new Point(86, 15);
            txtCadastro.Name = "txtCadastro";
            txtCadastro.ReadOnly = true;
            txtCadastro.Size = new Size(167, 23);
            txtCadastro.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 69);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome: ";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(86, 66);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(272, 23);
            txtNome.TabIndex = 0;
            // 
            // formDetalhesCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 209);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimizeBox = false;
            Name = "formDetalhesUsuario";
            Text = "[NOVO]";
            Load += formDetalhesUsuario_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem dadosGeraisToolStripMenuItem;
        private Panel panel1;
        private Label label2;
        private TextBox txtCadastro;
        private Label label1;
        private TextBox txtNome;
        private Label label3;
        private TextBox txtAtualizacao;
        private Label label4;
        private ComboBox cbCargo;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}