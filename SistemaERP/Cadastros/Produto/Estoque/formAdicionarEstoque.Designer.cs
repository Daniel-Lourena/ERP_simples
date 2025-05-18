namespace SistemaERP.Cadastros.Produto.Estoque
{
    partial class formAdicionarEstoque
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
            btnAdd = new Button();
            lblQtd = new Label();
            nudQtd = new NumericUpDown();
            lblProduto = new Label();
            label1 = new Label();
            cbProdutos = new ComboBox();
            cbSetores = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudQtd).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(316, 93);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(81, 32);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "ADICIONAR";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblQtd
            // 
            lblQtd.AutoSize = true;
            lblQtd.Location = new Point(297, 56);
            lblQtd.Name = "lblQtd";
            lblQtd.Size = new Size(30, 15);
            lblQtd.TabIndex = 19;
            lblQtd.Text = "Qtd:";
            // 
            // nudQtd
            // 
            nudQtd.DecimalPlaces = 2;
            nudQtd.Location = new Point(333, 54);
            nudQtd.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudQtd.Name = "nudQtd";
            nudQtd.Size = new Size(64, 23);
            nudQtd.TabIndex = 15;
            nudQtd.TextAlign = HorizontalAlignment.Right;
            // 
            // lblProduto
            // 
            lblProduto.AutoSize = true;
            lblProduto.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblProduto.Location = new Point(5, 29);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(72, 21);
            lblProduto.TabIndex = 14;
            lblProduto.Text = "Produto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(165, 29);
            label1.Name = "label1";
            label1.Size = new Size(115, 21);
            label1.TabIndex = 20;
            label1.Text = "Setor Estoque";
            // 
            // cbProdutos
            // 
            cbProdutos.FormattingEnabled = true;
            cbProdutos.Location = new Point(5, 53);
            cbProdutos.Name = "cbProdutos";
            cbProdutos.Size = new Size(154, 23);
            cbProdutos.TabIndex = 21;
            // 
            // cbSetores
            // 
            cbSetores.FormattingEnabled = true;
            cbSetores.Location = new Point(165, 53);
            cbSetores.Name = "cbSetores";
            cbSetores.Size = new Size(121, 23);
            cbSetores.TabIndex = 22;
            // 
            // formAdicionarEstoque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 137);
            Controls.Add(cbSetores);
            Controls.Add(cbProdutos);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Controls.Add(lblQtd);
            Controls.Add(nudQtd);
            Controls.Add(lblProduto);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "formAdicionarEstoque";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Incluir Estoque";
            ((System.ComponentModel.ISupportInitialize)nudQtd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Label lblQtd;
        private NumericUpDown nudQtd;
        private Label lblProduto;
        private Label label1;
        private ComboBox cbProdutos;
        private ComboBox cbSetores;
    }
}