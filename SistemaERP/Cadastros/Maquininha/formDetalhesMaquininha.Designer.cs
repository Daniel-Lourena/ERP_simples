namespace SistemaERP.Cadastros.Maquininha
{
    partial class formDetalhesMaquininha
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
            btnSalvar = new Button();
            btnCancelar = new Button();
            tpDadosGerais = new TabPage();
            label1 = new Label();
            cbTipoMaquininha = new ComboBox();
            ckInativo = new CheckBox();
            txtNome = new TextBox();
            label14 = new Label();
            label4 = new Label();
            cbAdquirente = new ComboBox();
            tcMaquininha = new TabControl();
            tpDadosGerais.SuspendLayout();
            tcMaquininha.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalvar
            // 
            btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvar.Location = new Point(199, 189);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 39);
            btnSalvar.TabIndex = 35;
            btnSalvar.Text = "SALVAR";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor = SystemColors.ButtonHighlight;
            btnCancelar.Location = new Point(118, 189);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 39);
            btnCancelar.TabIndex = 34;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // tpDadosGerais
            // 
            tpDadosGerais.Controls.Add(label1);
            tpDadosGerais.Controls.Add(cbTipoMaquininha);
            tpDadosGerais.Controls.Add(btnSalvar);
            tpDadosGerais.Controls.Add(btnCancelar);
            tpDadosGerais.Controls.Add(ckInativo);
            tpDadosGerais.Controls.Add(txtNome);
            tpDadosGerais.Controls.Add(label14);
            tpDadosGerais.Controls.Add(label4);
            tpDadosGerais.Controls.Add(cbAdquirente);
            tpDadosGerais.Location = new Point(104, 4);
            tpDadosGerais.Name = "tpDadosGerais";
            tpDadosGerais.Padding = new Padding(3);
            tpDadosGerais.Size = new Size(278, 234);
            tpDadosGerais.TabIndex = 0;
            tpDadosGerais.Text = "Dados Gerais";
            tpDadosGerais.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 118);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 46;
            label1.Text = "Tipo:";
            // 
            // cbTipoMaquininha
            // 
            cbTipoMaquininha.FormattingEnabled = true;
            cbTipoMaquininha.Location = new Point(6, 136);
            cbTipoMaquininha.Name = "cbTipoMaquininha";
            cbTipoMaquininha.Size = new Size(69, 23);
            cbTipoMaquininha.TabIndex = 45;
            // 
            // ckInativo
            // 
            ckInativo.AutoSize = true;
            ckInativo.Location = new Point(199, 89);
            ckInativo.Name = "ckInativo";
            ckInativo.Size = new Size(62, 19);
            ckInativo.TabIndex = 44;
            ckInativo.Text = "Inativo";
            ckInativo.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(6, 40);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(255, 23);
            txtNome.TabIndex = 36;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 22);
            label14.Name = "label14";
            label14.Size = new Size(43, 15);
            label14.TabIndex = 37;
            label14.Text = "Nome:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 67);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 17;
            label4.Text = "Adquirente:";
            // 
            // cbAdquirente
            // 
            cbAdquirente.FormattingEnabled = true;
            cbAdquirente.Location = new Point(6, 85);
            cbAdquirente.Name = "cbAdquirente";
            cbAdquirente.Size = new Size(183, 23);
            cbAdquirente.TabIndex = 16;
            // 
            // tcBanco
            // 
            tcMaquininha.Alignment = TabAlignment.Left;
            tcMaquininha.Controls.Add(tpDadosGerais);
            tcMaquininha.Dock = DockStyle.Fill;
            tcMaquininha.DrawMode = TabDrawMode.OwnerDrawFixed;
            tcMaquininha.ItemSize = new Size(30, 100);
            tcMaquininha.Location = new Point(0, 0);
            tcMaquininha.Multiline = true;
            tcMaquininha.Name = "tcMaquininha";
            tcMaquininha.SelectedIndex = 0;
            tcMaquininha.Size = new Size(386, 242);
            tcMaquininha.SizeMode = TabSizeMode.Fixed;
            tcMaquininha.TabIndex = 0;
            tcMaquininha.DrawItem += tcMaquininha_DrawItem;
            // 
            // formDetalhesMaquininha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 242);
            Controls.Add(tcMaquininha);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "formDetalhesMaquininha";
            StartPosition = FormStartPosition.CenterParent;
            Text = "[NOVO]";
            Load += formDetalhesMaquininha_Load;
            tpDadosGerais.ResumeLayout(false);
            tpDadosGerais.PerformLayout();
            tcMaquininha.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnSalvar;
        private Button btnCancelar;
        private TabPage tpDadosGerais;
        private CheckBox ckInativo;
        private TextBox txtNome;
        private Label label14;
        private Label label4;
        private ComboBox cbAdquirente;
        private TabControl tcMaquininha;
        private Label label1;
        private ComboBox cbTipoMaquininha;
    }
}