using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using SistemaERP.Cadastros.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP.Vendas
{
    public partial class formGerenciarVendas : Form
    {
        private ModuloCadastro.Context.ModuloCadastroContext _db_context;

        public formGerenciarVendas(ModuloCadastroContext db_context)
        {
            _db_context = db_context;
            InitializeComponent();
            CarregaVendas();
        }

        private void CarregaVendas()
        {
            var listaDataSource = new ModuloCadastro.Service.PedidoVendaService(_db_context).GetList().Select(x => new PedidoVendaEntity { id = x.id, idCliente = x.idCliente, dataCriacao = x.dataCriacao }).ToList();

            dgvVendas.CriarColunasDataGridView(listaDataSource, new List<(string, bool)>()
            {
                (nameof(PedidoVendaEntity.id),true), (nameof(PedidoVendaEntity.idCliente),true),
                (nameof(PedidoVendaEntity.dataCriacao),true)
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesVenda().ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVendas.CurrentRow != null)
            {
                new formDetalhesVenda(Convert.ToInt32(dgvVendas.CurrentRow.Cells[nameof(PedidoVendaEntity.id)].Value)).ShowDialog();
            }
        }
    }
}
