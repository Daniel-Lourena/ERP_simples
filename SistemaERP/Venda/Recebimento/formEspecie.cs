using ModuloCadastro.Context;
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
    public partial class formEspecie : Form
    {
        private RecebimentoVendaEntity _recebimento;
        private int _idPedido;
        private EFormaPagamento _formaPagamento;

        public formEspecie()
        {
            InitializeComponent();
            this.ConfiguraTabIndex();
            CarregarTipoTransferencia();
        }

        public formEspecie(EFormaPagamento formaPagamento,int idPedido) : this()
        {
            _formaPagamento = formaPagamento;
            _idPedido = idPedido;
        }
        public formEspecie(RecebimentoVendaEntity recebimento) : this()
        {
            _recebimento = recebimento;
            _formaPagamento = recebimento.Especie;
            _idPedido = recebimento.PedidoId;
        }

        private void ConfiguraDataBindings()
        {
            _recebimento = _recebimento ?? new RecebimentoVendaEntity();

            cbTipoTransferencia.DataBindings.Add(nameof(cbTipoTransferencia.SelectedValue), _recebimento, nameof(_recebimento.TipoTransferencia));
            txtObs.DataBindings.Add(nameof(txtObs.Text), _recebimento, nameof(_recebimento.Descricao));
            nudValor.DataBindings.Add(nameof(nudValor.Value), _recebimento, nameof(_recebimento.Valor));
        }
        private void CarregarTipoTransferencia()
        {
            cbTipoTransferencia.PreencherComboBoxEnum<ETipoTransferencia>(true);
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
                    Especie = _formaPagamento,
                    TipoTransferencia = _formaPagamento == EFormaPagamento.TRANSFERENCIA ? (ETipoTransferencia)Convert.ToInt32(cbTipoTransferencia.SelectedValue) : 0,
                    NroParcela = 1,
                    TotalParcela = 1,
                    PedidoId = _idPedido,
                    Vencimento = DateTime.Now.Date,
                    Valor = nudValor.Value,
                    Descricao = txtObs.Text
                });
            }
            else
            {
                new RecebimentosVendaService().Update(new RecebimentoVendaEntity()
                {
                    Id = _recebimento.Id,
                    Especie = _recebimento.Especie,
                    TipoTransferencia = _recebimento.TipoTransferencia,
                    NroParcela = 1,
                    TotalParcela = 1,
                    PedidoId = _idPedido,
                    Vencimento = DateTime.Now.Date,
                    Valor = nudValor.Value,
                    Descricao = txtObs.Text
                });
            }

            this.Close();
        }


        private void formEspecie_Load(object sender, EventArgs e)
        {
            ConfiguraDataBindings();
            if(_formaPagamento == EFormaPagamento.DINHEIRO)
            {
                cbTipoTransferencia.Visible = false;
            }
            else
            {
                cbTipoTransferencia.Visible = true;
                lblEspecie.Text = "TRANSFERÊNCIA";
            }

            if (_recebimento.Id > 0) btnAdicionar.Text = "SALVAR";
        }
    }
}
