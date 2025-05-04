using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using ModuloCadastro.ViewModel;
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

namespace SistemaERP.Cadastros.Produto.Categoria
{
    public partial class formGerenciarCategoriasProduto : Form
    {
        private ModuloCadastro.Context.ModuloCadastroContext _db_context;

        public formGerenciarCategoriasProduto(ModuloCadastroContext db_context)
        {
            _db_context = db_context;
            InitializeComponent();
            CarregaCategorias();
        }

        private void CarregaCategorias()
        {
            List<CategoriaViewModel> _listaDataSource = new List<CategoriaViewModel>(new ModuloCadastro.Service.CategoriaService(_db_context).GetList()
            .Select(x => new CategoriaViewModel
            {
                id = x.id,
                descricao = x.descricao
            }).ToList());

            dgvCategorias.CriarColunasDataGridView(_listaDataSource, new()
            {
                (nameof(CategoriaViewModel.id), true,false), (nameof(CategoriaViewModel.descricao), false,true)
            });
        }

        private void dgvCategorias_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CategoriaViewModel row = dgvCategorias.Rows[e.RowIndex].DataBoundItem as CategoriaViewModel;

            if (row.id == 0)
            {
                new ModuloCadastro.Service.CategoriaService(_db_context).Insert(row.ToEntity());
            }
            else
            {
                new ModuloCadastro.Service.CategoriaService(_db_context).Update(row.ToEntity());
            }
            CarregaCategorias();
        }
    }
}
