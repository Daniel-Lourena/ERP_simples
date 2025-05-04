namespace SistemaERP.Cadastros.Banco
{
    partial class formGerenciarBancos
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
            dgvBancos = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            btnEditar = new Button();
            btnNovo = new Button();
            ckeOcultaInativos = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvBancos).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBancos
            // 
            dgvBancos.AllowUserToAddRows = false;
            dgvBancos.AllowUserToDeleteRows = false;
            dgvBancos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBancos.BackgroundColor = SystemColors.ActiveBorder;
            dgvBancos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBancos.Location = new Point(12, 83);
            dgvBancos.Name = "dgvBancos";
            dgvBancos.ReadOnly = true;
            dgvBancos.RowTemplate.Height = 25;
            dgvBancos.Size = new Size(776, 285);
            dgvBancos.TabIndex = 0;
            dgvBancos.RowPrePaint += dgvBancos_RowPrePaint;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(ckeOcultaInativos);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 65);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(btnEditar);
            panel2.Controls.Add(btnNovo);
            panel2.Location = new Point(12, 373);
            panel2.Name = "panel2";
            panel2.Size = new Size(776, 65);
            panel2.TabIndex = 2;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditar.FlatAppearance.BorderColor = Color.Black;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditar.Location = new Point(102, 12);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 44);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "EDITAR";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNovo.BackColor = SystemColors.ActiveCaption;
            btnNovo.FlatAppearance.BorderColor = Color.Black;
            btnNovo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnNovo.ForeColor = SystemColors.ButtonHighlight;
            btnNovo.Location = new Point(12, 12);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(75, 44);
            btnNovo.TabIndex = 0;
            btnNovo.Text = "NOVO";
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += btnNovo_Click;
            // 
            // ckeOcultaInativos
            // 
            ckeOcultaInativos.AutoSize = true;
            ckeOcultaInativos.Checked = true;
            ckeOcultaInativos.CheckState = CheckState.Checked;
            ckeOcultaInativos.Location = new Point(3, 3);
            ckeOcultaInativos.Name = "ckeOcultaInativos";
            ckeOcultaInativos.Size = new Size(162, 19);
            ckeOcultaInativos.TabIndex = 3;
            ckeOcultaInativos.Text = "Ocultar cadastros inativos";
            ckeOcultaInativos.UseVisualStyleBackColor = true;
            ckeOcultaInativos.CheckedChanged += ckeOcultaInativos_CheckedChanged;
            // 
            // formGerenciarBancos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dgvBancos);
            Name = "formGerenciarBancos";
            Text = "Gerenciar Clientes";
            ((System.ComponentModel.ISupportInitialize)dgvBancos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvBancos;
        private Panel panel1;
        private Panel panel2;
        private Button btnNovo;
        private Button btnEditar;
        private CheckBox ckeOcultaInativos;
    }
}