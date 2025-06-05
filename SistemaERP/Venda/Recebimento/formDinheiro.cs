using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP.Venda.Recebimento
{
    public partial class formDinheiro : Form
    {
        private int _idPedido;
        public formDinheiro(int idPedido)
        {
            InitializeComponent();
            _idPedido = idPedido;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (nudValor.Value <= 0)
            {
                MessageBox.Show($"Valor inválido.", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            new RecebimentosVendaService().Insert(new RecebimentoVendaEntity()
            {
                Especie = ModuloCadastro.Enum.ERecebimentoEspecie.DINHEIRO,
                NroParcela = 1,
                TotalParcela = 1,
                PedidoId = _idPedido,
                Vencimento = DateTime.Now.Date,
                Valor = nudValor.Value,
                Descricao = txtObs.Text
            });
            this.Close();
        }
    }
}
