using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
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
        public RecebimentoVendaEntity _recebimento;

        public formDinheiro()
        {
            InitializeComponent();
        }

        public formDinheiro(int idPedido, RecebimentoVendaEntity recebimento = null) : this()
        {
            _idPedido = idPedido;
        }

        public formDinheiro(RecebimentoVendaEntity recebimento = null) : this()
        {
            _recebimento = recebimento;
        }

        private void ConfiguraDataBindings()
        {
            _recebimento = _recebimento ?? new RecebimentoVendaEntity();

            txtObs.DataBindings.Add(nameof(txtObs.Text), _recebimento, nameof(_recebimento.Descricao));
            nudValor.DataBindings.Add(nameof(nudValor.Value), _recebimento, nameof(_recebimento.Valor));
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
                    Especie = ModuloCadastro.Enum.ERecebimentoEspecie.DINHEIRO,
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
                    Especie = ModuloCadastro.Enum.ERecebimentoEspecie.DINHEIRO,
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


        private void formDinheiro_Load(object sender, EventArgs e)
        {
            ConfiguraDataBindings();
            if (_recebimento.Id > 0) btnAdicionar.Text = "SALVAR";
        }

    }
}
