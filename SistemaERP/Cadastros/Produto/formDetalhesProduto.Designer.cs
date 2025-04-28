namespace SistemaERP.Cadastros.Produto
{
    partial class formDetalhesProduto
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
            tcProduto = new TabControl();
            tpDadosGerais = new TabPage();
            ckeInativo = new CheckBox();
            label11 = new Label();
            cbCategoria = new ComboBox();
            comboBox1 = new ComboBox();
            nudEstoqueMinimo = new NumericUpDown();
            label12 = new Label();
            label8 = new Label();
            label5 = new Label();
            txtDescricao = new TextBox();
            label3 = new Label();
            txtAtualizacao = new TextBox();
            label2 = new Label();
            txtCadastro = new TextBox();
            label1 = new Label();
            txtCodigoSKU = new TextBox();
            tpFiscal = new TabPage();
            label14 = new Label();
            cbOrigem = new ComboBox();
            label9 = new Label();
            txtCEST = new TextBox();
            label7 = new Label();
            txtNCM = new TextBox();
            label4 = new Label();
            cbCST = new ComboBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            tcProduto.SuspendLayout();
            tpDadosGerais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudEstoqueMinimo).BeginInit();
            tpFiscal.SuspendLayout();
            SuspendLayout();
            // 
            // tcProduto
            // 
            tcProduto.Alignment = TabAlignment.Left;
            tcProduto.Controls.Add(tpDadosGerais);
            tcProduto.Controls.Add(tpFiscal);
            tcProduto.DrawMode = TabDrawMode.OwnerDrawFixed;
            tcProduto.ItemSize = new Size(30, 100);
            tcProduto.Location = new Point(2, 1);
            tcProduto.Multiline = true;
            tcProduto.Name = "tcProduto";
            tcProduto.SelectedIndex = 0;
            tcProduto.Size = new Size(715, 298);
            tcProduto.SizeMode = TabSizeMode.Fixed;
            tcProduto.TabIndex = 0;
            tcProduto.DrawItem += tcProduto_DrawItem;
            // 
            // tpDadosGerais
            // 
            tpDadosGerais.Controls.Add(ckeInativo);
            tpDadosGerais.Controls.Add(label11);
            tpDadosGerais.Controls.Add(cbCategoria);
            tpDadosGerais.Controls.Add(comboBox1);
            tpDadosGerais.Controls.Add(nudEstoqueMinimo);
            tpDadosGerais.Controls.Add(label12);
            tpDadosGerais.Controls.Add(label8);
            tpDadosGerais.Controls.Add(label5);
            tpDadosGerais.Controls.Add(txtDescricao);
            tpDadosGerais.Controls.Add(label3);
            tpDadosGerais.Controls.Add(txtAtualizacao);
            tpDadosGerais.Controls.Add(label2);
            tpDadosGerais.Controls.Add(txtCadastro);
            tpDadosGerais.Controls.Add(label1);
            tpDadosGerais.Controls.Add(txtCodigoSKU);
            tpDadosGerais.Location = new Point(104, 4);
            tpDadosGerais.Name = "tpDadosGerais";
            tpDadosGerais.Padding = new Padding(3);
            tpDadosGerais.Size = new Size(607, 290);
            tpDadosGerais.TabIndex = 0;
            tpDadosGerais.Text = "Dados Gerais";
            tpDadosGerais.UseVisualStyleBackColor = true;
            // 
            // ckeInativo
            // 
            ckeInativo.AutoSize = true;
            ckeInativo.Location = new Point(6, 265);
            ckeInativo.Name = "ckeInativo";
            ckeInativo.Size = new Size(62, 19);
            ckeInativo.TabIndex = 39;
            ckeInativo.Text = "Inativo";
            ckeInativo.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(115, 99);
            label11.Name = "label11";
            label11.Size = new Size(61, 15);
            label11.TabIndex = 36;
            label11.Text = "Categoria:";
            // 
            // cbCategoria
            // 
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(115, 117);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(183, 23);
            cbCategoria.TabIndex = 35;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(304, 117);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(54, 23);
            comboBox1.TabIndex = 34;
            // 
            // nudEstoqueMinimo
            // 
            nudEstoqueMinimo.DecimalPlaces = 2;
            nudEstoqueMinimo.Location = new Point(6, 118);
            nudEstoqueMinimo.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            nudEstoqueMinimo.Name = "nudEstoqueMinimo";
            nudEstoqueMinimo.Size = new Size(103, 23);
            nudEstoqueMinimo.TabIndex = 33;
            nudEstoqueMinimo.TextAlign = HorizontalAlignment.Right;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 100);
            label12.Name = "label12";
            label12.Size = new Size(97, 15);
            label12.TabIndex = 32;
            label12.Text = "Estoque Mínimo:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(304, 99);
            label8.Name = "label8";
            label8.Size = new Size(27, 15);
            label8.TabIndex = 27;
            label8.Text = "UN:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(115, 51);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 21;
            label5.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(115, 69);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(483, 23);
            txtDescricao.TabIndex = 20;
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
            label1.Location = new Point(6, 51);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 11;
            label1.Text = "Código SKU:";
            // 
            // txtCodigoSKU
            // 
            txtCodigoSKU.Location = new Point(6, 69);
            txtCodigoSKU.Name = "txtCodigoSKU";
            txtCodigoSKU.Size = new Size(103, 23);
            txtCodigoSKU.TabIndex = 10;
            // 
            // tpFiscal
            // 
            tpFiscal.Controls.Add(label14);
            tpFiscal.Controls.Add(cbOrigem);
            tpFiscal.Controls.Add(label9);
            tpFiscal.Controls.Add(txtCEST);
            tpFiscal.Controls.Add(label7);
            tpFiscal.Controls.Add(txtNCM);
            tpFiscal.Controls.Add(label4);
            tpFiscal.Controls.Add(cbCST);
            tpFiscal.Location = new Point(104, 4);
            tpFiscal.Name = "tpFiscal";
            tpFiscal.Padding = new Padding(3);
            tpFiscal.Size = new Size(607, 290);
            tpFiscal.TabIndex = 1;
            tpFiscal.Text = "Fiscal";
            tpFiscal.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 6);
            label14.Name = "label14";
            label14.Size = new Size(50, 15);
            label14.TabIndex = 43;
            label14.Text = "Origem:";
            // 
            // cbOrigem
            // 
            cbOrigem.FormattingEnabled = true;
            cbOrigem.Location = new Point(6, 24);
            cbOrigem.Name = "cbOrigem";
            cbOrigem.Size = new Size(595, 23);
            cbOrigem.TabIndex = 42;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(146, 57);
            label9.Name = "label9";
            label9.Size = new Size(36, 15);
            label9.TabIndex = 39;
            label9.Text = "CEST:";
            // 
            // txtCEST
            // 
            txtCEST.Location = new Point(146, 75);
            txtCEST.Name = "txtCEST";
            txtCEST.Size = new Size(142, 23);
            txtCEST.TabIndex = 38;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 57);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 37;
            label7.Text = "NCM:";
            // 
            // txtNCM
            // 
            txtNCM.Location = new Point(6, 75);
            txtNCM.Name = "txtNCM";
            txtNCM.Size = new Size(134, 23);
            txtNCM.TabIndex = 36;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(294, 57);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 33;
            label4.Text = "CST/CSOSN:";
            // 
            // cbCST
            // 
            cbCST.FormattingEnabled = true;
            cbCST.Location = new Point(294, 75);
            cbCST.Name = "cbCST";
            cbCST.Size = new Size(73, 23);
            cbCST.TabIndex = 32;
            // 
            // btnSalvar
            // 
            btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvar.Location = new Point(642, 305);
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
            btnCancelar.Location = new Point(561, 305);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 39);
            btnCancelar.TabIndex = 34;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // formDetalhesProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 347);
            ControlBox = false;
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(tcProduto);
            MinimizeBox = false;
            Name = "formDetalhesProduto";
            Text = "[NOVO]";
            Load += formDetalhesProduto_Load;
            tcProduto.ResumeLayout(false);
            tpDadosGerais.ResumeLayout(false);
            tpDadosGerais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudEstoqueMinimo).EndInit();
            tpFiscal.ResumeLayout(false);
            tpFiscal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcProduto;
        private TabPage tpDadosGerais;
        private TabPage tpFiscal;
        private Label label3;
        private TextBox txtAtualizacao;
        private Label label2;
        private TextBox txtCadastro;
        private Label label1;
        private TextBox txtCodigoSKU;
        private Label label5;
        private TextBox txtDescricao;
        private Label label8;
        private Button btnSalvar;
        private Button btnCancelar;
        private NumericUpDown nudEstoqueMinimo;
        private Label label12;
        private ComboBox comboBox1;
        private Label label11;
        private ComboBox cbCategoria;
        private CheckBox ckeInativo;
        private Label label9;
        private TextBox txtCEST;
        private Label label7;
        private TextBox txtNCM;
        private Label label4;
        private ComboBox cbCST;
        private Label label14;
        private ComboBox cbOrigem;
    }
}