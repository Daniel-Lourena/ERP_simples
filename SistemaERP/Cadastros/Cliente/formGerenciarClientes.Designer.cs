namespace SistemaERP.Cadastros.Cliente
{
    partial class formGerenciarClientes
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
            dgvClientes = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            btnExcluir = new Button();
            btnEditar = new Button();
            btnNovo = new Button();
            ckeOcultaExcluidos = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.BackgroundColor = SystemColors.ActiveBorder;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 83);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowTemplate.Height = 25;
            dgvClientes.Size = new Size(776, 285);
            dgvClientes.TabIndex = 0;
            dgvClientes.RowPrePaint += dgvClientes_RowPrePaint;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(ckeOcultaExcluidos);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 65);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(btnExcluir);
            panel2.Controls.Add(btnEditar);
            panel2.Controls.Add(btnNovo);
            panel2.Location = new Point(12, 373);
            panel2.Name = "panel2";
            panel2.Size = new Size(776, 65);
            panel2.TabIndex = 2;
            // 
            // btnExcluir
            // 
            btnExcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExcluir.BackColor = Color.IndianRed;
            btnExcluir.FlatAppearance.BorderColor = Color.Black;
            btnExcluir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnExcluir.ForeColor = SystemColors.ButtonHighlight;
            btnExcluir.Location = new Point(688, 12);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 44);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "EXCLUIR";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
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
            ckeOcultaExcluidos.AutoSize = true;
            ckeOcultaExcluidos.Checked = true;
            ckeOcultaExcluidos.CheckState = CheckState.Checked;
            ckeOcultaExcluidos.Location = new Point(3, 3);
            ckeOcultaExcluidos.Name = "ckeOcultaExcluidos";
            ckeOcultaExcluidos.Size = new Size(171, 19);
            ckeOcultaExcluidos.TabIndex = 1;
            ckeOcultaExcluidos.Text = "Ocultar cadastros excluidos";
            ckeOcultaExcluidos.UseVisualStyleBackColor = true;
            ckeOcultaExcluidos.CheckedChanged += ckeOcultaExcluidos_CheckedChanged;
            // 
            // formGerenciarClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dgvClientes);
            Name = "formGerenciarClientes";
            Text = "Gerenciar Clientes";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvClientes;
        private Panel panel1;
        private Panel panel2;
        private Button btnNovo;
        private Button btnExcluir;
        private Button btnEditar;
        private CheckBox ckeOcultaExcluidos;
    }
}