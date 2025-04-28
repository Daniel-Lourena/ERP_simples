using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Entity;
using ModuloCadastro.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Context
{
    public class EstoqueContext
    {
        public List<EstoqueEntity> GetListEstoqueBruto()
        {
            return new ModuloCadastroContext().Estoques.AsNoTracking().ToList();
        }

        public List<EstoqueViewModel> GetListEstoqueDisponivel()
        {
            ModuloCadastroContext _context = new();

            var listaConsultaEstoque = (from estoque in _context.Estoques
                        join resultado in
                        (   from produtospedido in _context.ProdutosVendas
                            join pedidos in _context.PedidosVendas on produtospedido.idPedido equals pedidos.id
                            where pedidos.dataFechamento == null
                            group produtospedido by produtospedido.idProduto into produtospedidoAgrupamento
                            select new
                            {
                                idProduto = produtospedidoAgrupamento.Key,
                                quantidadeVenda = produtospedidoAgrupamento.Sum(x => x.quantidade)
                            }
                        )
                        on estoque.idProduto equals resultado.idProduto
                        join infoProduto in _context.Produtos on estoque.idProduto equals infoProduto.id
                        select new EstoqueViewModel
                        {
                            idProduto = resultado.idProduto,
                            descricaoProduto = infoProduto.descricao,
                            quantidadeEstoque = estoque.quantidade,
                            quantidadePedidoVenda = resultado.quantidadeVenda,
                            quantidadeEstoqueSaldoDisponivel = estoque.quantidade - resultado.quantidadeVenda
                        }).AsNoTracking().ToList();
            return listaConsultaEstoque;
        }
    }
}
