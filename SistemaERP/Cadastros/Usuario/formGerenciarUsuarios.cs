using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;
using SistemaERP.Cadastros.Extensions;
using System.Data;

namespace SistemaERP.Cadastros.Usuario
{
    public partial class formGerenciarUsuarios : Form
    {
        private ModuloCadastro.Context.ModuloCadastroContext _db_context;

        public formGerenciarUsuarios(ModuloCadastroContext db_context)
        {
            _db_context = db_context;
            InitializeComponent();
            CarregaUsuarios();
        }

        private void CarregaUsuarios()
        {
            List<UsuarioViewModel> listaDataSource = new();
            if (ckeOcultaExcluidos.Checked)
            {
                listaDataSource = new ModuloCadastro.Service.UsuarioService(_db_context).GetList()
                .Where(x => !x.excluido)
                .Select(x => new UsuarioViewModel
                { id = x.id, nome = x.nome, cargo = x.cargo, dataCadastro = x.dataCadastro, dataAtualizacao = x.dataAtualizacao, excluido = x.excluido })
                .ToList();
            }
            else
            {
                listaDataSource = new ModuloCadastro.Service.UsuarioService(_db_context).GetList()
                .Select(x => new UsuarioViewModel
                { id = x.id, nome = x.nome, cargo = x.cargo, dataCadastro = x.dataCadastro, dataAtualizacao = x.dataAtualizacao,excluido = x.excluido })
                .ToList();
            }


            dgvUsuarios.CriarColunasDataGridView(listaDataSource, new()
            {
                (nameof(UsuarioViewModel.id),true,true), (nameof(UsuarioViewModel.nome),true,true),
                (nameof(UsuarioViewModel.cargo),true,true),(nameof(UsuarioViewModel.dataCadastro),true,true),
                (nameof(UsuarioViewModel.dataAtualizacao),true,true),(nameof(UsuarioViewModel.excluido),true,false)
            });
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new formDetalhesUsuario().ShowDialog();
            CarregaUsuarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                new formDetalhesUsuario(Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[nameof(UsuarioViewModel.id)].Value)).ShowDialog();
            }
            CarregaUsuarios();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir os usuários selecionados?", String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new ModuloCadastro.Service.UsuarioService(new ModuloCadastroContext()).UpdateParcial(new UsuarioEntity()
                {
                    id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[nameof(UsuarioViewModel.id)].Value),
                    dataExclusao = DateTime.Now,
                    excluido = true
                }, new List<string>() { nameof(UsuarioEntity.dataExclusao), nameof(UsuarioEntity.excluido) });

                CarregaUsuarios();
            }
        }

        private void ckeOcultaExcluidos_CheckedChanged(object sender, EventArgs e)
        {
            CarregaUsuarios();
        }

        private void dgvUsuarios_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            UsuarioViewModel row = dgvUsuarios.Rows[e.RowIndex].DataBoundItem as UsuarioViewModel;

            if (row.excluido)
            {
                dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
            }
        }
    }
}
