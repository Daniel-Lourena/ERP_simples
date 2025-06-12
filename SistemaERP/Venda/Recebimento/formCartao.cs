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
    public partial class formCartao : Form
    {
        private int _idPedido;
        private RecebimentoVendaEntity _recebimento;
        private EFormaPagamento _formaPagamento;
        public formCartao()
        {
            InitializeComponent();
            this.ConfiguraTabIndex();
            CarregaMaquininhas();
            CarregaBandeiras();
        }
        public formCartao(EFormaPagamento formaPagamento,int idPedido) : this()
        {
            _idPedido = idPedido; 
            _formaPagamento = formaPagamento;
        }
        public formCartao(RecebimentoVendaEntity recebimento) : this()
        {
            _recebimento = recebimento;
            _idPedido = recebimento.PedidoId;
        }

        private void ConfiguraDataBindings()
        {
            _recebimento = _recebimento ?? new RecebimentoVendaEntity();

            cbMaquininhas.DataBindings.Add(nameof(cbMaquininhas.SelectedValue), _recebimento, nameof(_recebimento.MaquininhaId));
            cbBandeiras.DataBindings.Add(nameof(cbBandeiras.SelectedValue), _recebimento, nameof(_recebimento.BandeiraCartao));
            nudValor.DataBindings.Add(nameof(nudValor.Value), _recebimento, nameof(_recebimento.Valor));
            txtObs.DataBindings.Add(nameof(txtObs.Text), _recebimento, nameof(_recebimento.Descricao));

            if (_recebimento.Id == 0)
            {
                nudParcelas.Value = 1;
                cbMaquininhas.SelectedIndex = 0;
            }
        }
        private void CarregaMaquininhas()
        {
            cbMaquininhas.PreencherComboBoxList<MaquininhaEntity>(new MaquininhaService().GetList().ToList(),nameof(MaquininhaEntity.Id),nameof(MaquininhaEntity.Nome),true);
        }
        private void CarregaBandeiras()
        {
            cbBandeiras.PreencherComboBoxEnum<EBandeiraCartao>();
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
                    BancoId = Convert.ToInt32(cbMaquininhas.SelectedValue),
                    Descricao = row.Descricao
                });
            }

            this.Close();
        }

        private void formCartao_Load(object sender, EventArgs e)
        {
            ConfiguraDataBindings();
            if (_formaPagamento == EFormaPagamento.CARTAO_DEBITO) 
                lblCartao.Text = "CARTÃO DÉBITO";
            else
                lblCartao.Text = "CARTÃO CRÉBITO";

            if (_recebimento.Id > 0)
            {
                btnAdicionar.Text = "SALVAR";
                nudParcelas.ReadOnly = true;
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
            //if (nudParcelas.Value > (cbMaquininhas.SelectedItem as MaquininhaEntity).NroParcelas)
            //{
            //    MessageBox.Show($"Quantidade de parcelas inválida. Número máximo de parcelas permitido {((cbMaquininhas.SelectedItem as MaquininhaEntity).NroParcelas)}", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            DateTime dataParcela = DateTime.Now.Date;
            decimal valorTotal = nudValor.Value;

            List<RecebimentoVendaEntity> parcelaCalculada = new();
            for (int i = 1; i <= nudParcelas.Value; i++)
            {
                var valorParcela = Math.Round(nudValor.Value / nudParcelas.Value);

                if ((valorTotal - valorParcela) < 0 || nudParcelas.Value == i) valorParcela = valorTotal;

                parcelaCalculada.Add(new RecebimentoVendaEntity
                {
                    Valor = valorParcela,
                    Descricao = txtObs.Text,
                    Vencimento = dataParcela,
                    NroParcela = i
                });

                dataParcela = dataParcela.AddMonths(1);
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
    }
}
