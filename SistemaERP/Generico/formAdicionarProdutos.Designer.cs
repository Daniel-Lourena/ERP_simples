namespace SistemaERP.Generico
{
    partial class formAdicionarProdutosPedido
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
            btnAdd = new Button();
            panelProduto = new Panel();
            txtSaldo = new TextBox();
            txtPedido = new TextBox();
            txtEstoque = new TextBox();
            lblQtd = new Label();
            lblSaldo = new Label();
            lblPedido = new Label();
            lblEstoque = new Label();
            nudQtd = new NumericUpDown();
            lblProduto = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            panelProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQtd).BeginInit();
            SuspendLayout();
            // 
            // dgvProdutos
            // 
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.AllowUserToDeleteRows = false;
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Dock = DockStyle.Fill;
            dgvProdutos.Location = new Point(0, 0);
            dgvProdutos.MultiSelect = false;
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.ReadOnly = true;
            dgvProdutos.RowTemplate.Height = 25;
            dgvProdutos.Size = new Size(681, 263);
            dgvProdutos.TabIndex = 0;
            dgvProdutos.DoubleClick += dgvProdutos_DoubleClick;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 263);
            panel1.Name = "panel1";
            panel1.Size = new Size(681, 71);
            panel1.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(41, 203);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(81, 32);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "ADICIONAR";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // panelProduto
            // 
            panelProduto.Controls.Add(btnAdd);
            panelProduto.Controls.Add(txtSaldo);
            panelProduto.Controls.Add(txtPedido);
            panelProduto.Controls.Add(txtEstoque);
            panelProduto.Controls.Add(lblQtd);
            panelProduto.Controls.Add(lblSaldo);
            panelProduto.Controls.Add(lblPedido);
            panelProduto.Controls.Add(lblEstoque);
            panelProduto.Controls.Add(nudQtd);
            panelProduto.Controls.Add(lblProduto);
            panelProduto.Location = new Point(253, 12);
            panelProduto.Name = "panelProduto";
            panelProduto.Size = new Size(168, 245);
            panelProduto.TabIndex = 2;
            panelProduto.Visible = false;
            // 
            // txtSaldo
            // 
            txtSaldo.Location = new Point(72, 120);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.ReadOnly = true;
            txtSaldo.Size = new Size(62, 23);
            txtSaldo.TabIndex = 12;
            // 
            // txtPedido
            // 
            txtPedido.Location = new Point(72, 91);
            txtPedido.Name = "txtPedido";
            txtPedido.ReadOnly = true;
            txtPedido.Size = new Size(62, 23);
            txtPedido.TabIndex = 11;
            // 
            // txtEstoque
            // 
            txtEstoque.Location = new Point(72, 63);
            txtEstoque.Name = "txtEstoque";
            txtEstoque.ReadOnly = true;
            txtEstoque.Size = new Size(62, 23);
            txtEstoque.TabIndex = 10;
            // 
            // lblQtd
            // 
            lblQtd.AutoSize = true;
            lblQtd.Location = new Point(34, 165);
            lblQtd.Name = "lblQtd";
            lblQtd.Size = new Size(30, 15);
            lblQtd.TabIndex = 9;
            lblQtd.Text = "Qtd:";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(14, 123);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(39, 15);
            lblSaldo.TabIndex = 8;
            lblSaldo.Text = "Saldo:";
            // 
            // lblPedido
            // 
            lblPedido.AutoSize = true;
            lblPedido.Location = new Point(14, 94);
            lblPedido.Name = "lblPedido";
            lblPedido.Size = new Size(47, 15);
            lblPedido.TabIndex = 7;
            lblPedido.Text = "Pedido:";
            // 
            // lblEstoque
            // 
            lblEstoque.AutoSize = true;
            lblEstoque.Location = new Point(14, 66);
            lblEstoque.Name = "lblEstoque";
            lblEstoque.Size = new Size(52, 15);
            lblEstoque.TabIndex = 6;
            lblEstoque.Text = "Estoque:";
            // 
            // nudQtd
            // 
            nudQtd.DecimalPlaces = 2;
            nudQtd.Location = new Point(70, 163);
            nudQtd.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudQtd.Name = "nudQtd";
            nudQtd.Size = new Size(64, 23);
            nudQtd.TabIndex = 5;
            nudQtd.TextAlign = HorizontalAlignment.Right;
            // 
            // lblProduto
            // 
            lblProduto.AutoSize = true;
            lblProduto.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblProduto.Location = new Point(41, 24);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(72, 21);
            lblProduto.TabIndex = 4;
            lblProduto.Text = "Produto";
            // 
            // formAdicionarProdutosPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 334);
            Controls.Add(panelProduto);
            Controls.Add(dgvProdutos);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "formAdicionarProdutosPedido";
            Text = "formAdicionarProdutos";
            KeyDown += formAdicionarProdutos_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            panelProduto.ResumeLayout(false);
            panelProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQtd).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProdutos;
        private Panel panel1;
        private Button btnAdd;
        private Panel panelProduto;
        private NumericUpDown nudQtd;
        private Label lblProduto;
        private TextBox txtSaldo;
        private TextBox txtPedido;
        private TextBox txtEstoque;
        private Label lblQtd;
        private Label lblSaldo;
        private Label lblPedido;
        private Label lblEstoque;
    }
}