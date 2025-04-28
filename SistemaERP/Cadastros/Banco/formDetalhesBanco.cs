using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModuloCadastro.Service;
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

        private void ConfigurarDataBinding()
        {
            _banco = _banco ?? new BancoEntity();
            cbTipoConta.DataBindings.Add(nameof(cbTipoConta.SelectedValue), _banco, nameof(_banco.tipoConta));
            txtAtualizacao.DataBindings.Add(nameof(txtAtualizacao.Text), _banco, nameof(_banco.dataAtualizacao));
            txtCadastro.DataBindings.Add(nameof(txtCadastro.Text), _banco, nameof(_banco.dataCadastro));
            txtNomeBanco.DataBindings.Add(nameof(txtNomeBanco.Text), _banco, nameof(_banco.nome));
            txtCodigo.DataBindings.Add(nameof(txtCodigo.Text), _banco, nameof(_banco.codigo));
            txtAgenciaDigito.DataBindings.Add(nameof(txtAgenciaDigito.Text), _banco, nameof(_banco.agenciaDigito));
            txtAgencia.DataBindings.Add(nameof(txtAgencia.Text), _banco, nameof(_banco.agencia));
            txtContaDigito.DataBindings.Add(nameof(txtContaDigito.Text), _banco, nameof(_banco.contaDigito));
            txtConta.DataBindings.Add(nameof(txtConta.Text), _banco, nameof(_banco.conta));
            txtNomeTitular.DataBindings.Add(nameof(txtNomeTitular.Text), _banco, nameof(_banco.titularNome));
            txtTitularDocumento.DataBindings.Add(nameof(txtTitularDocumento.Text), _banco, nameof(_banco.titularDocumento));
            cbTipoChavePix.DataBindings.Add(nameof(cbTipoChavePix.SelectedValue), _banco, nameof(_banco.pixTipoChave));
            txtChavePix.DataBindings.Add(nameof(txtChavePix.Text), _banco, nameof(_banco.pixChave));
            ckContaInternacional.DataBindings.Add(nameof(ckContaInternacional.Checked), _banco, nameof(_banco.contaInternacional));
            ckInativo.DataBindings.Add(nameof(ckInativo.Checked), _banco, nameof(_banco.inativo));
            txtIBAN.DataBindings.Add(nameof(txtIBAN.Text), _banco, nameof(_banco.iban));
            txtSwift.DataBindings.Add(nameof(txtSwift.Text), _banco, nameof(_banco.swiftCode));
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
            if (_id == 0)
            {
                new ModuloCadastro.Service.BancoService(new ModuloCadastroContext()).Insert(_banco);
            }
            else
            {
                _banco.dataAtualizacao = DateTime.Now;
                new ModuloCadastro.Service.BancoService(new ModuloCadastroContext()).Update(_banco);
            }
        }

        private void formDetalhesBanco_Load(object sender, EventArgs e)
        {
            if (_id > 0) MostraBanco();

            ConfigurarDataBinding();
        }

        private void MostraBanco()
        {
            _banco = new BancoService(new ModuloCadastroContext()).Get(_id);
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
