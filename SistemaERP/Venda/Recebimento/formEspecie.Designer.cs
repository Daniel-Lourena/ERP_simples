
namespace SistemaERP.Venda.Recebimento
{
    partial class formEspecie
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
            lblEspecie = new Label();
            txtObs = new TextBox();
            label1 = new Label();
            cbTipoTransferencia = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudValor).BeginInit();
            SuspendLayout();
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(226, 120);
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
            lblValor.Location = new Point(12, 127);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(52, 15);
            lblValor.TabIndex = 19;
            lblValor.Text = "Valor R$:";
            // 
            // nudValor
            // 
            nudValor.DecimalPlaces = 2;
            nudValor.Location = new Point(70, 125);
            nudValor.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudValor.Name = "nudValor";
            nudValor.Size = new Size(69, 23);
            nudValor.TabIndex = 15;
            nudValor.TextAlign = HorizontalAlignment.Right;
            // 
            // lblEspecie
            // 
            lblEspecie.AutoSize = true;
            lblEspecie.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblEspecie.Location = new Point(12, 9);
            lblEspecie.Name = "lblEspecie";
            lblEspecie.Size = new Size(71, 21);
            lblEspecie.TabIndex = 14;
            lblEspecie.Text = "ESPÉCIE";
            // 
            // txtObs
            // 
            txtObs.Location = new Point(12, 68);
            txtObs.Multiline = true;
            txtObs.Name = "txtObs";
            txtObs.ScrollBars = ScrollBars.Vertical;
            txtObs.Size = new Size(290, 46);
            txtObs.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 50);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 21;
            label1.Text = "Obs:";
            // 
            // cbTipoTransferencia
            // 
            cbTipoTransferencia.FormattingEnabled = true;
            cbTipoTransferencia.Location = new Point(181, 8);
            cbTipoTransferencia.Name = "cbTipoTransferencia";
            cbTipoTransferencia.Size = new Size(121, 23);
            cbTipoTransferencia.TabIndex = 22;
            // 
            // formEspecie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 161);
            Controls.Add(cbTipoTransferencia);
            Controls.Add(label1);
            Controls.Add(txtObs);
            Controls.Add(btnAdicionar);
            Controls.Add(lblValor);
            Controls.Add(nudValor);
            Controls.Add(lblEspecie);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "formEspecie";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Recebimento";
            Load += formEspecie_Load;
            ((System.ComponentModel.ISupportInitialize)nudValor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Button btnAdicionar;
        private Label lblValor;
        private NumericUpDown nudValor;
        private Label lblEspecie;
        private TextBox txtObs;
        private Label label1;
        private ComboBox cbTipoTransferencia;
    }
}