namespace SistemaERP.Venda.Recebimento
{
    partial class formBoleto
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
            btnAdicionar = new Button();
            lblValor = new Label();
            nudValor = new NumericUpDown();
            label = new Label();
            txtObs = new TextBox();
            label1 = new Label();
            label2 = new Label();
            nudParcelas = new NumericUpDown();
            cbBanco = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            nudPrimeiraParcela = new NumericUpDown();
            label5 = new Label();
            nudDemaisParcelas = new NumericUpDown();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudValor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudParcelas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrimeiraParcela).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDemaisParcelas).BeginInit();
            SuspendLayout();
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(167, 221);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(76, 28);
            btnAdicionar.TabIndex = 13;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(12, 228);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(52, 15);
            lblValor.TabIndex = 19;
            lblValor.Text = "Valor R$:";
            // 
            // nudValor
            // 
            nudValor.DecimalPlaces = 2;
            nudValor.Location = new Point(70, 226);
            nudValor.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudValor.Name = "nudValor";
            nudValor.Size = new Size(69, 23);
            nudValor.TabIndex = 15;
            nudValor.TextAlign = HorizontalAlignment.Right;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label.Location = new Point(12, 9);
            label.Name = "label";
            label.Size = new Size(60, 21);
            label.TabIndex = 14;
            label.Text = "Boleto";
            // 
            // txtObs
            // 
            txtObs.Location = new Point(12, 169);
            txtObs.Multiline = true;
            txtObs.Name = "txtObs";
            txtObs.ScrollBars = ScrollBars.Vertical;
            txtObs.Size = new Size(229, 46);
            txtObs.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 151);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 21;
            label1.Text = "Obs:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(191, 45);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 23;
            label2.Text = "Parcelas";
            // 
            // nudParcelas
            // 
            nudParcelas.Location = new Point(191, 63);
            nudParcelas.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudParcelas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudParcelas.Name = "nudParcelas";
            nudParcelas.Size = new Size(52, 23);
            nudParcelas.TabIndex = 22;
            nudParcelas.TextAlign = HorizontalAlignment.Right;
            nudParcelas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudParcelas.ValueChanged += nudParcelas_ValueChanged;
            // 
            // cbBanco
            // 
            cbBanco.FormattingEnabled = true;
            cbBanco.Location = new Point(12, 63);
            cbBanco.Name = "cbBanco";
            cbBanco.Size = new Size(173, 23);
            cbBanco.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 45);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 25;
            label3.Text = "Banco";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 96);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 27;
            label4.Text = "Primeira parcela:";
            // 
            // nudPrimeiraParcela
            // 
            nudPrimeiraParcela.Location = new Point(12, 114);
            nudPrimeiraParcela.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudPrimeiraParcela.Name = "nudPrimeiraParcela";
            nudPrimeiraParcela.Size = new Size(52, 23);
            nudPrimeiraParcela.TabIndex = 26;
            nudPrimeiraParcela.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(133, 96);
            label5.Name = "label5";
            label5.Size = new Size(95, 15);
            label5.TabIndex = 29;
            label5.Text = "Demais parcelas:";
            // 
            // nudDemaisParcelas
            // 
            nudDemaisParcelas.Enabled = false;
            nudDemaisParcelas.Location = new Point(133, 114);
            nudDemaisParcelas.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudDemaisParcelas.Name = "nudDemaisParcelas";
            nudDemaisParcelas.Size = new Size(52, 23);
            nudDemaisParcelas.TabIndex = 28;
            nudDemaisParcelas.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(70, 122);
            label6.Name = "label6";
            label6.Size = new Size(28, 15);
            label6.TabIndex = 30;
            label6.Text = "dias";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(191, 122);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 31;
            label7.Text = "dias";
            // 
            // formBoleto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(254, 264);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(nudDemaisParcelas);
            Controls.Add(label4);
            Controls.Add(nudPrimeiraParcela);
            Controls.Add(label3);
            Controls.Add(cbBanco);
            Controls.Add(label2);
            Controls.Add(nudParcelas);
            Controls.Add(label1);
            Controls.Add(txtObs);
            Controls.Add(btnAdicionar);
            Controls.Add(lblValor);
            Controls.Add(nudValor);
            Controls.Add(label);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "formBoleto";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Recebimento";
            ((System.ComponentModel.ISupportInitialize)nudValor).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudParcelas).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrimeiraParcela).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDemaisParcelas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdicionar;
        private Label lblValor;
        private NumericUpDown nudValor;
        private Label label;
        private TextBox txtObs;
        private Label label1;
        private Label label2;
        private NumericUpDown nudParcelas;
        private ComboBox cbBanco;
        private Label label3;
        private Label label4;
        private NumericUpDown nudPrimeiraParcela;
        private Label label5;
        private NumericUpDown nudDemaisParcelas;
        private Label label6;
        private Label label7;
    }
}