using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using SistemaERP.Cadastros.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP.Cadastros.Banco
{
    public partial class formGerenciarBancos : Form
    {
        ModuloCadastro.Context.ModuloCadastroContext _db_context;
        public formGerenciarBancos(ModuloCadastroContext db_context)
        {
            _db_context = db_context;
            InitializeComponent();
            CarregaBancos();
        }

        private void CarregaBancos()
        {
            var listaDataSource = new ModuloCadastro.Service.BancoService(_db_context).GetList();
            dgvBancos.CriarColunasDataGridView(listaDataSource, new()
            { 
                (nameof(BancoEntity.id),true,true), (nameof(BancoEntity.nome),true,true),
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesBanco().ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvBancos.CurrentRow != null)
            {
                new formDetalhesBanco(Convert.ToInt32(dgvBancos.CurrentRow.Cells[nameof(BancoEntity.id)].Value)).ShowDialog();
            }
        }
    }
}
