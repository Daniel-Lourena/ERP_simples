using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using SistemaERP.Cadastros.Extensions;
using SistemaERP.Generico;
using System.Security.Cryptography;

namespace SistemaERP.Vendas
{
    public partial class formDetalhesVenda : Form
    {
        private int _idPedido = 0;
        private PedidoVendaEntity _pedido;
        public formDetalhesVenda()
        {
            InitializeComponent();
            this.ConfiguraTabIndex();
        }
        public formDetalhesVenda(int idPedido) : this()
        {
            _idPedido = idPedido;
        }

        private void ConfiguraDataBindings()
        {
            _pedido = _pedido ?? new PedidoVendaEntity();
            BindingSource clienteSource = new();
            clienteSource.DataSource = _pedido.Cliente;
            BindingSource cidadeSource = new();
            cidadeSource.DataSource = _pedido.Cliente.Cidade;
            BindingSource estadoSource = new();
            estadoSource.DataSource = _pedido.Cliente.Cidade.DadosEstado;

            txtIdCliente.DataBindings.Add(nameof(txtIdCliente.Text), _pedido, nameof(_pedido.ClienteId));
            txtCadastro.DataBindings.Add(nameof(txtCadastro.Text), _pedido, nameof(_pedido.DataCriacao));
            txtAtualizacao.DataBindings.Add(nameof(txtAtualizacao.Text), _pedido, nameof(_pedido.DataAtualizacao));
            txtFantasia.DataBindings.Add(nameof(txtFantasia.Text), clienteSource, nameof(_pedido.Cliente.Fantasia));
            txtRazaoSocial.DataBindings.Add(nameof(txtRazaoSocial.Text), clienteSource, nameof(_pedido.Cliente.RazaoSocial));
            txtLogradouro.DataBindings.Add(nameof(txtLogradouro.Text), clienteSource, nameof(_pedido.Cliente.End_logradouro));
            txtRua.DataBindings.Add(nameof(txtRua.Text), clienteSource, nameof(_pedido.Cliente.End_nomeRua));
            txtNro.DataBindings.Add(nameof(txtNro.Text), clienteSource, nameof(_pedido.Cliente.End_numero));
            txtBairro.DataBindings.Add(nameof(txtBairro.Text), clienteSource, nameof(_pedido.Cliente.End_bairro));
            txtCidade.DataBindings.Add(nameof(txtCidade.Text), cidadeSource, nameof(_pedido.Cliente.Cidade.Dmunicipio));
            txtUF.DataBindings.Add(nameof(txtUF.Text), estadoSource, nameof(_pedido.Cliente.Cidade.DadosEstado.Uf));
        }

        private void CarregarProdutos()
        {
            dgvProdutos.CriarColunasDataGridView<ProdutoVendaViewModel>
                (
                    new ModuloCadastro.Service.ProdutoVendaService().GetListProdutosPedido(_idPedido),
                    new()
                    {
                        (nameof(ProdutoVendaViewModel.idProduto),true,true),(nameof(ProdutoVendaViewModel.descricaoProduto),true, true),
                        (nameof(ProdutoVendaViewModel.descricaoProduto), true,true),(nameof(ProdutoVendaViewModel.quantidade), false,true),
                        (nameof(ProdutoVendaViewModel.valor), false,true),(nameof(ProdutoVendaViewModel.id), false,false)
                    }
                );
        }

        private void MostraPedido()
        {
            _pedido = new PedidoVendaService(new ModuloCadastroContext()).Get(_idPedido);
            this.Text = $"PEDIDO [{_pedido.Id}]";
        }

        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            new formAdicionarProdutosPedido(ETipoPedido.VENDA, _idPedido).ShowDialog();
            CarregarProdutos();
        }

        private void btnRemProduto_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow == null) return;

            if (MessageBox.Show($"Deseja excluir o item {dgvProdutos.CurrentRow.Cells[nameof(ProdutoVendaViewModel.idProduto)].Value} - {dgvProdutos.CurrentRow.Cells[nameof(ProdutoVendaViewModel.descricaoProduto)].Value} do pedido?", String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            new ModuloCadastro.Service.ProdutoVendaService().Delete(Convert.ToInt32(dgvProdutos.CurrentRow.Cells[nameof(ProdutoVendaViewModel.id)].Value));
        }

        private void formDetalhesVenda_Load(object sender, EventArgs e)
        {
            CarregarProdutos();

            if (_idPedido > 0) MostraPedido();
            ConfiguraDataBindings();

            if (_idPedido == 0)
            {
                btnAddProduto.Enabled = false;
                btnRemProduto.Enabled = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_idPedido == 0)
            {
                _pedido.DataCriacao = DateTime.Now;
                _pedido.DataAtualizacao = DateTime.Now;
                _pedido.UsuarioCriacaoId = 1; //Provisório
                _pedido.UsuarioAtualizacaoId = 1; //Provisório
                _pedido.Id = new ModuloCadastro.Service.PedidoVendaService(new ModuloCadastroContext()).Insert(_pedido);
                _idPedido = _pedido.Id;
                this.Text = $"PEDIDO [{_pedido.Id}]";
            }
            else
            {
                _pedido.DataAtualizacao = DateTime.Now;
                new ModuloCadastro.Service.PedidoVendaService(new ModuloCadastroContext()).Update(_pedido);
            }

            btnAddProduto.Enabled = true;
            btnRemProduto.Enabled = true;

            MessageBox.Show("Salvo com sucesso", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnProcurarCliente_Click(object sender, EventArgs e)
        {
            using (formAdicionarClientes form = new formAdicionarClientes())
            {
                form.ShowDialog();
                _pedido.ClienteId = form._idClienteSelecionado;
            };
            if (_pedido.ClienteId == 0) return;
            _pedido.Cliente = new ModuloCadastro.Service.ClienteService(new ModuloCadastroContext()).Get(_pedido.ClienteId);
            txtFantasia.Text = _pedido.Cliente.Fantasia;
            txtRazaoSocial.Text = _pedido.Cliente.RazaoSocial;
            txtLogradouro.Text = _pedido.Cliente.End_logradouro;
            txtRua.Text = _pedido.Cliente.End_nomeRua;
            txtNro.Text = _pedido.Cliente.End_numero;
            txtBairro.Text = _pedido.Cliente.End_bairro;
            txtCidade.Text = _pedido.Cliente.Cidade.Dmunicipio;
            txtUF.Text = _pedido.Cliente.Cidade.DadosEstado.Uf;
        }
    }
}
