namespace SistemaERP.Venda.Recebimento
{
    partial class formCheque
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
            cbBanco = new ComboBox();
            label3 = new Label();
            label8 = new Label();
            txtAgencia = new TextBox();
            label9 = new Label();
            txtContaCorrente = new TextBox();
            label10 = new Label();
            txtNroCheque = new TextBox();
            txtDigitoContaCorrente = new TextBox();
            txtDigitoAgencia = new TextBox();
            label2 = new Label();
            txtEmissor = new TextBox();
            dtpDataEmissao = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            dtpBomPara = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)nudValor).BeginInit();
            SuspendLayout();
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(289, 288);
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
            lblValor.Location = new Point(12, 295);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(52, 15);
            lblValor.TabIndex = 19;
            lblValor.Text = "Valor R$:";
            // 
            // nudValor
            // 
            nudValor.DecimalPlaces = 2;
            nudValor.Location = new Point(70, 293);
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
            label.Size = new Size(68, 21);
            label.TabIndex = 14;
            label.Text = "Cheque";
            // 
            // txtObs
            // 
            txtObs.Location = new Point(12, 236);
            txtObs.Multiline = true;
            txtObs.Name = "txtObs";
            txtObs.ScrollBars = ScrollBars.Vertical;
            txtObs.Size = new Size(353, 46);
            txtObs.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 218);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 21;
            label1.Text = "Obs:";
            // 
            // cbBanco
            // 
            cbBanco.FormattingEnabled = true;
            cbBanco.Location = new Point(12, 63);
            cbBanco.Name = "cbBanco";
            cbBanco.Size = new Size(142, 23);
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
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(120, 101);
            label8.Name = "label8";
            label8.Size = new Size(50, 15);
            label8.TabIndex = 33;
            label8.Text = "Agência";
            // 
            // txtAgencia
            // 
            txtAgencia.Location = new Point(120, 119);
            txtAgencia.Name = "txtAgencia";
            txtAgencia.ScrollBars = ScrollBars.Vertical;
            txtAgencia.Size = new Size(87, 23);
            txtAgencia.TabIndex = 32;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(255, 101);
            label9.Name = "label9";
            label9.Size = new Size(28, 15);
            label9.TabIndex = 35;
            label9.Text = "C/C";
            // 
            // txtContaCorrente
            // 
            txtContaCorrente.Location = new Point(255, 119);
            txtContaCorrente.Name = "txtContaCorrente";
            txtContaCorrente.ScrollBars = ScrollBars.Vertical;
            txtContaCorrente.Size = new Size(86, 23);
            txtContaCorrente.TabIndex = 34;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 101);
            label10.Name = "label10";
            label10.Size = new Size(65, 15);
            label10.TabIndex = 37;
            label10.Text = "N° Cheque";
            // 
            // txtNroCheque
            // 
            txtNroCheque.Location = new Point(12, 119);
            txtNroCheque.Name = "txtNroCheque";
            txtNroCheque.ScrollBars = ScrollBars.Vertical;
            txtNroCheque.Size = new Size(102, 23);
            txtNroCheque.TabIndex = 36;
            // 
            // txtDigitoContaCorrente
            // 
            txtDigitoContaCorrente.Location = new Point(347, 119);
            txtDigitoContaCorrente.Name = "txtDigitoContaCorrente";
            txtDigitoContaCorrente.ScrollBars = ScrollBars.Vertical;
            txtDigitoContaCorrente.Size = new Size(18, 23);
            txtDigitoContaCorrente.TabIndex = 38;
            // 
            // txtDigitoAgencia
            // 
            txtDigitoAgencia.Location = new Point(213, 119);
            txtDigitoAgencia.Name = "txtDigitoAgencia";
            txtDigitoAgencia.ScrollBars = ScrollBars.Vertical;
            txtDigitoAgencia.Size = new Size(18, 23);
            txtDigitoAgencia.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 162);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 42;
            label2.Text = "Nome Emissor";
            // 
            // txtEmissor
            // 
            txtEmissor.Location = new Point(12, 180);
            txtEmissor.Name = "txtEmissor";
            txtEmissor.ScrollBars = ScrollBars.Vertical;
            txtEmissor.Size = new Size(353, 23);
            txtEmissor.TabIndex = 41;
            // 
            // dtpDataEmissao
            // 
            dtpDataEmissao.Format = DateTimePickerFormat.Short;
            dtpDataEmissao.Location = new Point(165, 63);
            dtpDataEmissao.Name = "dtpDataEmissao";
            dtpDataEmissao.Size = new Size(97, 23);
            dtpDataEmissao.TabIndex = 43;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(165, 45);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 44;
            label4.Text = "Emissão";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(268, 45);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 46;
            label5.Text = "Bom para";
            // 
            // dtpBomPara
            // 
            dtpBomPara.Format = DateTimePickerFormat.Short;
            dtpBomPara.Location = new Point(268, 63);
            dtpBomPara.Name = "dtpBomPara";
            dtpBomPara.Size = new Size(97, 23);
            dtpBomPara.TabIndex = 45;
            // 
            // formCheque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 330);
            Controls.Add(label5);
            Controls.Add(dtpBomPara);
            Controls.Add(label4);
            Controls.Add(dtpDataEmissao);
            Controls.Add(label2);
            Controls.Add(txtEmissor);
            Controls.Add(txtDigitoAgencia);
            Controls.Add(txtDigitoContaCorrente);
            Controls.Add(label10);
            Controls.Add(txtNroCheque);
            Controls.Add(label9);
            Controls.Add(txtContaCorrente);
            Controls.Add(label8);
            Controls.Add(txtAgencia);
            Controls.Add(label3);
            Controls.Add(cbBanco);
            Controls.Add(label1);
            Controls.Add(txtObs);
            Controls.Add(btnAdicionar);
            Controls.Add(lblValor);
            Controls.Add(nudValor);
            Controls.Add(label);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "formCheque";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Recebimento";
            ((System.ComponentModel.ISupportInitialize)nudValor).EndInit();
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
        private ComboBox cbBanco;
        private Label label3;
        private Label label8;
        private TextBox txtAgencia;
        private Label label9;
        private TextBox txtContaCorrente;
        private Label label10;
        private TextBox txtNroCheque;
        private TextBox txtDigitoContaCorrente;
        private TextBox txtDigitoAgencia;
        private Label label2;
        private TextBox txtEmissor;
        private DateTimePicker dtpDataEmissao;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpBomPara;
    }
}