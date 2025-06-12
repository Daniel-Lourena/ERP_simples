using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using SistemaERP.Extensions;
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
        private RecebimentoVendaEntity _recebimento;
        public formCheque()
        {
            InitializeComponent();
            this.ConfiguraTabIndex();
            CarregaBancos();
        }

        public formCheque(int idPedido) : this()
        {
            _idPedido = idPedido;
        }
        public formCheque(RecebimentoVendaEntity recebimento) : this()
        {
            _recebimento = recebimento;
        }
        private void ConfiguraDataBindings()
        {
            _recebimento = _recebimento ?? new RecebimentoVendaEntity();

            cbBanco.DataBindings.Add(nameof(cbBanco.SelectedValue), _recebimento, nameof(_recebimento.BancoId));
            dtpDataEmissao.DataBindings.Add(nameof(dtpDataEmissao.Value), _recebimento, nameof(_recebimento.DataEmissaoDocumento));
            dtpBomPara.DataBindings.Add(nameof(dtpBomPara.Value), _recebimento, nameof(_recebimento.Vencimento));
            txtNroCheque.DataBindings.Add(nameof(txtNroCheque.Text), _recebimento, nameof(_recebimento.NroDocumento));
            nudValor.DataBindings.Add(nameof(nudValor.Value), _recebimento, nameof(_recebimento.Valor));
            txtObs.DataBindings.Add(nameof(txtObs.Text), _recebimento, nameof(_recebimento.Descricao));
            txtAgencia.DataBindings.Add(nameof(txtAgencia.Text), _recebimento, nameof(_recebimento.Agencia));
            txtDigitoAgencia.DataBindings.Add(nameof(txtDigitoAgencia.Text), _recebimento, nameof(_recebimento.DigitoAgencia));
            txtContaCorrente.DataBindings.Add(nameof(txtContaCorrente.Text), _recebimento, nameof(_recebimento.ContaCorrente));
            txtDigitoContaCorrente.DataBindings.Add(nameof(txtDigitoContaCorrente.Text), _recebimento, nameof(_recebimento.DigitoContaCorrente));
            txtEmissor.DataBindings.Add(nameof(txtEmissor.Text), _recebimento, nameof(_recebimento.NomeEmissor));

            if (_recebimento.Id == 0)
            {
                cbBanco.SelectedIndex = 0;
            }
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

            if (_recebimento.Id == 0)
            {
                new RecebimentosVendaService().Insert(new RecebimentoVendaEntity()
                {
                    Especie = EFormaPagamento.CHEQUE,
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
            }
            else
            {
                new RecebimentosVendaService().Update(new RecebimentoVendaEntity()
                {
                    Especie = EFormaPagamento.CHEQUE,
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
            }

            this.Close();
        }

        private void formCheque_Load(object sender, EventArgs e)
        {
            ConfiguraDataBindings();
            if (_recebimento.Id > 0)
            {
                btnAdicionar.Text = "SALVAR";
                nudValor.ReadOnly = true;
            }
        }
    }
}
