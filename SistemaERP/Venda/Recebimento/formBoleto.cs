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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP.Venda.Recebimento
{
    public partial class formBoleto : Form
    {
        private int _idPedido;
        private RecebimentoVendaEntity _recebimento;
        private bool _atualizarData = true;
        private bool _atualizandoData = false;
        public formBoleto()
        {
            InitializeComponent();
            this.ConfiguraTabIndex();
            CarregaBancos();
        }
        public formBoleto(int idPedido) : this()
        {
            _idPedido = idPedido;
        }
        public formBoleto(RecebimentoVendaEntity recebimento) : this()
        {
            _recebimento = recebimento;
            _idPedido = recebimento.PedidoId;
        }

        private void ConfiguraDataBindings()
        {
            _recebimento = _recebimento ?? new RecebimentoVendaEntity();

            cbBanco.DataBindings.Add(nameof(cbBanco.SelectedValue), _recebimento, nameof(_recebimento.BancoId));
            //nudParcelas.DataBindings.Add(nameof(nudParcelas.Value), _recebimento, nameof(_recebimento.TotalParcela));
            nudValor.DataBindings.Add(nameof(nudValor.Value), _recebimento, nameof(_recebimento.Valor));
            txtObs.DataBindings.Add(nameof(txtObs.Text), _recebimento, nameof(_recebimento.Descricao));

            if (_recebimento.Id == 0)
            {
                nudParcelas.Value = 1;
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
            foreach (var row in ((BindingList<RecebimentoVendaEntity>)dgvParcelas.DataSource).OrderBy(x => x.NroParcela))
            {
                new RecebimentosVendaService().Insert(new RecebimentoVendaEntity()
                {
                    Especie = EFormaPagamento.BOLETO,
                    NroParcela = row.NroParcela,
                    TotalParcela = Convert.ToInt32(nudParcelas.Value),
                    PedidoId = _idPedido,
                    Vencimento = row.Vencimento,
                    Valor = row.Valor,
                    BancoId = Convert.ToInt32(cbBanco.SelectedValue),
                    Descricao = row.Descricao
                });
            }

            //new RecebimentosVendaService().Update(new RecebimentoVendaEntity()
            //{
            //    Id = _recebimento.Id,
            //    Especie = ModuloCadastro.Enum.ERecebimentoEspecie.BOLETO,
            //    NroParcela = _recebimento.NroParcela,
            //    TotalParcela = _recebimento.TotalParcela,
            //    PedidoId = _idPedido,
            //    Vencimento = _recebimento.Vencimento.Date,
            //    Valor = _recebimento.Valor,
            //    BancoId = Convert.ToInt32(cbBanco.SelectedValue),
            //    Descricao = txtObs.Text
            //});

            this.Close();
        }

        private void nudParcelas_ValueChanged(object sender, EventArgs e)
        {
            if (nudParcelas.Value > 1) nudDemaisParcelas.Enabled = true;
            else nudDemaisParcelas.Enabled = false;
        }
        private void formBoleto_Load(object sender, EventArgs e)
        {
            ConfiguraDataBindings();
            if (_recebimento.Id > 0)
            {
                btnAdicionar.Text = "SALVAR";
                nudParcelas.ReadOnly = true;
                nudPrimeiraParcela.ReadOnly = true;
                nudValor.ReadOnly = true;
            }
        }

        private void btnCalcularParcelas_Click(object sender, EventArgs e)
        {
            if (nudValor.Value <= 0)
            {
                MessageBox.Show($"Valor inválido.", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime dataParcela = DateTime.Now.Date;
            decimal valorTotal = nudValor.Value;

            List<RecebimentoVendaEntity> parcelaCalculada = new();
            for (int i = 1; i <= nudParcelas.Value; i++)
            {
                if (i == 1)
                    dataParcela = dataParcela.AddDays(Convert.ToInt32(nudPrimeiraParcela.Value));
                else
                    dataParcela = dataParcela.AddDays(Convert.ToInt32(nudDemaisParcelas.Value));

                var valorParcela = Math.Round(nudValor.Value / nudParcelas.Value);

                if ((valorTotal - valorParcela) < 0 || nudParcelas.Value == i) valorParcela = valorTotal;

                parcelaCalculada.Add(new RecebimentoVendaEntity
                {
                    Valor = valorParcela,
                    Descricao = txtObs.Text,
                    Vencimento = dataParcela,
                    NroParcela = i
                });

                valorTotal -= valorParcela;
            }

            dgvParcelas.CriarColunasDataGridView<RecebimentoVendaEntity>(parcelaCalculada,
                new()
                {
                    (nameof(RecebimentoVendaEntity.Valor),false,true),
                    (nameof(RecebimentoVendaEntity.Descricao),false,true),
                    (nameof(RecebimentoVendaEntity.Vencimento),false,true),
                    (nameof(RecebimentoVendaEntity.NroParcela),true,false)
                });
        }

        private void dtpVencimento_ValueChanged(object sender, EventArgs e)
        {
            if (_atualizarData && _atualizandoData is false)
            {
                _atualizandoData = true;
                TimeSpan diferencaDias = dtpVencimento.Value.Date - DateTime.Now.Date;
                nudPrimeiraParcela.Value = diferencaDias.Days;
                _atualizandoData = false;
            }
        }

        private void nudPrimeiraParcela_ValueChanged(object sender, EventArgs e)
        {
            if (_atualizarData && _atualizandoData is false)
            {
                _atualizandoData = true;
                dtpVencimento.Value = DateTime.Now.Date.AddDays(Convert.ToInt32(nudPrimeiraParcela.Value));
                _atualizandoData = false;
            }
        }
    }
}
