namespace SistemaERP.Generico
{
    partial class formAdicionarClientes
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
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Dock = DockStyle.Fill;
            dgvClientes.Location = new Point(0, 0);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowTemplate.Height = 25;
            dgvClientes.Size = new Size(681, 263);
            dgvClientes.TabIndex = 0;
            dgvClientes.DoubleClick += dgvClientes_DoubleClick;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 263);
            panel1.Name = "panel1";
            panel1.Size = new Size(681, 71);
            panel1.TabIndex = 1;
            // 
            // formAdicionarProdutosPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 334);
            Controls.Add(dgvClientes);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "formAdicionarClientes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adicionar clientes";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvClientes;
        private Panel panel1;
    }
}