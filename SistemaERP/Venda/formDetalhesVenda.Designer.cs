
namespace SistemaERP.Venda
{
    partial class formDetalhesVenda
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
            tcPedidos = new TabControl();
            tpDadosGerais = new TabPage();
            label6 = new Label();
            txtAtualizacao = new TextBox();
            label9 = new Label();
            txtCriacao = new TextBox();
            groupBox1 = new GroupBox();
            btnProcurarCliente = new Button();
            txtIdCliente = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtUF = new TextBox();
            label2 = new Label();
            txtCidade = new TextBox();
            txtRua = new TextBox();
            label10 = new Label();
            txtFantasia = new TextBox();
            txtBairro = new TextBox();
            label1 = new Label();
            txtRazaoSocial = new TextBox();
            label5 = new Label();
            label8 = new Label();
            txtLogradouro = new TextBox();
            txtNro = new TextBox();
            label7 = new Label();
            tpProdutos = new TabPage();
            dgvProdutos = new DataGridView();
            panel3 = new Panel();
            groupBox3 = new GroupBox();
            btnRemProduto = new Button();
            btnAddProduto = new Button();
            tpFinanceiro = new TabPage();
            panel2 = new Panel();
            groupBox2 = new GroupBox();
            btnCartaoCredito = new Button();
            btnCartaoDebito = new Button();
            btnBoleto = new Button();
            btnCheque = new Button();
            btnTransferencia = new Button();
            btnCreditoLoja = new Button();
            btnDinheiro = new Button();
            dgvRecebimentos = new DataGridView();
            panel1 = new Panel();
            label12 = new Label();
            textBox2 = new TextBox();
            label11 = new Label();
            btnFecharPedido = new Button();
            textBox1 = new TextBox();
            btnExcluirPedido = new Button();
            btnSalvar = new Button();
            tcPedidos.SuspendLayout();
            tpDadosGerais.SuspendLayout();
            groupBox1.SuspendLayout();
            tpProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            panel3.SuspendLayout();
            groupBox3.SuspendLayout();
            tpFinanceiro.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecebimentos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tcPedidos
            // 
            tcPedidos.Controls.Add(tpDadosGerais);
            tcPedidos.Controls.Add(tpProdutos);
            tcPedidos.Controls.Add(tpFinanceiro);
            tcPedidos.Dock = DockStyle.Fill;
            tcPedidos.Location = new Point(0, 0);
            tcPedidos.Name = "tcPedidos";
            tcPedidos.SelectedIndex = 0;
            tcPedidos.Size = new Size(800, 378);
            tcPedidos.TabIndex = 0;
            // 
            // tpDadosGerais
            // 
            tpDadosGerais.Controls.Add(label6);
            tpDadosGerais.Controls.Add(txtAtualizacao);
            tpDadosGerais.Controls.Add(label9);
            tpDadosGerais.Controls.Add(txtCriacao);
            tpDadosGerais.Controls.Add(groupBox1);
            tpDadosGerais.Location = new Point(4, 24);
            tpDadosGerais.Name = "tpDadosGerais";
            tpDadosGerais.Padding = new Padding(3);
            tpDadosGerais.Size = new Size(792, 350);
            tpDadosGerais.TabIndex = 0;
            tpDadosGerais.Text = "Dados Gerais";
            tpDadosGerais.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(524, 9);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 48;
            label6.Text = "Atualização: ";
            // 
            // txtAtualizacao
            // 
            txtAtualizacao.BackColor = SystemColors.Menu;
            txtAtualizacao.Location = new Point(604, 6);
            txtAtualizacao.Name = "txtAtualizacao";
            txtAtualizacao.ReadOnly = true;
            txtAtualizacao.Size = new Size(167, 23);
            txtAtualizacao.TabIndex = 47;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(259, 9);
            label9.Name = "label9";
            label9.Size = new Size(53, 15);
            label9.TabIndex = 46;
            label9.Text = "Criação: ";
            // 
            // txtCriacao
            // 
            txtCriacao.BackColor = SystemColors.Menu;
            txtCriacao.Location = new Point(325, 6);
            txtCriacao.Name = "txtCriacao";
            txtCriacao.ReadOnly = true;
            txtCriacao.Size = new Size(167, 23);
            txtCriacao.TabIndex = 45;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnProcurarCliente);
            groupBox1.Controls.Add(txtIdCliente);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtUF);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCidade);
            groupBox1.Controls.Add(txtRua);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtFantasia);
            groupBox1.Controls.Add(txtBairro);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtRazaoSocial);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtLogradouro);
            groupBox1.Controls.Add(txtNro);
            groupBox1.Controls.Add(label7);
            groupBox1.Location = new Point(23, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(748, 154);
            groupBox1.TabIndex = 44;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cliente";
            // 
            // btnProcurarCliente
            // 
            btnProcurarCliente.Location = new Point(67, 55);
            btnProcurarCliente.Name = "btnProcurarCliente";
            btnProcurarCliente.Size = new Size(24, 22);
            btnProcurarCliente.TabIndex = 2;
            btnProcurarCliente.Text = "...";
            btnProcurarCliente.UseVisualStyleBackColor = true;
            btnProcurarCliente.Click += btnProcurarCliente_Click;
            // 
            // txtIdCliente
            // 
            txtIdCliente.Location = new Point(21, 54);
            txtIdCliente.Name = "txtIdCliente";
            txtIdCliente.ReadOnly = true;
            txtIdCliente.Size = new Size(40, 23);
            txtIdCliente.TabIndex = 48;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 36);
            label4.Name = "label4";
            label4.Size = new Size(21, 15);
            label4.TabIndex = 49;
            label4.Text = "ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(667, 85);
            label3.Name = "label3";
            label3.Size = new Size(24, 15);
            label3.TabIndex = 47;
            label3.Text = "UF:";
            // 
            // txtUF
            // 
            txtUF.Location = new Point(667, 103);
            txtUF.Name = "txtUF";
            txtUF.ReadOnly = true;
            txtUF.Size = new Size(63, 23);
            txtUF.TabIndex = 46;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(481, 85);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 45;
            label2.Text = "Cidade:";
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(481, 103);
            txtCidade.Name = "txtCidade";
            txtCidade.ReadOnly = true;
            txtCidade.Size = new Size(180, 23);
            txtCidade.TabIndex = 44;
            // 
            // txtRua
            // 
            txtRua.Location = new Point(67, 103);
            txtRua.Name = "txtRua";
            txtRua.ReadOnly = true;
            txtRua.Size = new Size(219, 23);
            txtRua.TabIndex = 40;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(292, 85);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 43;
            label10.Text = "Bairro: ";
            // 
            // txtFantasia
            // 
            txtFantasia.Location = new Point(97, 54);
            txtFantasia.Name = "txtFantasia";
            txtFantasia.ReadOnly = true;
            txtFantasia.Size = new Size(189, 23);
            txtFantasia.TabIndex = 32;
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(292, 103);
            txtBairro.Name = "txtBairro";
            txtBairro.ReadOnly = true;
            txtBairro.Size = new Size(183, 23);
            txtBairro.TabIndex = 42;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 36);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 33;
            label1.Text = "Fantasia: ";
            // 
            // txtRazaoSocial
            // 
            txtRazaoSocial.Location = new Point(292, 54);
            txtRazaoSocial.Name = "txtRazaoSocial";
            txtRazaoSocial.ReadOnly = true;
            txtRazaoSocial.Size = new Size(369, 23);
            txtRazaoSocial.TabIndex = 34;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(292, 36);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 35;
            label5.Text = "Razão social: ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(667, 36);
            label8.Name = "label8";
            label8.Size = new Size(27, 15);
            label8.TabIndex = 39;
            label8.Text = "N°: ";
            // 
            // txtLogradouro
            // 
            txtLogradouro.Location = new Point(21, 103);
            txtLogradouro.Name = "txtLogradouro";
            txtLogradouro.ReadOnly = true;
            txtLogradouro.Size = new Size(40, 23);
            txtLogradouro.TabIndex = 36;
            // 
            // txtNro
            // 
            txtNro.Location = new Point(667, 54);
            txtNro.Name = "txtNro";
            txtNro.ReadOnly = true;
            txtNro.Size = new Size(63, 23);
            txtNro.TabIndex = 38;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 85);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 37;
            label7.Text = "Endereço:";
            // 
            // tpProdutos
            // 
            tpProdutos.Controls.Add(dgvProdutos);
            tpProdutos.Controls.Add(panel3);
            tpProdutos.Location = new Point(4, 24);
            tpProdutos.Name = "tpProdutos";
            tpProdutos.Padding = new Padding(3);
            tpProdutos.Size = new Size(792, 350);
            tpProdutos.TabIndex = 1;
            tpProdutos.Text = "Produtos";
            tpProdutos.UseVisualStyleBackColor = true;
            // 
            // dgvProdutos
            // 
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Dock = DockStyle.Fill;
            dgvProdutos.Location = new Point(3, 3);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.RowTemplate.Height = 25;
            dgvProdutos.Size = new Size(786, 251);
            dgvProdutos.TabIndex = 0;
            dgvProdutos.CellEndEdit += dgvProdutos_CellEndEdit;
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox3);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(3, 254);
            panel3.Name = "panel3";
            panel3.Size = new Size(786, 93);
            panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnRemProduto);
            groupBox3.Controls.Add(btnAddProduto);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(786, 93);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            // 
            // btnRemProduto
            // 
            btnRemProduto.Location = new Point(117, 27);
            btnRemProduto.Name = "btnRemProduto";
            btnRemProduto.Size = new Size(105, 50);
            btnRemProduto.TabIndex = 4;
            btnRemProduto.Text = "Remover";
            btnRemProduto.UseVisualStyleBackColor = true;
            btnRemProduto.Click += btnRemProduto_Click;
            // 
            // btnAddProduto
            // 
            btnAddProduto.Location = new Point(6, 27);
            btnAddProduto.Name = "btnAddProduto";
            btnAddProduto.Size = new Size(105, 50);
            btnAddProduto.TabIndex = 0;
            btnAddProduto.Text = "Adicionar";
            btnAddProduto.UseVisualStyleBackColor = true;
            btnAddProduto.Click += btnAddProduto_Click;
            // 
            // tpFinanceiro
            // 
            tpFinanceiro.Controls.Add(dgvRecebimentos);
            tpFinanceiro.Controls.Add(panel2);
            tpFinanceiro.Location = new Point(4, 24);
            tpFinanceiro.Name = "tpFinanceiro";
            tpFinanceiro.Padding = new Padding(3);
            tpFinanceiro.Size = new Size(792, 350);
            tpFinanceiro.TabIndex = 2;
            tpFinanceiro.Text = "Financeiro";
            tpFinanceiro.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox2);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(3, 254);
            panel2.Name = "panel2";
            panel2.Size = new Size(786, 93);
            panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnCartaoCredito);
            groupBox2.Controls.Add(btnCartaoDebito);
            groupBox2.Controls.Add(btnBoleto);
            groupBox2.Controls.Add(btnCheque);
            groupBox2.Controls.Add(btnTransferencia);
            groupBox2.Controls.Add(btnCreditoLoja);
            groupBox2.Controls.Add(btnDinheiro);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(786, 93);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Forma Pagamento";
            // 
            // btnCartaoCredito
            // 
            btnCartaoCredito.Location = new Point(672, 34);
            btnCartaoCredito.Name = "btnCartaoCredito";
            btnCartaoCredito.Size = new Size(105, 50);
            btnCartaoCredito.TabIndex = 6;
            btnCartaoCredito.Text = "Cartão crédito";
            btnCartaoCredito.UseVisualStyleBackColor = true;
            btnCartaoCredito.Click += btnCartaoCredito_Click;
            // 
            // btnCartaoDebito
            // 
            btnCartaoDebito.Location = new Point(561, 34);
            btnCartaoDebito.Name = "btnCartaoDebito";
            btnCartaoDebito.Size = new Size(105, 50);
            btnCartaoDebito.TabIndex = 5;
            btnCartaoDebito.Text = "Cartão débito";
            btnCartaoDebito.UseVisualStyleBackColor = true;
            btnCartaoDebito.Click += btnCartaoDebito_Click;
            // 
            // btnBoleto
            // 
            btnBoleto.Location = new Point(117, 34);
            btnBoleto.Name = "btnBoleto";
            btnBoleto.Size = new Size(105, 50);
            btnBoleto.TabIndex = 4;
            btnBoleto.Text = "Boleto";
            btnBoleto.UseVisualStyleBackColor = true;
            btnBoleto.Click += btnBoleto_Click;
            // 
            // btnCheque
            // 
            btnCheque.Location = new Point(228, 34);
            btnCheque.Name = "btnCheque";
            btnCheque.Size = new Size(105, 50);
            btnCheque.TabIndex = 3;
            btnCheque.Text = "Cheque";
            btnCheque.UseVisualStyleBackColor = true;
            btnCheque.Click += btnCheque_Click;
            // 
            // btnTransferencia
            // 
            btnTransferencia.Location = new Point(450, 34);
            btnTransferencia.Name = "btnTransferencia";
            btnTransferencia.Size = new Size(105, 50);
            btnTransferencia.TabIndex = 2;
            btnTransferencia.Text = "Transferência";
            btnTransferencia.UseVisualStyleBackColor = true;
            btnTransferencia.Click += btnTransferencia_Click;
            // 
            // btnCreditoLoja
            // 
            btnCreditoLoja.Location = new Point(339, 34);
            btnCreditoLoja.Name = "btnCreditoLoja";
            btnCreditoLoja.Size = new Size(105, 50);
            btnCreditoLoja.TabIndex = 1;
            btnCreditoLoja.Text = "Crédito loja";
            btnCreditoLoja.UseVisualStyleBackColor = true;
            btnCreditoLoja.Click += btnCreditoLoja_Click;
            // 
            // btnDinheiro
            // 
            btnDinheiro.Location = new Point(6, 34);
            btnDinheiro.Name = "btnDinheiro";
            btnDinheiro.Size = new Size(105, 50);
            btnDinheiro.TabIndex = 0;
            btnDinheiro.Text = "Dinheiro";
            btnDinheiro.UseVisualStyleBackColor = true;
            btnDinheiro.Click += btnDinheiro_Click;
            // 
            // dgvRecebimentos
            // 
            dgvRecebimentos.AllowUserToAddRows = false;
            dgvRecebimentos.AllowUserToOrderColumns = true;
            dgvRecebimentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecebimentos.Dock = DockStyle.Fill;
            dgvRecebimentos.Location = new Point(3, 3);
            dgvRecebimentos.Name = "dgvRecebimentos";
            dgvRecebimentos.RowTemplate.Height = 25;
            dgvRecebimentos.ScrollBars = ScrollBars.Vertical;
            dgvRecebimentos.Size = new Size(786, 251);
            dgvRecebimentos.TabIndex = 0;
            dgvRecebimentos.DoubleClick += dgvRecebimentos_DoubleClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(label12);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(btnFecharPedido);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(btnExcluirPedido);
            panel1.Controls.Add(btnSalvar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 378);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 72);
            panel1.TabIndex = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(536, 45);
            label12.Name = "label12";
            label12.Size = new Size(64, 15);
            label12.TabIndex = 53;
            label12.Text = "Valor Total:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(606, 37);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(82, 23);
            textBox2.TabIndex = 52;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(538, 18);
            label11.Name = "label11";
            label11.Size = new Size(62, 15);
            label11.TabIndex = 51;
            label11.Text = "Recebido: ";
            // 
            // btnFecharPedido
            // 
            btnFecharPedido.Location = new Point(707, 10);
            btnFecharPedido.Name = "btnFecharPedido";
            btnFecharPedido.Size = new Size(81, 50);
            btnFecharPedido.TabIndex = 3;
            btnFecharPedido.Text = "FECHAR PEDIDO";
            btnFecharPedido.UseVisualStyleBackColor = true;
            btnFecharPedido.Click += btnFecharPedido_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(606, 10);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(82, 23);
            textBox1.TabIndex = 50;
            // 
            // btnExcluirPedido
            // 
            btnExcluirPedido.BackColor = Color.IndianRed;
            btnExcluirPedido.ForeColor = SystemColors.ButtonHighlight;
            btnExcluirPedido.Location = new Point(124, 10);
            btnExcluirPedido.Name = "btnExcluirPedido";
            btnExcluirPedido.Size = new Size(81, 50);
            btnExcluirPedido.TabIndex = 2;
            btnExcluirPedido.Text = "EXCLUIR";
            btnExcluirPedido.UseVisualStyleBackColor = false;
            btnExcluirPedido.Click += btnExcluirPedido_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(12, 10);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(81, 50);
            btnSalvar.TabIndex = 1;
            btnSalvar.Text = "SALVAR";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // formDetalhesVenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tcPedidos);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "formDetalhesVenda";
            StartPosition = FormStartPosition.CenterParent;
            Text = "[NOVO]";
            Load += formDetalhesVenda_Load;
            tcPedidos.ResumeLayout(false);
            tpDadosGerais.ResumeLayout(false);
            tpDadosGerais.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tpProdutos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            panel3.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            tpFinanceiro.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecebimentos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private TabControl tcPedidos;
        private TabPage tpDadosGerais;
        private TabPage tpProdutos;
        private Panel panel1;
        private Label label10;
        private TextBox txtBairro;
        private TextBox txtRua;
        private Label label8;
        private TextBox txtNro;
        private Label label7;
        private TextBox txtLogradouro;
        private Label label5;
        private TextBox txtRazaoSocial;
        private Label label1;
        private TextBox txtFantasia;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox txtUF;
        private Label label2;
        private TextBox txtCidade;
        private TextBox txtIdCliente;
        private Label label4;
        private TabPage tpFinanceiro;
        private Panel panel2;
        private DataGridView dgvRecebimentos;
        private GroupBox groupBox2;
        private Button btnBoleto;
        private Button btnCheque;
        private Button btnTransferencia;
        private Button btnCreditoLoja;
        private Button btnDinheiro;
        private Button btnCartaoCredito;
        private Button btnCartaoDebito;
        private DataGridView dgvProdutos;
        private Panel panel3;
        private GroupBox groupBox3;
        private Button btnRemProduto;
        private Button btnAddProduto;
        private Button btnSalvar;
        private Button btnProcurarCliente;
        private Label label6;
        private TextBox txtAtualizacao;
        private Label label9;
        private TextBox txtCriacao;
        private Button btnExcluirPedido;
        private Button btnFecharPedido;
        private Label label12;
        private TextBox textBox2;
        private Label label11;
        private TextBox textBox1;
    }
}