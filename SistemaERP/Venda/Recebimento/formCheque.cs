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
    public partial class formCheque : Form
    {
        private int _idPedido;
        public formCheque(int idPedido)
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

            new RecebimentosVendaService().Insert(new RecebimentoVendaEntity()
            {
                Especie = ModuloCadastro.Enum.ERecebimentoEspecie.CHEQUE,
                NroParcela = 1,
                TotalParcela = 1,
                PedidoId = _idPedido,
                DataEmissaoDocumento = dtpDataEmissao.Value.Date,
                Vencimento = dtpBomPara.Value.Date,
                Valor = nudValor.Value,
                NroDocumento = txtNroCheque.Text,
                NomeEmissor = txtEmissor.Text,
                BancoId = Convert.ToInt32(cbBanco.SelectedValue),
                Agencia = txtAgencia.Text,
                DigitoAgencia = txtDigitoAgencia.Text,
                ContaCorrente = txtContaCorrente.Text,
                DigitoContaCorrente = txtDigitoContaCorrente.Text,
                Descricao = txtObs.Text
            });

            this.Close();
        }

    }
}
