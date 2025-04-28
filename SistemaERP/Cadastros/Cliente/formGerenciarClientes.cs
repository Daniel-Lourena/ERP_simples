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

namespace SistemaERP.Cadastros.Cliente
{
    public partial class formGerenciarClientes : Form
    {
        ModuloCadastro.Context.ModuloCadastroContext _db_context;
        public formGerenciarClientes(ModuloCadastroContext db_context)
        {
            _db_context = db_context;
            InitializeComponent();
            CarregaClientes();
        }

        private void CarregaClientes()
        {
            var listaDataSource = new ModuloCadastro.Service.ClienteService(_db_context).GetList().Select(x => new ClienteEntity { id = x.id, fantasia = x.fantasia, DadosCidade = x.DadosCidade }).ToList();
            dgvClientes.CriarColunasDataGridView(listaDataSource, new List<(string,bool)>()
            { 
                (nameof(ClienteEntity.id),true), (nameof(ClienteEntity.fantasia),true),
                (nameof(ClienteEntity.DadosCidade.cuf),true),(nameof(ClienteEntity.DadosCidade.dmunicipio),true)
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesCliente().ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                new formDetalhesCliente(Convert.ToInt32(dgvClientes.CurrentRow.Cells[nameof(ClienteEntity.id)].Value)).ShowDialog();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir os clientes selecionados?", String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new ModuloCadastro.Service.ClienteService(new ModuloCadastroContext()).UpdateParcial(new ClienteEntity()
                {
                    dataExclusao = DateTime.Now,
                    excluido = true
                }, new List<string>() { nameof(ClienteEntity.dataExclusao), nameof(ClienteEntity.excluido) });

                CarregaClientes();
            }
        }
    }
}
