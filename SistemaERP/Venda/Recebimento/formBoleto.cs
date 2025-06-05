using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using SistemaERP.Cadastros.Extensions;
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
    public partial class formBoleto : Form
    {
        private int _idPedido;
        public formBoleto(int idPedido)
        {
            InitializeComponent();
            CarregaBancos();
            _idPedido = idPedido;
        }

        private void CarregaBancos()
        {
            cbBanco.PreencherComboBoxList(
                new BancoService(new ModuloCadastro.Context.ModuloCadastroContext())
                .GetList().Where(x => x.Inativo == false)
                .Select(x => new BancoEntity { Id = x.Id, Nome = x.Nome }).ToList(),
                nameof(BancoEntity.Id), nameof(BancoEntity.Nome), true);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (nudValor.Value <= 0)
            {
                MessageBox.Show($"Valor inválido.", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime dataParcela = DateTime.Now.Date;
            decimal valorTotal = nudValor.Value;

            for (int i = 1; i <= nudParcelas.Value; i++)
            {
                if (i == 1)
                    dataParcela = dataParcela.AddDays(Convert.ToInt32(nudPrimeiraParcela.Value));
                else
                    dataParcela = dataParcela.AddDays(Convert.ToInt32(nudDemaisParcelas.Value));

                var valorParcela = Math.Round(nudValor.Value / nudParcelas.Value);

                if ((valorTotal - valorParcela) < 0 || nudParcelas.Value == i) valorParcela = valorTotal;

                new RecebimentosVendaService().Insert(new RecebimentoVendaEntity()
                {
                    Especie = ModuloCadastro.Enum.ERecebimentoEspecie.BOLETO,
                    NroParcela = i,
                    TotalParcela = Convert.ToInt32(nudParcelas.Value),
                    PedidoId = _idPedido,
                    Vencimento = dataParcela,
                    Valor = valorParcela,
                    BancoId = Convert.ToInt32(cbBanco.SelectedValue),
                    Descricao = txtObs.Text
                });

                valorTotal -= valorParcela;
            }

            this.Close();
        }

        private void nudParcelas_ValueChanged(object sender, EventArgs e)
        {
            if (nudParcelas.Value > 1) nudDemaisParcelas.Enabled = true;
            else nudDemaisParcelas.Enabled = false;
        }
    }
}
