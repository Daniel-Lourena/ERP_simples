namespace SistemaERP.Cadastros.Produto.Estoque
{
    partial class formGerenciar
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
            dgvProdutos = new DataGridView();
            panel1 = new Panel();
            ckeOcultaInativos = new CheckBox();
            panel2 = new Panel();
            btnSubtrair = new Button();
            btnAdicionar = new Button();
            btnTransferir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.AllowUserToDeleteRows = false;
            dgvProdutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProdutos.BackgroundColor = SystemColors.ActiveBorder;
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Location = new Point(12, 83);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.ReadOnly = true;
            dgvProdutos.RowTemplate.Height = 25;
            dgvProdutos.Size = new Size(776, 285);
            dgvProdutos.TabIndex = 0;
            dgvProdutos.RowPrePaint += dgvProdutos_RowPrePaint;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(ckeOcultaInativos);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 65);
            panel1.TabIndex = 1;
            // 
            // ckeOcultaInativos
            // 
            ckeOcultaInativos.AutoSize = true;
            ckeOcultaInativos.Checked = true;
            ckeOcultaInativos.CheckState = CheckState.Checked;
            ckeOcultaInativos.Location = new Point(3, 3);
            ckeOcultaInativos.Name = "ckeOcultaInativos";
            ckeOcultaInativos.Size = new Size(162, 19);
            ckeOcultaInativos.TabIndex = 2;
            ckeOcultaInativos.Text = "Ocultar cadastros inativos";
            ckeOcultaInativos.UseVisualStyleBackColor = true;
            ckeOcultaInativos.CheckedChanged += ckeOcultaInativos_CheckedChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(btnTransferir);
            panel2.Controls.Add(btnSubtrair);
            panel2.Controls.Add(btnAdicionar);
            panel2.Location = new Point(12, 373);
            panel2.Name = "panel2";
            panel2.Size = new Size(776, 65);
            panel2.TabIndex = 2;
            // 
            // btnSubtrair
            // 
            btnSubtrair.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSubtrair.BackColor = Color.IndianRed;
            btnSubtrair.FlatAppearance.BorderColor = Color.Black;
            btnSubtrair.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSubtrair.ForeColor = SystemColors.ButtonHighlight;
            btnSubtrair.Location = new Point(120, 12);
            btnSubtrair.Name = "btnSubtrair";
            btnSubtrair.Size = new Size(104, 44);
            btnSubtrair.TabIndex = 1;
            btnSubtrair.Text = "SUBTRAIR";
            btnSubtrair.UseVisualStyleBackColor = false;
            btnSubtrair.Click += btnEditar_Click;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdicionar.BackColor = SystemColors.ActiveCaption;
            btnAdicionar.FlatAppearance.BorderColor = Color.Black;
            btnAdicionar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdicionar.ForeColor = SystemColors.ButtonHighlight;
            btnAdicionar.Location = new Point(12, 12);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(102, 44);
            btnAdicionar.TabIndex = 0;
            btnAdicionar.Text = "ADICIONAR";
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.Click += btnNovo_Click;
            // 
            // btnTransferir
            // 
            btnTransferir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnTransferir.BackColor = Color.YellowGreen;
            btnTransferir.FlatAppearance.BorderColor = Color.Black;
            btnTransferir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnTransferir.ForeColor = SystemColors.ButtonHighlight;
            btnTransferir.Location = new Point(230, 12);
            btnTransferir.Name = "btnTransferir";
            btnTransferir.Size = new Size(104, 44);
            btnTransferir.TabIndex = 2;
            btnTransferir.Text = "TRANSFERIR";
            btnTransferir.UseVisualStyleBackColor = false;
            // 
            // formGerenciar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dgvProdutos);
            Name = "formGerenciar";
            Text = "Gerenciar Produtos";
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProdutos;
        private Panel panel1;
        private Panel panel2;
        private Button btnAdicionar;
        private Button btnSubtrair;
        private CheckBox ckeOcultaInativos;
        private Button btnTransferir;
    }
}