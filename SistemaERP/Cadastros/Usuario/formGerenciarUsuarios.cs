using ModuloCadastro.Entity;
using ModuloCadastro.Entity.Financeiro;
using ModuloCadastro.Entity.Cadastro.Produto;
using ModuloCadastro.Entity.Cadastro.Cliente;
using ModuloCadastro.Entity.Cadastro.Localizacao;
using ModuloCadastro.Entity.Cadastro.Usuario;
using ModuloCadastro.Entity.Venda;
using ModuloCadastro.Service;
using ModuloCadastro.Service.Financeiro;
using ModuloCadastro.Service.Cadastro.Produto;
using ModuloCadastro.Service.Cadastro.Cliente;
using ModuloCadastro.Service.Cadastro.Localizacao;
using ModuloCadastro.Service.Cadastro.Usuario;
using ModuloCadastro.Service.Venda;
using ModuloCadastro.ViewModel;
using ModuloCadastro.ViewModel.Financeiro;
using ModuloCadastro.ViewModel.Cadastro.Produto;
using ModuloCadastro.ViewModel.Cadastro.Cliente;
using ModuloCadastro.ViewModel.Cadastro.Usuario;
using ModuloCadastro.ViewModel.Venda;
using SistemaERP.Extensions;
using SistemaERP.Factory;
using System.Data;

namespace SistemaERP.Cadastros.Usuario
{
    public partial class formGerenciarUsuarios : Form
    {
        private readonly IFormFactory _formFactory;
        private readonly UsuarioService _service;

        public formGerenciarUsuarios(IFormFactory formFactory,UsuarioService service)
        {
            _formFactory = formFactory;
            _service = service;

            InitializeComponent();
            CarregaUsuarios();
            this.ConfiguraTabIndex();
        }

        private void CarregaUsuarios()
        {
            List<UsuarioViewModel> listaDataSource = new();
            if (ckeOcultaExcluidos.Checked)
            {
                listaDataSource = _service.GetList()
                .Where(x => !x.Excluido)
                .Select(x => new UsuarioViewModel
                { id = x.Id, nome = x.Nome, cargo = x.Cargo, dataCadastro = x.DataCadastro, dataAtualizacao = x.DataAtualizacao, excluido = x.Excluido })
                .ToList();
            }
            else
            {
                listaDataSource = _service.GetList()
                .Select(x => new UsuarioViewModel
                { id = x.Id, nome = x.Nome, cargo = x.Cargo, dataCadastro = x.DataCadastro, dataAtualizacao = x.DataAtualizacao, excluido = x.Excluido })
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
            _formFactory.Criar<formDetalhesUsuario>().ShowDialog();
            CarregaUsuarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                _formFactory.Criar<formDetalhesUsuario>(Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[nameof(UsuarioViewModel.id)].Value)).ShowDialog();
            }
            CarregaUsuarios();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir os usuários selecionados?", String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _service.UpdateParcial(new UsuarioEntity()
                {
                    Id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[nameof(UsuarioViewModel.id)].Value),
                    DataExclusao = DateTime.Now,
                    Excluido = true
                }, new List<string>() { nameof(UsuarioEntity.DataExclusao), nameof(UsuarioEntity.Excluido) });

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
