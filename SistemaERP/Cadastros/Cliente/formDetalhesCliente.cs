using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
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
                end_nomeRua = txtRua.Text,
                end_bairro = txtBairro.Text,
                end_cidade = cbCidades.SelectedValue as string,
                end_uf = cbEstados.SelectedValue as string,
                dataCadastro = DateTime.Now,
                dataAtualizacao = DateTime.Now,
                limiteCredito = nudLimite.Value
            };

            if (_id == 0)
            {
                new ModuloCadastro.Context.ClienteContext().Insert(cliente);
            }
            else
            {
                cliente.dataCadastro = _cliente.dataCadastro;
                new ModuloCadastro.Context.ClienteContext().Update(cliente);
            }
        }

        private void formDetalhesCliente_Load(object sender, EventArgs e)
        {
            if (_id > 0) MostraUsuario();
        }

        private void MostraUsuario()
        {
            _cliente = new ClienteContext().Get(_id);
            txtFantasia.Text = _cliente.fantasia;
            txtRazaoSocial.Text = _cliente.razaoSocial;
            txtLogradouro.Text = _cliente.end_logradouro;
            txtRua.Text = _cliente.end_nomeRua;
            txtNro.Text = _cliente.end_numero;
            txtBairro.Text = _cliente.end_bairro;
            txtCadastro.Text = _cliente.dataCadastro.ToString();
            txtAtualizacao.Text = _cliente.dataAtualizacao.ToString();
            cbCidades.SelectedValue = _cliente.end_cidade;
            cbEstados.SelectedValue = _cliente.end_uf;

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
                g.RotateTransform(-90); // Rotaciona 90° no sentido anti-horário

                g.DrawString(tabPage.Text, this.Font, SystemBrushes.ControlText, 0, 0, sf);

                g.ResetTransform(); // Reseta a rotação pra não afetar o resto
            }
        }

        private void cbEstado_SelectedValueChanged(object sender, EventArgs e)
        {
            cbCidades.GetListCidades((int)cbEstados.SelectedValue);
        }
    }
}
