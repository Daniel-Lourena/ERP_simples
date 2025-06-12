
namespace SistemaERP.Cadastros.Adquirente
{
    partial class formDetalhesAdquirente
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
            label2 = new Label();
            cbAdquirente = new ComboBox();
            txtCnpj = new TextBox();
            label1 = new Label();
            txtNome = new TextBox();
            label14 = new Label();
            tcAdquirente = new TabControl();
            tpTaxas = new TabPage();
            label5 = new Label();
            nudTaxaAntecipacao = new NumericUpDown();
            label4 = new Label();
            nudTaxaCreditoParcelado = new NumericUpDown();
            label3 = new Label();
            nudTaxaCreditoAVista = new NumericUpDown();
            lblValor = new Label();
            nudTaxaDebito = new NumericUpDown();
            label6 = new Label();
            nudParcelas = new NumericUpDown();
            tpDadosGerais.SuspendLayout();
            tcAdquirente.SuspendLayout();
            tpTaxas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTaxaAntecipacao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTaxaCreditoParcelado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTaxaCreditoAVista).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTaxaDebito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudParcelas).BeginInit();
            SuspendLayout();
            // 
            // btnSalvar
            // 
            btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvar.Location = new Point(341, 248);
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
            btnCancelar.Location = new Point(260, 248);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 39);
            btnCancelar.TabIndex = 34;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // tpDadosGerais
            // 
            tpDadosGerais.Controls.Add(label2);
            tpDadosGerais.Controls.Add(cbAdquirente);
            tpDadosGerais.Controls.Add(txtCnpj);
            tpDadosGerais.Controls.Add(label1);
            tpDadosGerais.Controls.Add(txtNome);
            tpDadosGerais.Controls.Add(label14);
            tpDadosGerais.Location = new Point(104, 4);
            tpDadosGerais.Name = "tpDadosGerais";
            tpDadosGerais.Padding = new Padding(3);
            tpDadosGerais.Size = new Size(315, 234);
            tpDadosGerais.TabIndex = 0;
            tpDadosGerais.Text = "Dados Gerais";
            tpDadosGerais.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 7);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 41;
            label2.Text = "Adquirente:";
            // 
            // cbAdquirente
            // 
            cbAdquirente.FormattingEnabled = true;
            cbAdquirente.Location = new Point(6, 25);
            cbAdquirente.Name = "cbAdquirente";
            cbAdquirente.Size = new Size(121, 23);
            cbAdquirente.TabIndex = 40;
            // 
            // txtCnpj
            // 
            txtCnpj.Location = new Point(6, 130);
            txtCnpj.Name = "txtCnpj";
            txtCnpj.ReadOnly = true;
            txtCnpj.Size = new Size(187, 23);
            txtCnpj.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 112);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 39;
            label1.Text = "CNPJ:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(6, 82);
            txtNome.Name = "txtNome";
            txtNome.ReadOnly = true;
            txtNome.Size = new Size(299, 23);
            txtNome.TabIndex = 36;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 64);
            label14.Name = "label14";
            label14.Size = new Size(43, 15);
            label14.TabIndex = 37;
            label14.Text = "Nome:";
            // 
            // tcAdquirente
            // 
            tcAdquirente.Alignment = TabAlignment.Left;
            tcAdquirente.Controls.Add(tpDadosGerais);
            tcAdquirente.Controls.Add(tpTaxas);
            tcAdquirente.DrawMode = TabDrawMode.OwnerDrawFixed;
            tcAdquirente.ItemSize = new Size(30, 100);
            tcAdquirente.Location = new Point(0, 0);
            tcAdquirente.Multiline = true;
            tcAdquirente.Name = "tcAdquirente";
            tcAdquirente.SelectedIndex = 0;
            tcAdquirente.Size = new Size(423, 242);
            tcAdquirente.SizeMode = TabSizeMode.Fixed;
            tcAdquirente.TabIndex = 0;
            tcAdquirente.DrawItem += tcAdquirente_DrawItem;
            // 
            // tpTaxas
            // 
            tpTaxas.Controls.Add(label6);
            tpTaxas.Controls.Add(nudParcelas);
            tpTaxas.Controls.Add(label5);
            tpTaxas.Controls.Add(nudTaxaAntecipacao);
            tpTaxas.Controls.Add(label4);
            tpTaxas.Controls.Add(nudTaxaCreditoParcelado);
            tpTaxas.Controls.Add(label3);
            tpTaxas.Controls.Add(nudTaxaCreditoAVista);
            tpTaxas.Controls.Add(lblValor);
            tpTaxas.Controls.Add(nudTaxaDebito);
            tpTaxas.Location = new Point(104, 4);
            tpTaxas.Name = "tpTaxas";
            tpTaxas.Padding = new Padding(3);
            tpTaxas.Size = new Size(315, 234);
            tpTaxas.TabIndex = 1;
            tpTaxas.Text = "Taxas";
            tpTaxas.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 162);
            label5.Name = "label5";
            label5.Size = new Size(110, 15);
            label5.TabIndex = 27;
            label5.Text = "% Taxa antecipação";
            // 
            // nudTaxaAntecipacao
            // 
            nudTaxaAntecipacao.DecimalPlaces = 2;
            nudTaxaAntecipacao.Location = new Point(6, 180);
            nudTaxaAntecipacao.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudTaxaAntecipacao.Name = "nudTaxaAntecipacao";
            nudTaxaAntecipacao.Size = new Size(69, 23);
            nudTaxaAntecipacao.TabIndex = 26;
            nudTaxaAntecipacao.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 111);
            label4.Name = "label4";
            label4.Size = new Size(138, 15);
            label4.TabIndex = 25;
            label4.Text = "% Taxa crédito parcelado";
            // 
            // nudTaxaCreditoParcelado
            // 
            nudTaxaCreditoParcelado.DecimalPlaces = 2;
            nudTaxaCreditoParcelado.Location = new Point(6, 129);
            nudTaxaCreditoParcelado.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudTaxaCreditoParcelado.Name = "nudTaxaCreditoParcelado";
            nudTaxaCreditoParcelado.Size = new Size(69, 23);
            nudTaxaCreditoParcelado.TabIndex = 24;
            nudTaxaCreditoParcelado.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 59);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 23;
            label3.Text = "% Taxa crédito a vista";
            // 
            // nudTaxaCreditoAVista
            // 
            nudTaxaCreditoAVista.DecimalPlaces = 2;
            nudTaxaCreditoAVista.Location = new Point(6, 77);
            nudTaxaCreditoAVista.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudTaxaCreditoAVista.Name = "nudTaxaCreditoAVista";
            nudTaxaCreditoAVista.Size = new Size(69, 23);
            nudTaxaCreditoAVista.TabIndex = 22;
            nudTaxaCreditoAVista.TextAlign = HorizontalAlignment.Right;
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(6, 8);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(80, 15);
            lblValor.TabIndex = 21;
            lblValor.Text = "% Taxa débito";
            // 
            // nudTaxaDebito
            // 
            nudTaxaDebito.DecimalPlaces = 2;
            nudTaxaDebito.Location = new Point(6, 26);
            nudTaxaDebito.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudTaxaDebito.Name = "nudTaxaDebito";
            nudTaxaDebito.Size = new Size(69, 23);
            nudTaxaDebito.TabIndex = 20;
            nudTaxaDebito.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(225, 8);
            label6.Name = "label6";
            label6.Size = new Size(79, 15);
            label6.TabIndex = 29;
            label6.Text = "Parcelas Máx.";
            // 
            // nudParcelas
            // 
            nudParcelas.DecimalPlaces = 2;
            nudParcelas.Location = new Point(225, 26);
            nudParcelas.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudParcelas.Name = "nudParcelas";
            nudParcelas.Size = new Size(69, 23);
            nudParcelas.TabIndex = 28;
            nudParcelas.TextAlign = HorizontalAlignment.Right;
            // 
            // formDetalhesAdquirente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 293);
            Controls.Add(tcAdquirente);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "formDetalhesAdquirente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "[NOVO]";
            Load += formDetalhesAdquirente_Load;
            tpDadosGerais.ResumeLayout(false);
            tpDadosGerais.PerformLayout();
            tcAdquirente.ResumeLayout(false);
            tpTaxas.ResumeLayout(false);
            tpTaxas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTaxaAntecipacao).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTaxaCreditoParcelado).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTaxaCreditoAVista).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTaxaDebito).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudParcelas).EndInit();
            ResumeLayout(false);
        }


        #endregion
        private Button btnSalvar;
        private Button btnCancelar;
        private TabPage tpDadosGerais;
        private TextBox txtNome;
        private Label label14;
        private TabControl tcAdquirente;
        private TextBox txtCnpj;
        private Label label1;
        private Label label2;
        private ComboBox cbAdquirente;
        private TabPage tpTaxas;
        private Label lblValor;
        private NumericUpDown nudTaxaDebito;
        private Label label3;
        private NumericUpDown nudTaxaCreditoAVista;
        private Label label4;
        private NumericUpDown nudTaxaCreditoParcelado;
        private Label label5;
        private NumericUpDown nudTaxaAntecipacao;
        private Label label6;
        private NumericUpDown nudParcelas;
    }
}