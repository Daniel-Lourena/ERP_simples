using ModuloCadastro.Context;
using ModuloCadastro.Enum;
using SistemaERP.Generico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP.Vendas
{
    public partial class formDetalhesVenda : Form
    {
        private int _idPedido = 0;
        public formDetalhesVenda()
        {
            InitializeComponent();
        }
        public formDetalhesVenda(int idPedido) : this()
        {
            _idPedido = idPedido;
        }

        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            new formAdicionarProdutosPedido(ETipoPedido.VENDA, _idPedido).ShowDialog();
        }
    }
}
