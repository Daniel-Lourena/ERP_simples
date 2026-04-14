namespace SistemaERP.Cadastros.Usuario
{
    partial class formAlterarSenha
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblSenhaAtual = new Label();
            txtSenhaAtual = new TextBox();
            btnValidarSenha = new Button();
            lblNovaSenha = new Label();
            txtNovaSenha = new TextBox();
            lblConfirmaSenha = new Label();
            txtNovaSenhaConfirma = new TextBox();
            btnSalvarNovaSenha = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            //
            // lblSenhaAtual
            //
            lblSenhaAtual.AutoSize = true;
            lblSenhaAtual.Location = new Point(14, 20);
            lblSenhaAtual.Name = "lblSenhaAtual";
            lblSenhaAtual.Size = new Size(78, 15);
            lblSenhaAtual.Text = "Senha Atual:";
            //
            // txtSenhaAtual
            //
            txtSenhaAtual.Location = new Point(110, 17);
            txtSenhaAtual.Name = "txtSenhaAtual";
            txtSenhaAtual.PasswordChar = '●';
            txtSenhaAtual.Size = new Size(200, 23);
            txtSenhaAtual.TabIndex = 0;
            //
            // btnValidarSenha
            //
            btnValidarSenha.Location = new Point(318, 16);
            btnValidarSenha.Name = "btnValidarSenha";
            btnValidarSenha.Size = new Size(90, 25);
            btnValidarSenha.TabIndex = 1;
            btnValidarSenha.Text = "VALIDAR";
            btnValidarSenha.UseVisualStyleBackColor = true;
            btnValidarSenha.Click += btnValidarSenha_Click;
            //
            // lblNovaSenha
            //
            lblNovaSenha.AutoSize = true;
            lblNovaSenha.Location = new Point(14, 60);
            lblNovaSenha.Name = "lblNovaSenha";
            lblNovaSenha.Size = new Size(78, 15);
            lblNovaSenha.Text = "Nova Senha:";
            //
            // txtNovaSenha
            //
            txtNovaSenha.Enabled = false;
            txtNovaSenha.Location = new Point(110, 57);
            txtNovaSenha.Name = "txtNovaSenha";
            txtNovaSenha.PasswordChar = '●';
            txtNovaSenha.Size = new Size(200, 23);
            txtNovaSenha.TabIndex = 2;
            //
            // lblConfirmaSenha
            //
            lblConfirmaSenha.AutoSize = true;
            lblConfirmaSenha.Location = new Point(14, 100);
            lblConfirmaSenha.Name = "lblConfirmaSenha";
            lblConfirmaSenha.Size = new Size(78, 15);
            lblConfirmaSenha.Text = "Confirma Nova Senha:";
            //
            // txtNovaSenhaConfirma
            //
            txtNovaSenhaConfirma.Enabled = false;
            txtNovaSenhaConfirma.Location = new Point(110, 97);
            txtNovaSenhaConfirma.Name = "txtNovaSenhaConfirma";
            txtNovaSenhaConfirma.PasswordChar = '●';
            txtNovaSenhaConfirma.Size = new Size(200, 23);
            txtNovaSenhaConfirma.TabIndex = 3;
            //
            // btnSalvarNovaSenha
            //
            btnSalvarNovaSenha.Enabled = false;
            btnSalvarNovaSenha.Location = new Point(318, 140);
            btnSalvarNovaSenha.Name = "btnSalvarNovaSenha";
            btnSalvarNovaSenha.Size = new Size(90, 30);
            btnSalvarNovaSenha.TabIndex = 5;
            btnSalvarNovaSenha.Text = "SALVAR SENHA";
            btnSalvarNovaSenha.UseVisualStyleBackColor = true;
            btnSalvarNovaSenha.Click += btnSalvarNovaSenha_Click;
            //
            // btnCancelar
            //
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelar.ForeColor = SystemColors.ButtonHighlight;
            btnCancelar.Location = new Point(222, 140);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 30);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            //
            // formAlterarSenha
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 188);
            Controls.Add(lblSenhaAtual);
            Controls.Add(txtSenhaAtual);
            Controls.Add(btnValidarSenha);
            Controls.Add(lblNovaSenha);
            Controls.Add(txtNovaSenha);
            Controls.Add(lblConfirmaSenha);
            Controls.Add(txtNovaSenhaConfirma);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvarNovaSenha);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "formAlterarSenha";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Alterar Senha";
            Load += formAlterarSenha_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSenhaAtual;
        private TextBox txtSenhaAtual;
        private Button btnValidarSenha;
        private Label lblNovaSenha;
        private TextBox txtNovaSenha;
        private Label lblConfirmaSenha;
        private TextBox txtNovaSenhaConfirma;
        private Button btnSalvarNovaSenha;
        private Button btnCancelar;
    }
}
