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
        private RecebimentoVendaEntity _recebimento;
        public formBoleto()
        {
            InitializeComponent();
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
            nudParcelas.DataBindings.Add(nameof(nudParcelas.Value), _recebimento, nameof(_recebimento.TotalParcela));
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
            if (nudValor.Value <= 0)
            {
                MessageBox.Show($"Valor inválido.", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_recebimento.Id == 0)
            {
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
            }
            else
            {
                new RecebimentosVendaService().Update(new RecebimentoVendaEntity()
                {
                    Id = _recebimento.Id,
                    Especie = ModuloCadastro.Enum.ERecebimentoEspecie.BOLETO,
                    NroParcela = _recebimento.NroParcela,
                    TotalParcela = _recebimento.TotalParcela,
                    PedidoId = _idPedido,
                    Vencimento = _recebimento.Vencimento.Date,
                    Valor = _recebimento.Valor,
                    BancoId = Convert.ToInt32(cbBanco.SelectedValue),
                    Descricao = txtObs.Text
                });
            }

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
    }
}
