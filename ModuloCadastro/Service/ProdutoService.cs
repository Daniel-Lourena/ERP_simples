using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class ProdutoService : IService<ProdutoEntity>
    {
        private ModuloCadastroContext _db_context;

        public ProdutoService(ModuloCadastroContext db_context) => _db_context = db_context;
        public ProdutoEntity Get(int id)
        {
            return new ModuloCadastroContext().Produtos.FirstOrDefault(x => x.Id.Equals(id))!;
        }
        public List<ProdutoEntity> GetList()
        {
            return _db_context.Produtos.AsNoTracking()
                .Include(x => x.Categoria)
                .ToList();
        }

        public int Insert(ProdutoEntity entity)
        {
            int insert = 0;
            using (var autoNumeradorContext = new Service.AutoNumeradorService(new ModuloCadastroContext()))
            {
                AutoNumeradorEntity numerador = autoNumeradorContext.Get();
                numerador.IdProduto++;
                entity.Id = numerador.IdProduto;
                var _context = new ModuloCadastroContext();
                _context.Produtos.Add(entity);
                _context.SaveChanges();
                ServiceMethods.UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdProduto) });
                insert = entity.Id;
            }
            return insert;
        }
        public void Update(ProdutoEntity entity)
        {
            var _context = new ModuloCadastroContext();
            _context.Produtos.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateParcial(ProdutoEntity entity, List<string> listaPropriedadesAtualizar)
        {
            ServiceMethods.UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
