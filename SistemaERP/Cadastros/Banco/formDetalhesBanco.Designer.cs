namespace SistemaERP.Cadastros.Banco
{
    partial class formDetalhesBanco
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
            tcBanco = new TabControl();
            tpDadosGerais = new TabPage();
            label8 = new Label();
            ckInativo = new CheckBox();
            label6 = new Label();
            txtSwift = new TextBox();
            txtChavePix = new TextBox();
            ckContaInternacional = new CheckBox();
            label16 = new Label();
            txtIBAN = new TextBox();
            cbTipoChavePix = new ComboBox();
            label15 = new Label();
            txtTitularDocumento = new TextBox();
            label14 = new Label();
            txtNomeTitular = new TextBox();
            label5 = new Label();
            txtContaDigito = new TextBox();
            label11 = new Label();
            txtConta = new TextBox();
            label10 = new Label();
            txtAgenciaDigito = new TextBox();
            label9 = new Label();
            txtAgencia = new TextBox();
            label7 = new Label();
            txtCodigo = new TextBox();
            label4 = new Label();
            cbTipoConta = new ComboBox();
            label3 = new Label();
            txtAtualizacao = new TextBox();
            label2 = new Label();
            txtCadastro = new TextBox();
            label1 = new Label();
            txtNomeBanco = new TextBox();
            tpFinanceiro = new TabPage();
            btnSalvar = new Button();
            btnCancelar = new Button();
            tcBanco.SuspendLayout();
            tpDadosGerais.SuspendLayout();
            SuspendLayout();
            // 
            // tcBanco
            // 
            tcBanco.Alignment = TabAlignment.Left;
            tcBanco.Controls.Add(tpDadosGerais);
            tcBanco.Controls.Add(tpFinanceiro);
            tcBanco.DrawMode = TabDrawMode.OwnerDrawFixed;
            tcBanco.ItemSize = new Size(30, 100);
            tcBanco.Location = new Point(2, 1);
            tcBanco.Multiline = true;
            tcBanco.Name = "tcBanco";
            tcBanco.SelectedIndex = 0;
            tcBanco.Size = new Size(671, 320);
            tcBanco.SizeMode = TabSizeMode.Fixed;
            tcBanco.TabIndex = 0;
            tcBanco.DrawItem += tcBanco_DrawItem;
            // 
            // tpDadosGerais
            // 
            tpDadosGerais.Controls.Add(label8);
            tpDadosGerais.Controls.Add(ckInativo);
            tpDadosGerais.Controls.Add(label6);
            tpDadosGerais.Controls.Add(txtSwift);
            tpDadosGerais.Controls.Add(txtChavePix);
            tpDadosGerais.Controls.Add(ckContaInternacional);
            tpDadosGerais.Controls.Add(label16);
            tpDadosGerais.Controls.Add(txtIBAN);
            tpDadosGerais.Controls.Add(cbTipoChavePix);
            tpDadosGerais.Controls.Add(label15);
            tpDadosGerais.Controls.Add(txtTitularDocumento);
            tpDadosGerais.Controls.Add(label14);
            tpDadosGerais.Controls.Add(txtNomeTitular);
            tpDadosGerais.Controls.Add(label5);
            tpDadosGerais.Controls.Add(txtContaDigito);
            tpDadosGerais.Controls.Add(label11);
            tpDadosGerais.Controls.Add(txtConta);
            tpDadosGerais.Controls.Add(label10);
            tpDadosGerais.Controls.Add(txtAgenciaDigito);
            tpDadosGerais.Controls.Add(label9);
            tpDadosGerais.Controls.Add(txtAgencia);
            tpDadosGerais.Controls.Add(label7);
            tpDadosGerais.Controls.Add(txtCodigo);
            tpDadosGerais.Controls.Add(label4);
            tpDadosGerais.Controls.Add(cbTipoConta);
            tpDadosGerais.Controls.Add(label3);
            tpDadosGerais.Controls.Add(txtAtualizacao);
            tpDadosGerais.Controls.Add(label2);
            tpDadosGerais.Controls.Add(txtCadastro);
            tpDadosGerais.Controls.Add(label1);
            tpDadosGerais.Controls.Add(txtNomeBanco);
            tpDadosGerais.Location = new Point(104, 4);
            tpDadosGerais.Name = "tpDadosGerais";
            tpDadosGerais.Padding = new Padding(3);
            tpDadosGerais.Size = new Size(563, 312);
            tpDadosGerais.TabIndex = 0;
            tpDadosGerais.Text = "Dados Gerais";
            tpDadosGerais.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(272, 267);
            label8.Name = "label8";
            label8.Size = new Size(62, 15);
            label8.TabIndex = 46;
            label8.Text = "SWIFT/BIC";
            // 
            // ckInativo
            // 
            ckInativo.AutoSize = true;
            ckInativo.Location = new Point(494, 287);
            ckInativo.Name = "ckInativo";
            ckInativo.Size = new Size(62, 19);
            ckInativo.TabIndex = 44;
            ckInativo.Text = "Inativo";
            ckInativo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(102, 267);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 46;
            label6.Text = "IBAN:";
            // 
            // txtSwift
            // 
            txtSwift.Location = new Point(272, 285);
            txtSwift.Name = "txtSwift";
            txtSwift.Size = new Size(178, 23);
            txtSwift.TabIndex = 45;
            // 
            // txtChavePix
            // 
            txtChavePix.Location = new Point(195, 170);
            txtChavePix.Name = "txtChavePix";
            txtChavePix.Size = new Size(362, 23);
            txtChavePix.TabIndex = 42;
            // 
            // ckContaInternacional
            // 
            ckContaInternacional.AutoSize = true;
            ckContaInternacional.Location = new Point(6, 287);
            ckContaInternacional.Name = "ckContaInternacional";
            ckContaInternacional.Size = new Size(95, 19);
            ckContaInternacional.TabIndex = 43;
            ckContaInternacional.Text = "Internacional";
            ckContaInternacional.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 152);
            label16.Name = "label16";
            label16.Size = new Size(86, 15);
            label16.TabIndex = 41;
            label16.Text = "Tipo chave pix:";
            // 
            // txtIBAN
            // 
            txtIBAN.Location = new Point(102, 285);
            txtIBAN.Name = "txtIBAN";
            txtIBAN.Size = new Size(164, 23);
            txtIBAN.TabIndex = 45;
            // 
            // cbTipoChavePix
            // 
            cbTipoChavePix.FormattingEnabled = true;
            cbTipoChavePix.Location = new Point(6, 170);
            cbTipoChavePix.Name = "cbTipoChavePix";
            cbTipoChavePix.Size = new Size(183, 23);
            cbTipoChavePix.TabIndex = 40;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(456, 94);
            label15.Name = "label15";
            label15.Size = new Size(63, 15);
            label15.TabIndex = 39;
            label15.Text = "CPF/CNPJ:";
            // 
            // txtTitularDocumento
            // 
            txtTitularDocumento.Location = new Point(456, 112);
            txtTitularDocumento.Name = "txtTitularDocumento";
            txtTitularDocumento.Size = new Size(101, 23);
            txtTitularDocumento.TabIndex = 38;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(195, 94);
            label14.Name = "label14";
            label14.Size = new Size(43, 15);
            label14.TabIndex = 37;
            label14.Text = "Titular:";
            // 
            // txtNomeTitular
            // 
            txtNomeTitular.Location = new Point(195, 112);
            txtNomeTitular.Name = "txtNomeTitular";
            txtNomeTitular.Size = new Size(255, 23);
            txtNomeTitular.TabIndex = 36;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(515, 42);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 35;
            label5.Text = "Dígito:";
            // 
            // txtContaDigito
            // 
            txtContaDigito.Location = new Point(515, 60);
            txtContaDigito.Name = "txtContaDigito";
            txtContaDigito.Size = new Size(42, 23);
            txtContaDigito.TabIndex = 34;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(407, 42);
            label11.Name = "label11";
            label11.Size = new Size(42, 15);
            label11.TabIndex = 33;
            label11.Text = "Conta:";
            // 
            // txtConta
            // 
            txtConta.Location = new Point(407, 60);
            txtConta.Name = "txtConta";
            txtConta.Size = new Size(102, 23);
            txtConta.TabIndex = 32;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(359, 42);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 31;
            label10.Text = "Dígito:";
            // 
            // txtAgenciaDigito
            // 
            txtAgenciaDigito.Location = new Point(359, 60);
            txtAgenciaDigito.Name = "txtAgenciaDigito";
            txtAgenciaDigito.Size = new Size(42, 23);
            txtAgenciaDigito.TabIndex = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(251, 42);
            label9.Name = "label9";
            label9.Size = new Size(53, 15);
            label9.TabIndex = 29;
            label9.Text = "Agência:";
            // 
            // txtAgencia
            // 
            txtAgencia.Location = new Point(251, 60);
            txtAgencia.Name = "txtAgencia";
            txtAgencia.Size = new Size(102, 23);
            txtAgencia.TabIndex = 28;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(195, 42);
            label7.Name = "label7";
            label7.Size = new Size(49, 15);
            label7.TabIndex = 25;
            label7.Text = "Código:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(195, 60);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(50, 23);
            txtCodigo.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 94);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 17;
            label4.Text = "Tipo Conta:";
            // 
            // cbTipoConta
            // 
            cbTipoConta.FormattingEnabled = true;
            cbTipoConta.Location = new Point(6, 112);
            cbTipoConta.Name = "cbTipoConta";
            cbTipoConta.Size = new Size(183, 23);
            cbTipoConta.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(310, 17);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 15;
            label3.Text = "Atualização: ";
            // 
            // txtAtualizacao
            // 
            txtAtualizacao.BackColor = SystemColors.Menu;
            txtAtualizacao.Location = new Point(390, 14);
            txtAtualizacao.Name = "txtAtualizacao";
            txtAtualizacao.ReadOnly = true;
            txtAtualizacao.Size = new Size(167, 23);
            txtAtualizacao.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 17);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 13;
            label2.Text = "Cadastro: ";
            // 
            // txtCadastro
            // 
            txtCadastro.BackColor = SystemColors.Menu;
            txtCadastro.Location = new Point(72, 14);
            txtCadastro.Name = "txtCadastro";
            txtCadastro.ReadOnly = true;
            txtCadastro.Size = new Size(167, 23);
            txtCadastro.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 42);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 11;
            label1.Text = "Banco:";
            // 
            // txtNomeBanco
            // 
            txtNomeBanco.Location = new Point(6, 60);
            txtNomeBanco.Name = "txtNomeBanco";
            txtNomeBanco.Size = new Size(183, 23);
            txtNomeBanco.TabIndex = 10;
            // 
            // tpFinanceiro
            // 
            tpFinanceiro.Location = new Point(104, 4);
            tpFinanceiro.Name = "tpFinanceiro";
            tpFinanceiro.Padding = new Padding(3);
            tpFinanceiro.Size = new Size(563, 312);
            tpFinanceiro.TabIndex = 1;
            tpFinanceiro.Text = "Financeiro";
            tpFinanceiro.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvar.Location = new Point(598, 327);
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
            btnCancelar.Location = new Point(517, 327);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 39);
            btnCancelar.TabIndex = 34;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // formDetalhesBanco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 368);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(tcBanco);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "formDetalhesBanco";
            StartPosition = FormStartPosition.CenterParent;
            Text = "[NOVO]";
            Load += formDetalhesBanco_Load;
            tcBanco.ResumeLayout(false);
            tpDadosGerais.ResumeLayout(false);
            tpDadosGerais.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcBanco;
        private TabPage tpDadosGerais;
        private TabPage tpFinanceiro;
        private Label label4;
        private ComboBox cbTipoConta;
        private Label label3;
        private TextBox txtAtualizacao;
        private Label label2;
        private TextBox txtCadastro;
        private Label label1;
        private TextBox txtNomeBanco;
        private Label label7;
        private TextBox txtCodigo;
        private Label label10;
        private TextBox txtAgenciaDigito;
        private Label label9;
        private TextBox txtAgencia;
        private Button btnSalvar;
        private Button btnCancelar;
        private Label label5;
        private TextBox txtContaDigito;
        private Label label11;
        private TextBox txtConta;
        private Label label14;
        private TextBox txtNomeTitular;
        private Label label15;
        private TextBox txtTitularDocumento;
        private Label label16;
        private ComboBox cbTipoChavePix;
        private TextBox txtChavePix;
        private CheckBox ckContaInternacional;
        private CheckBox ckInativo;
        private Label label6;
        private TextBox txtIBAN;
        private Label label8;
        private TextBox txtSwift;
    }
}