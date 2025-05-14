namespace SistemaERP.Cadastros.Produto.Estoque
{
    partial class formModificarEstoque
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
            btnModificar = new Button();
            txtSaldo = new TextBox();
            txtPedido = new TextBox();
            txtEstoque = new TextBox();
            lblQtd = new Label();
            lblSaldo = new Label();
            lblPedido = new Label();
            lblEstoque = new Label();
            nudQtd = new NumericUpDown();
            lblProduto = new Label();
            ((System.ComponentModel.ISupportInitialize)nudQtd).BeginInit();
            SuspendLayout();
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(72, 207);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(81, 32);
            btnModificar.TabIndex = 13;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // txtSaldo
            // 
            txtSaldo.Location = new Point(107, 124);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.ReadOnly = true;
            txtSaldo.Size = new Size(62, 23);
            txtSaldo.TabIndex = 22;
            // 
            // txtPedido
            // 
            txtPedido.Location = new Point(107, 95);
            txtPedido.Name = "txtPedido";
            txtPedido.ReadOnly = true;
            txtPedido.Size = new Size(62, 23);
            txtPedido.TabIndex = 21;
            // 
            // txtEstoque
            // 
            txtEstoque.Location = new Point(107, 67);
            txtEstoque.Name = "txtEstoque";
            txtEstoque.ReadOnly = true;
            txtEstoque.Size = new Size(62, 23);
            txtEstoque.TabIndex = 20;
            // 
            // lblQtd
            // 
            lblQtd.AutoSize = true;
            lblQtd.Location = new Point(69, 169);
            lblQtd.Name = "lblQtd";
            lblQtd.Size = new Size(30, 15);
            lblQtd.TabIndex = 19;
            lblQtd.Text = "Qtd:";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(49, 127);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(39, 15);
            lblSaldo.TabIndex = 18;
            lblSaldo.Text = "Saldo:";
            // 
            // lblPedido
            // 
            lblPedido.AutoSize = true;
            lblPedido.Location = new Point(49, 98);
            lblPedido.Name = "lblPedido";
            lblPedido.Size = new Size(47, 15);
            lblPedido.TabIndex = 17;
            lblPedido.Text = "Pedido:";
            // 
            // lblEstoque
            // 
            lblEstoque.AutoSize = true;
            lblEstoque.Location = new Point(49, 70);
            lblEstoque.Name = "lblEstoque";
            lblEstoque.Size = new Size(52, 15);
            lblEstoque.TabIndex = 16;
            lblEstoque.Text = "Estoque:";
            // 
            // nudQtd
            // 
            nudQtd.DecimalPlaces = 2;
            nudQtd.Location = new Point(105, 167);
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
            lblProduto.Location = new Point(76, 28);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(72, 21);
            lblProduto.TabIndex = 14;
            lblProduto.Text = "Produto";
            // 
            // formModificarEstoque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(217, 262);
            Controls.Add(btnModificar);
            Controls.Add(txtSaldo);
            Controls.Add(txtPedido);
            Controls.Add(txtEstoque);
            Controls.Add(lblQtd);
            Controls.Add(lblSaldo);
            Controls.Add(lblPedido);
            Controls.Add(lblEstoque);
            Controls.Add(nudQtd);
            Controls.Add(lblProduto);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "formModificarEstoque";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modificar Estoque";
            Load += formModificarEstoque_Load;
            ((System.ComponentModel.ISupportInitialize)nudQtd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnModificar;
        private TextBox txtSaldo;
        private TextBox txtPedido;
        private TextBox txtEstoque;
        private Label lblQtd;
        private Label lblSaldo;
        private Label lblPedido;
        private Label lblEstoque;
        private NumericUpDown nudQtd;
        private Label lblProduto;
    }
}