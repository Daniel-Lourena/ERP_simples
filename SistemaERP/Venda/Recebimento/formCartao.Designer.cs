
namespace SistemaERP.Venda.Recebimento
{
    partial class formCartao
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
            lblCartao = new Label();
            txtObs = new TextBox();
            label1 = new Label();
            label2 = new Label();
            nudParcelas = new NumericUpDown();
            cbMaquininhas = new ComboBox();
            label3 = new Label();
            dgvParcelas = new DataGridView();
            btnCalcularParcelas = new Button();
            label9 = new Label();
            cbBandeiras = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudValor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudParcelas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvParcelas).BeginInit();
            SuspendLayout();
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(224, 345);
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
            lblValor.Location = new Point(106, 97);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(52, 15);
            lblValor.TabIndex = 19;
            lblValor.Text = "Valor R$:";
            // 
            // nudValor
            // 
            nudValor.DecimalPlaces = 2;
            nudValor.Location = new Point(106, 115);
            nudValor.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudValor.Name = "nudValor";
            nudValor.Size = new Size(69, 23);
            nudValor.TabIndex = 15;
            nudValor.TextAlign = HorizontalAlignment.Right;
            // 
            // lblCartao
            // 
            lblCartao.AutoSize = true;
            lblCartao.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCartao.Location = new Point(12, 9);
            lblCartao.Name = "lblCartao";
            lblCartao.Size = new Size(60, 21);
            lblCartao.TabIndex = 14;
            lblCartao.Text = "Cartão";
            // 
            // txtObs
            // 
            txtObs.Location = new Point(14, 327);
            txtObs.Multiline = true;
            txtObs.Name = "txtObs";
            txtObs.ScrollBars = ScrollBars.Vertical;
            txtObs.Size = new Size(185, 46);
            txtObs.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 309);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 21;
            label1.Text = "Obs:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 97);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 23;
            label2.Text = "Parcelas";
            // 
            // nudParcelas
            // 
            nudParcelas.Location = new Point(12, 115);
            nudParcelas.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudParcelas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudParcelas.Name = "nudParcelas";
            nudParcelas.Size = new Size(52, 23);
            nudParcelas.TabIndex = 22;
            nudParcelas.TextAlign = HorizontalAlignment.Right;
            nudParcelas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cbMaquininhas
            // 
            cbMaquininhas.FormattingEnabled = true;
            cbMaquininhas.Location = new Point(12, 63);
            cbMaquininhas.Name = "cbMaquininhas";
            cbMaquininhas.Size = new Size(163, 23);
            cbMaquininhas.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 45);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 25;
            label3.Text = "Maquininha";
            // 
            // dgvParcelas
            // 
            dgvParcelas.AllowUserToAddRows = false;
            dgvParcelas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParcelas.Location = new Point(12, 159);
            dgvParcelas.Name = "dgvParcelas";
            dgvParcelas.RowTemplate.Height = 25;
            dgvParcelas.ScrollBars = ScrollBars.Vertical;
            dgvParcelas.Size = new Size(288, 134);
            dgvParcelas.TabIndex = 34;
            // 
            // btnCalcularParcelas
            // 
            btnCalcularParcelas.Location = new Point(224, 110);
            btnCalcularParcelas.Name = "btnCalcularParcelas";
            btnCalcularParcelas.Size = new Size(76, 28);
            btnCalcularParcelas.TabIndex = 35;
            btnCalcularParcelas.Text = "Calcular";
            btnCalcularParcelas.UseVisualStyleBackColor = true;
            btnCalcularParcelas.Click += btnCalcularParcelas_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(181, 45);
            label9.Name = "label9";
            label9.Size = new Size(53, 15);
            label9.TabIndex = 37;
            label9.Text = "Bandeira";
            // 
            // cbBandeiras
            // 
            cbBandeiras.FormattingEnabled = true;
            cbBandeiras.Location = new Point(181, 63);
            cbBandeiras.Name = "cbBandeiras";
            cbBandeiras.Size = new Size(119, 23);
            cbBandeiras.TabIndex = 36;
            // 
            // formCartao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 390);
            Controls.Add(label9);
            Controls.Add(cbBandeiras);
            Controls.Add(btnCalcularParcelas);
            Controls.Add(dgvParcelas);
            Controls.Add(label3);
            Controls.Add(cbMaquininhas);
            Controls.Add(label2);
            Controls.Add(nudParcelas);
            Controls.Add(label1);
            Controls.Add(txtObs);
            Controls.Add(btnAdicionar);
            Controls.Add(lblValor);
            Controls.Add(nudValor);
            Controls.Add(lblCartao);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "formCartao";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Recebimento";
            Load += formCartao_Load;
            ((System.ComponentModel.ISupportInitialize)nudValor).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudParcelas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvParcelas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Button btnAdicionar;
        private Label lblValor;
        private NumericUpDown nudValor;
        private Label lblCartao;
        private TextBox txtObs;
        private Label label1;
        private Label label2;
        private NumericUpDown nudParcelas;
        private ComboBox cbMaquininhas;
        private Label label3;
        private DataGridView dgvParcelas;
        private Button btnCalcularParcelas;
        private Label label9;
        private ComboBox cbBandeiras;
    }
}