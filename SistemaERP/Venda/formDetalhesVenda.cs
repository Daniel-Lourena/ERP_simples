using ModuloCadastro.Context;
using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using ModuloCadastro.Service;
using ModuloCadastro.ViewModel;
using SistemaERP.Cadastros.Extensions;
using SistemaERP.Generico;
using System.ComponentModel;

namespace SistemaERP.Venda
{
    public partial class formDetalhesVenda : Form
    {
        private int _idPedido = 0;
        private PedidoVendaViewModel _pedido;
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
            _pedido = _pedido ?? new PedidoVendaViewModel();

            txtIdCliente.DataBindings.Add(nameof(txtIdCliente.Text), _pedido, nameof(_pedido.idCliente));
            txtCriacao.DataBindings.Add(nameof(txtCriacao.Text), _pedido, nameof(_pedido.dataCriacao));
            txtAtualizacao.DataBindings.Add(nameof(txtAtualizacao.Text), _pedido, nameof(_pedido.dataAtualizacao));
            txtFantasia.DataBindings.Add(nameof(txtFantasia.Text), _pedido, nameof(_pedido.clienteFantasia));
            txtRazaoSocial.DataBindings.Add(nameof(txtRazaoSocial.Text), _pedido, nameof(_pedido.clienteRazaoSocial));
            txtLogradouro.DataBindings.Add(nameof(txtLogradouro.Text), _pedido, nameof(_pedido.clienteEndLogradouro));
            txtRua.DataBindings.Add(nameof(txtRua.Text), _pedido, nameof(_pedido.clienteEndNomeRua));
            txtNro.DataBindings.Add(nameof(txtNro.Text), _pedido, nameof(_pedido.clienteEndNro));
            txtBairro.DataBindings.Add(nameof(txtBairro.Text), _pedido, nameof(_pedido.clienteEndBairro));
            txtCidade.DataBindings.Add(nameof(txtCidade.Text), _pedido, nameof(_pedido.clienteEndCidade));
            txtUF.DataBindings.Add(nameof(txtUF.Text), _pedido, nameof(_pedido.clienteEndEstado));
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
                        (nameof(ProdutoVendaViewModel.valor), false,true),(nameof(ProdutoVendaViewModel.id), false,false),
                        (nameof(ProdutoVendaViewModel.idSetorEstoque), false,false)
                    }
                );
        }

        private void CarregaRecebimentos()
        {
            dgvRecebimentos.CriarColunasDataGridView<RecebimentoVendaEntity>
                (
                    new ModuloCadastro.Service.RecebimentosVendaService().GetList().Where(x => x.PedidoId == _idPedido).ToList(),
                    new()
                    {
                        (nameof(RecebimentoVendaEntity.Especie), false,true),(nameof(RecebimentoVendaEntity.Valor), false,true),
                        (nameof(RecebimentoVendaEntity.NroParcela), false,true),(nameof(RecebimentoVendaEntity.TotalParcela), false,true),
                        (nameof(RecebimentoVendaEntity.Vencimento), false,true)
                    }
                );
        }

        private void MostraPedido()
        {
            _pedido = new PedidoVendaService(new ModuloCadastroContext()).Get(_idPedido).ToViewModel();
            this.Text = $"PEDIDO [{_pedido.id}]";
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
            CarregarProdutos();
        }

        private void formDetalhesVenda_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
            CarregaRecebimentos();

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
                _pedido.dataCriacao = DateTime.Now;
                _pedido.dataAtualizacao = DateTime.Now;
                _pedido.idCriador = 1; //Provisório
                _pedido.usuarioAtualizacao = 1; //Provisório
                _pedido.id = new ModuloCadastro.Service.PedidoVendaService(new ModuloCadastroContext()).Insert(_pedido.ToEntity());
                _idPedido = _pedido.id;
                this.Text = $"PEDIDO [{_pedido.id}]";
            }
            else
            {
                _pedido.usuarioAtualizacao = 1; //Provisório
                _pedido.dataAtualizacao = DateTime.Now;
                new ModuloCadastro.Service.PedidoVendaService(new ModuloCadastroContext()).Update(_pedido.ToEntity());
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
                _pedido.idCliente = form._idClienteSelecionado;
            }
            ;
            if (_pedido.idCliente == 0) return;

            var cliente = new ModuloCadastro.Service.ClienteService(new ModuloCadastroContext()).Get(_pedido.idCliente);
            txtIdCliente.Text = cliente.Id.ToString();
            txtFantasia.Text = cliente.Fantasia;
            txtRazaoSocial.Text = cliente.RazaoSocial;
            txtLogradouro.Text = cliente.End_logradouro;
            txtRua.Text = cliente.End_nomeRua;
            txtNro.Text = cliente.End_numero;
            txtBairro.Text = cliente.End_bairro;
            txtCidade.Text = cliente.Cidade.Dmunicipio;
            txtUF.Text = cliente.Cidade.DadosEstado.Uf;
        }

        private void btnExcluirPedido_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir o pedido?", "Sistema ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _pedido.dataExclusao = DateTime.Now;
            _pedido.usuarioExclusao = 1; // PROVISÓRIO
            _pedido.excluido = true;
            new ModuloCadastro.Service.PedidoVendaService(new ModuloCadastroContext())
                .UpdateParcial(_pedido.ToEntity(), new()
                {
                    nameof(PedidoVendaEntity.Excluido),nameof(PedidoVendaEntity.UsuarioExclusaoId),nameof(PedidoVendaEntity.DataExclusao)
                });
            MessageBox.Show("Pedido excluído", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void dgvProdutos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ProdutoVendaViewModel row = dgvProdutos.Rows[e.RowIndex].DataBoundItem as ProdutoVendaViewModel;

            new ModuloCadastro.Service.ProdutoVendaService()
                .UpdateParcial(new ProdutoVendaEntity
                {
                    Id = row.id,
                    Quantidade = row.quantidade,
                    Valor = row.valor
                }, new() { nameof(ProdutoVendaEntity.Quantidade), nameof(ProdutoVendaEntity.Valor) });
            CarregarProdutos();
        }

        private void btnFecharPedido_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente finalizar o pedido?", "Sistema ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            #region Atualiza Estoque

            BindingList<ProdutoVendaViewModel> produtos = dgvProdutos.DataSource as BindingList<ProdutoVendaViewModel>;

            foreach (var row in produtos)
            {
                var estoqueAtual = new ModuloCadastro.Service.EstoqueService().Get(row.idProduto, row.idSetorEstoque);
                estoqueAtual.QuantidadeEstoque -= row.quantidade;

                if (estoqueAtual.QuantidadeEstoque == 0)
                {
                    new ModuloCadastro.Service.EstoqueService().Delete(new EstoqueEntity
                    {
                        ProdutoId = row.idProduto,
                        SetorEstoqueId = row.idSetorEstoque,
                    });
                }
                else
                {
                    new ModuloCadastro.Service.EstoqueService()
                    .UpdateParcial(new EstoqueEntity
                    {
                        ProdutoId = row.idProduto,
                        SetorEstoqueId = row.idSetorEstoque,
                        Quantidade = estoqueAtual.QuantidadeEstoque
                    },
                    new() { nameof(EstoqueEntity.Quantidade) });
                }
            }

            #endregion

            #region Atualiza Financeiro

            #endregion

            #region Finaliza Pedido
            _pedido.dataFechamento = DateTime.Now;
            _pedido.usuarioFechamento = 1; // PROVISÓRIO

            new ModuloCadastro.Service.PedidoVendaService(new ModuloCadastroContext())
                .UpdateParcial(_pedido.ToEntity(), new()
                {
                    nameof(PedidoVendaEntity.UsuarioFechamentoId),nameof(PedidoVendaEntity.DataFechamento)
                });

            #endregion
            MessageBox.Show("Pedido finalizado!", "Sistema ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }


        private void btnDinheiro_Click(object sender, EventArgs e)
        {
            new Venda.Recebimento.formDinheiro(_pedido.id).ShowDialog();
            CarregaRecebimentos();
        }

        private void btnBoleto_Click(object sender, EventArgs e)
        {
            new Venda.Recebimento.formBoleto(_pedido.id).ShowDialog();
            CarregaRecebimentos();
        }

        private void btnCheque_Click(object sender, EventArgs e)
        {

        }

        private void btnCreditoLoja_Click(object sender, EventArgs e)
        {

        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {

        }

        private void btnCartaoDebito_Click(object sender, EventArgs e)
        {

        }

        private void btnCartaoCredito_Click(object sender, EventArgs e)
        {

        }
    }
}
