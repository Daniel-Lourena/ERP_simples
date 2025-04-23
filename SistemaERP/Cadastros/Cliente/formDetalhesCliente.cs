using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using SistemaERP.Cadastros.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP.Cadastros.Cliente
{
    public partial class formDetalhesCliente : Form
    {
        private int _id = 0;
        private ClienteEntity _cliente;

        public formDetalhesCliente()
        {
            InitializeComponent();
            CarregaEstado();
        }
        public formDetalhesCliente(int id) : this()
        {
            _id = id;
        }

        public void CarregaEstado()
        {
            cbEstados.GetListEstados();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ClienteEntity cliente = new()
            {
                fantasia = txtFantasia.Text,
                razaoSocial = txtRazaoSocial.Text,
                end_logradouro = txtLogradouro.Text,
                end_numero = txtNro.Text,
                end_nomeRua = txtRua.Text,
                end_bairro = txtBairro.Text,
                end_cidade = (int)cbCidades.SelectedValue,
                end_uf = (int)cbEstados.SelectedValue,
                dataCadastro = DateTime.Now,
                dataAtualizacao = DateTime.Now,
                limiteCredito = nudLimite.Value
            };

            if (_id == 0)
            {
                using (var autoNumeradorContext = new ModuloCadastro.Context.AutoNumeradorContext(new ModuloCadastroContext()))
                {
                    AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                    numerador.idCliente++;
                    cliente.id = numerador.idCliente;
                    new ModuloCadastro.Context.ClienteContext(new ModuloCadastroContext()).Insert(cliente);
                    ContextMethods.UpdateParcial<AutoNumeradorEntity>(numerador,new List<string>() { nameof(AutoNumeradorEntity.idCliente) });
                }
            }
            else
            {
                cliente.dataCadastro = _cliente.dataCadastro;
                new ModuloCadastro.Context.ClienteContext(new ModuloCadastroContext()).Update(cliente);
            }
        }

        private void formDetalhesCliente_Load(object sender, EventArgs e)
        {
            if (_id > 0) MostraCliente();
        }

        private void MostraCliente()
        {
            _cliente = new ClienteContext(new ModuloCadastroContext()).Get(_id);
            txtFantasia.Text = _cliente.fantasia;
            txtRazaoSocial.Text = _cliente.razaoSocial;
            txtLogradouro.Text = _cliente.end_logradouro;
            txtRua.Text = _cliente.end_nomeRua;
            txtNro.Text = _cliente.end_numero;
            txtBairro.Text = _cliente.end_bairro;
            txtCadastro.Text = _cliente.dataCadastro.ToString();
            txtAtualizacao.Text = _cliente.dataAtualizacao.ToString();
            cbEstados.SelectedValue = _cliente.end_uf;
            cbCidades.SelectedValue = _cliente.end_cidade;

            if (_cliente.excluido)
            {
                lblDataExclusao.Visible = true;
                txtExclusao.Visible = true;
                txtExclusao.Text = _cliente.dataExclusao.ToString();
            }
            this.Text = $"REGISTRO [{_cliente.id}]";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcCliente_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tabPage = tcCliente.TabPages[e.Index];
            Rectangle tabBounds = tcCliente.GetTabRect(e.Index);

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.TranslateTransform(tabBounds.Left + tabBounds.Width / 2, tabBounds.Top + tabBounds.Height / 2);

                g.DrawString(tabPage.Text, this.Font, SystemBrushes.ControlText, 0, 0, sf);

                g.ResetTransform(); // Reseta a rotação pra não afetar o resto
            }
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCidades.GetListCidades((int)cbEstados.SelectedValue);
        }
    }
}
