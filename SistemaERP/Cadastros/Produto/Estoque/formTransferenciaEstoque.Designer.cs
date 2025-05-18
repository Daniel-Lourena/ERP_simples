namespace SistemaERP.Cadastros.Produto.Estoque
{
    partial class formTransferenciaEstoque
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
            btnTransferir = new Button();
            lblQtd = new Label();
            nudQtd = new NumericUpDown();
            label1 = new Label();
            cbSetorDestino = new ComboBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            txtSetorOrigem = new TextBox();
            txtSaldo = new TextBox();
            label3 = new Label();
            label4 = new Label();
            lblProduto = new Label();
            txtProduto = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudQtd).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnTransferir
            // 
            btnTransferir.Location = new Point(176, 295);
            btnTransferir.Name = "btnTransferir";
            btnTransferir.Size = new Size(81, 32);
            btnTransferir.TabIndex = 13;
            btnTransferir.Text = "TRANSFERIR";
            btnTransferir.UseVisualStyleBackColor = true;
            btnTransferir.Click += btnTransferir_Click;
            // 
            // lblQtd
            // 
            lblQtd.AutoSize = true;
            lblQtd.Location = new Point(162, 39);
            lblQtd.Name = "lblQtd";
            lblQtd.Size = new Size(30, 15);
            lblQtd.TabIndex = 19;
            lblQtd.Text = "Qtd:";
            // 
            // nudQtd
            // 
            nudQtd.DecimalPlaces = 2;
            nudQtd.Location = new Point(162, 59);
            nudQtd.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudQtd.Name = "nudQtd";
            nudQtd.Size = new Size(64, 23);
            nudQtd.TabIndex = 15;
            nudQtd.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(17, 34);
            label1.Name = "label1";
            label1.Size = new Size(115, 21);
            label1.TabIndex = 20;
            label1.Text = "Setor Estoque";
            // 
            // cbSetorDestino
            // 
            cbSetorDestino.FormattingEnabled = true;
            cbSetorDestino.Location = new Point(17, 58);
            cbSetorDestino.Name = "cbSetorDestino";
            cbSetorDestino.Size = new Size(121, 23);
            cbSetorDestino.TabIndex = 22;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbSetorDestino);
            groupBox1.Controls.Add(nudQtd);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblQtd);
            groupBox1.Location = new Point(14, 182);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(243, 100);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Destino";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSetorOrigem);
            groupBox2.Controls.Add(txtSaldo);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(12, 76);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(245, 100);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            groupBox2.Text = "Origem";
            // 
            // txtSetorOrigem
            // 
            txtSetorOrigem.Location = new Point(19, 56);
            txtSetorOrigem.Name = "txtSetorOrigem";
            txtSetorOrigem.ReadOnly = true;
            txtSetorOrigem.Size = new Size(121, 23);
            txtSetorOrigem.TabIndex = 24;
            // 
            // txtSaldo
            // 
            txtSaldo.Location = new Point(164, 55);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.ReadOnly = true;
            txtSaldo.Size = new Size(64, 23);
            txtSaldo.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(19, 32);
            label3.Name = "label3";
            label3.Size = new Size(115, 21);
            label3.TabIndex = 20;
            label3.Text = "Setor Estoque";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(164, 37);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 19;
            label4.Text = "Saldo";
            // 
            // lblProduto
            // 
            lblProduto.AutoSize = true;
            lblProduto.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblProduto.Location = new Point(14, 9);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(72, 21);
            lblProduto.TabIndex = 25;
            lblProduto.Text = "Produto";
            // 
            // txtProduto
            // 
            txtProduto.Location = new Point(14, 33);
            txtProduto.Name = "txtProduto";
            txtProduto.ReadOnly = true;
            txtProduto.Size = new Size(243, 23);
            txtProduto.TabIndex = 25;
            // 
            // formTransferenciaEstoque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(269, 339);
            Controls.Add(txtProduto);
            Controls.Add(lblProduto);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnTransferir);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "formTransferenciaEstoque";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Transferência de Estoque";
            ((System.ComponentModel.ISupportInitialize)nudQtd).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTransferir;
        private Label lblQtd;
        private NumericUpDown nudQtd;
        private Label label1;
        private ComboBox cbSetorDestino;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label3;
        private Label label4;
        private TextBox txtSaldo;
        private TextBox txtSetorOrigem;
        private Label lblProduto;
        private TextBox txtProduto;
    }
}