namespace SistemaERP.Cadastros.Produto.SetorEstoque
{
    partial class formGerenciarSetorEstoqueProduto
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
            dgvSetorEstoque = new DataGridView();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvSetorEstoque).BeginInit();
            SuspendLayout();
            // 
            // dgvSetorEstoque
            // 
            dgvSetorEstoque.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSetorEstoque.BackgroundColor = SystemColors.ActiveBorder;
            dgvSetorEstoque.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSetorEstoque.Location = new Point(12, 83);
            dgvSetorEstoque.Name = "dgvSetorEstoque";
            dgvSetorEstoque.RowTemplate.Height = 25;
            dgvSetorEstoque.Size = new Size(776, 355);
            dgvSetorEstoque.TabIndex = 0;
            dgvSetorEstoque.CellEndEdit += dgvSetorEstoque_CellEndEdit;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 65);
            panel1.TabIndex = 1;
            // 
            // formGerenciarSetorEstoqueProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(dgvSetorEstoque);
            Name = "formGerenciarSetorEstoqueProduto";
            Text = "Gerenciar Setores Estoque";
            ((System.ComponentModel.ISupportInitialize)dgvSetorEstoque).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private DataGridView dgvSetorEstoque;
        private Panel panel1;
    }
}