using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using SistemaERP.Cadastros.Extensions;
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

namespace SistemaERP.Cadastros.Banco
{
    public partial class formDetalhesBanco : Form
    {
        private int _id = 0;
        private BancoEntity _banco;

        public formDetalhesBanco()
        {
            InitializeComponent();
            CarregarTipoConta();
            CarregarTipoChavePix();
        }

        public formDetalhesBanco(int id) : this()
        {
            _id = id;
        }

        private void CarregarTipoConta()
        {
            cbTipoConta.PreencherComboBoxEnum<ETipoContaBanco>();
        }
        private void CarregarTipoChavePix()
        {
            cbTipoChavePix.PreencherComboBoxEnum<ETipoChavePix>();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            BancoEntity banco = new()
            {
                nome = txtNomeBanco.Text,
                codigo = txtCodigo.Text,
                agencia = txtAgencia.Text,
                agenciaDigito = txtAgenciaDigito.Text,
                conta = txtConta.Text,
                contaDigito = txtContaDigito.Text,
                titularNome = txtNomeTitular.Text,
                titularDocumento = txtTitularDocumento.Text,
                inativo = ckInativo.Checked,
                contaInternacional = ckContaInternacional.Checked,
                dataCadastro = DateTime.Now,
                dataAtualizacao = DateTime.Now,
                tipoConta = (int)cbTipoConta.SelectedValue,
                pixTipoChave = (int)cbTipoChavePix.SelectedValue,
                pixChave = txtChavePix.Text,
                iban = txtIBAN.Text,
                swiftCode = txtSwift.Text
            };

            if (_id == 0)
            {
                new ModuloCadastro.Context.BancoContext(new ModuloCadastroContext()).Insert(banco);
            }
            else
            {
                banco.dataCadastro = _banco.dataCadastro;
                new ModuloCadastro.Context.BancoContext(new ModuloCadastroContext()).Update(banco);
            }
        }

        private void formDetalhesBanco_Load(object sender, EventArgs e)
        {
            if (_id > 0) MostraBanco();
        }

        private void MostraBanco()
        {
            _banco = new BancoContext(new ModuloCadastroContext()).Get(_id);
            txtNomeBanco.Text = _banco.nome;
            txtCodigo.Text = _banco.codigo;
            txtAgencia.Text = _banco.agencia;
            txtAgenciaDigito.Text = _banco.agenciaDigito;
            txtConta.Text = _banco.conta;
            txtContaDigito.Text = _banco.contaDigito;
            txtNomeTitular.Text = _banco.titularNome;
            txtTitularDocumento.Text = _banco.titularDocumento;
            ckInativo.Checked = _banco.inativo;
            ckContaInternacional.Checked = _banco.contaInternacional;
            txtCadastro.Text = _banco.dataCadastro.ToString();
            txtAtualizacao.Text = _banco.dataAtualizacao.ToString();
            cbTipoConta.SelectedValue = _banco.tipoConta;
            cbTipoChavePix.SelectedValue = _banco.pixTipoChave;
            txtChavePix.Text = _banco.pixChave;
            txtIBAN.Text = _banco.iban;
            txtSwift.Text = _banco.swiftCode;

            this.Text = $"REGISTRO [{_banco.id}]";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcBanco_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tabPage = tcBanco.TabPages[e.Index];
            Rectangle tabBounds = tcBanco.GetTabRect(e.Index);

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.TranslateTransform(tabBounds.Left + tabBounds.Width / 2, tabBounds.Top + tabBounds.Height / 2);

                g.DrawString(tabPage.Text, this.Font, SystemBrushes.ControlText, 0, 0, sf);

                g.ResetTransform(); // Reseta a rotação pra não afetar o resto
            }
        }
    }
}
