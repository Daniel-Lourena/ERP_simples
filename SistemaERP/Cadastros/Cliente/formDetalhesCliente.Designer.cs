namespace SistemaERP.Cadastros.Cliente
{
    partial class formDetalhesCliente
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
            tcCliente = new TabControl();
            tpDadosGerais = new TabPage();
            lblDataExclusao = new Label();
            txtExclusao = new TextBox();
            label10 = new Label();
            txtBairro = new TextBox();
            label9 = new Label();
            txtRua = new TextBox();
            label8 = new Label();
            txtNro = new TextBox();
            label7 = new Label();
            txtLogradouro = new TextBox();
            label6 = new Label();
            cbEstados = new ComboBox();
            label5 = new Label();
            txtRazaoSocial = new TextBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            label4 = new Label();
            cbCidades = new ComboBox();
            label3 = new Label();
            txtAtualizacao = new TextBox();
            label2 = new Label();
            txtCadastro = new TextBox();
            label1 = new Label();
            txtFantasia = new TextBox();
            tpFinanceiro = new TabPage();
            label13 = new Label();
            nudLimite = new NumericUpDown();
            label12 = new Label();
            tcCliente.SuspendLayout();
            tpDadosGerais.SuspendLayout();
            tpFinanceiro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudLimite).BeginInit();
            SuspendLayout();
            // 
            // tcCliente
            // 
            tcCliente.Alignment = TabAlignment.Left;
            tcCliente.Controls.Add(tpDadosGerais);
            tcCliente.Controls.Add(tpFinanceiro);
            tcCliente.DrawMode = TabDrawMode.OwnerDrawFixed;
            tcCliente.ItemSize = new Size(30, 100);
            tcCliente.Location = new Point(2, 1);
            tcCliente.Multiline = true;
            tcCliente.Name = "tcCliente";
            tcCliente.SelectedIndex = 0;
            tcCliente.Size = new Size(715, 351);
            tcCliente.SizeMode = TabSizeMode.Fixed;
            tcCliente.TabIndex = 0;
            tcCliente.DrawItem += tcCliente_DrawItem;
            // 
            // tpDadosGerais
            // 
            tpDadosGerais.Controls.Add(lblDataExclusao);
            tpDadosGerais.Controls.Add(txtExclusao);
            tpDadosGerais.Controls.Add(label10);
            tpDadosGerais.Controls.Add(txtBairro);
            tpDadosGerais.Controls.Add(label9);
            tpDadosGerais.Controls.Add(txtRua);
            tpDadosGerais.Controls.Add(label8);
            tpDadosGerais.Controls.Add(txtNro);
            tpDadosGerais.Controls.Add(label7);
            tpDadosGerais.Controls.Add(txtLogradouro);
            tpDadosGerais.Controls.Add(label6);
            tpDadosGerais.Controls.Add(cbEstados);
            tpDadosGerais.Controls.Add(label5);
            tpDadosGerais.Controls.Add(txtRazaoSocial);
            tpDadosGerais.Controls.Add(btnSalvar);
            tpDadosGerais.Controls.Add(btnCancelar);
            tpDadosGerais.Controls.Add(label4);
            tpDadosGerais.Controls.Add(cbCidades);
            tpDadosGerais.Controls.Add(label3);
            tpDadosGerais.Controls.Add(txtAtualizacao);
            tpDadosGerais.Controls.Add(label2);
            tpDadosGerais.Controls.Add(txtCadastro);
            tpDadosGerais.Controls.Add(label1);
            tpDadosGerais.Controls.Add(txtFantasia);
            tpDadosGerais.Location = new Point(104, 4);
            tpDadosGerais.Name = "tpDadosGerais";
            tpDadosGerais.Padding = new Padding(3);
            tpDadosGerais.Size = new Size(607, 343);
            tpDadosGerais.TabIndex = 0;
            tpDadosGerais.Text = "Dados Gerais";
            tpDadosGerais.UseVisualStyleBackColor = true;
            // 
            // lblDataExclusao
            // 
            lblDataExclusao.AutoSize = true;
            lblDataExclusao.Location = new Point(7, 306);
            lblDataExclusao.Name = "lblDataExclusao";
            lblDataExclusao.Size = new Size(59, 15);
            lblDataExclusao.TabIndex = 33;
            lblDataExclusao.Text = "Exclusão: ";
            lblDataExclusao.Visible = false;
            // 
            // txtExclusao
            // 
            txtExclusao.BackColor = SystemColors.Menu;
            txtExclusao.Location = new Point(72, 303);
            txtExclusao.Name = "txtExclusao";
            txtExclusao.ReadOnly = true;
            txtExclusao.Size = new Size(167, 23);
            txtExclusao.TabIndex = 32;
            txtExclusao.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(334, 91);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 31;
            label10.Text = "Bairro: ";
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(334, 109);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(183, 23);
            txtBairro.TabIndex = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(87, 91);
            label9.Name = "label9";
            label9.Size = new Size(33, 15);
            label9.TabIndex = 29;
            label9.Text = "Rua: ";
            // 
            // txtRua
            // 
            txtRua.Location = new Point(87, 109);
            txtRua.Name = "txtRua";
            txtRua.Size = new Size(241, 23);
            txtRua.TabIndex = 28;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(523, 91);
            label8.Name = "label8";
            label8.Size = new Size(27, 15);
            label8.TabIndex = 27;
            label8.Text = "N°: ";
            // 
            // txtNro
            // 
            txtNro.Location = new Point(523, 109);
            txtNro.Name = "txtNro";
            txtNro.Size = new Size(75, 23);
            txtNro.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 91);
            label7.Name = "label7";
            label7.Size = new Size(75, 15);
            label7.TabIndex = 25;
            label7.Text = "Logradouro: ";
            // 
            // txtLogradouro
            // 
            txtLogradouro.Location = new Point(6, 109);
            txtLogradouro.Name = "txtLogradouro";
            txtLogradouro.Size = new Size(75, 23);
            txtLogradouro.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(195, 138);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 23;
            label6.Text = "Estado: ";
            // 
            // cbEstados
            // 
            cbEstados.FormattingEnabled = true;
            cbEstados.Location = new Point(195, 156);
            cbEstados.Name = "cbEstado";
            cbEstados.Size = new Size(183, 23);
            cbEstados.TabIndex = 22;
            cbEstados.SelectedValueChanged += cbEstado_SelectedValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(250, 45);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 21;
            label5.Text = "Razão Social: ";
            // 
            // txtRazaoSocial
            // 
            txtRazaoSocial.Location = new Point(251, 60);
            txtRazaoSocial.Name = "txtRazaoSocial";
            txtRazaoSocial.Size = new Size(347, 23);
            txtRazaoSocial.TabIndex = 20;
            // 
            // btnSalvar
            // 
            btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvar.Location = new Point(523, 287);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 39);
            btnSalvar.TabIndex = 19;
            btnSalvar.Text = "SALVAR";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor = SystemColors.ButtonHighlight;
            btnCancelar.Location = new Point(442, 287);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 39);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 138);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 17;
            label4.Text = "Cidade: ";
            // 
            // cbCidades
            // 
            cbCidades.FormattingEnabled = true;
            cbCidades.Location = new Point(6, 156);
            cbCidades.Name = "cbCidade";
            cbCidades.Size = new Size(183, 23);
            cbCidades.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(351, 17);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 15;
            label3.Text = "Atualização: ";
            // 
            // txtAtualizacao
            // 
            txtAtualizacao.BackColor = SystemColors.Menu;
            txtAtualizacao.Location = new Point(431, 14);
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
            label1.Size = new Size(56, 15);
            label1.TabIndex = 11;
            label1.Text = "Fantasia: ";
            // 
            // txtFantasia
            // 
            txtFantasia.Location = new Point(6, 60);
            txtFantasia.Name = "txtFantasia";
            txtFantasia.Size = new Size(237, 23);
            txtFantasia.TabIndex = 10;
            // 
            // tpFinanceiro
            // 
            tpFinanceiro.Controls.Add(label13);
            tpFinanceiro.Controls.Add(nudLimite);
            tpFinanceiro.Controls.Add(label12);
            tpFinanceiro.Location = new Point(104, 4);
            tpFinanceiro.Name = "tpFinanceiro";
            tpFinanceiro.Padding = new Padding(3);
            tpFinanceiro.Size = new Size(607, 343);
            tpFinanceiro.TabIndex = 1;
            tpFinanceiro.Text = "Financeiro";
            tpFinanceiro.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(115, 23);
            label13.Name = "label13";
            label13.Size = new Size(23, 15);
            label13.TabIndex = 16;
            label13.Text = "R$ ";
            // 
            // nudLimite
            // 
            nudLimite.DecimalPlaces = 2;
            nudLimite.Location = new Point(6, 21);
            nudLimite.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            nudLimite.Name = "nudLimite";
            nudLimite.Size = new Size(103, 23);
            nudLimite.TabIndex = 15;
            nudLimite.TextAlign = HorizontalAlignment.Right;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 3);
            label12.Name = "label12";
            label12.Size = new Size(103, 15);
            label12.TabIndex = 14;
            label12.Text = "Limite disponível: ";
            // 
            // formDetalhesCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 355);
            ControlBox = false;
            Controls.Add(tcCliente);
            MinimizeBox = false;
            Name = "formDetalhesCliente";
            Text = "[NOVO]";
            Load += formDetalhesCliente_Load;
            tcCliente.ResumeLayout(false);
            tpDadosGerais.ResumeLayout(false);
            tpDadosGerais.PerformLayout();
            tpFinanceiro.ResumeLayout(false);
            tpFinanceiro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudLimite).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcCliente;
        private TabPage tpDadosGerais;
        private TabPage tpFinanceiro;
        private Button btnSalvar;
        private Button btnCancelar;
        private Label label4;
        private ComboBox cbCidades;
        private Label label3;
        private TextBox txtAtualizacao;
        private Label label2;
        private TextBox txtCadastro;
        private Label label1;
        private TextBox txtFantasia;
        private Label label5;
        private TextBox txtRazaoSocial;
        private Label label6;
        private ComboBox cbEstados;
        private Label label7;
        private TextBox txtLogradouro;
        private Label label8;
        private TextBox txtNro;
        private Label label10;
        private TextBox txtBairro;
        private Label label9;
        private TextBox txtRua;
        private Label lblDataExclusao;
        private TextBox txtExclusao;
        private Label label12;
        private NumericUpDown nudLimite;
        private Label label13;
    }
}