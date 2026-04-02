using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class ProdutoService : IService<ProdutoEntity>
    {
        private readonly IDbContextFactory<ModuloCadastroContext> _factory;
        public ProdutoService(IDbContextFactory<ModuloCadastroContext> factory) => _factory = factory;
        
        public ProdutoEntity Get(int id)
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Produtos.FirstOrDefault(x => x.Id == id)!;
        }
        public IQueryable<ProdutoEntity> GetList()
        {
            var _db_context = _factory.CreateDbContext();
            return _db_context.Produtos.AsNoTracking()
                .Include(x => x.Categoria);
        }

        public int Insert(ProdutoEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            int insert = 0;
            var autoNumeradorContext = new Service.AutoNumeradorService(_factory);
            AutoNumeradorEntity numerador = autoNumeradorContext.Get();
            numerador.IdProduto++;
            entity.Id = numerador.IdProduto;
            _db_context.Produtos.Add(entity);
            _db_context.SaveChanges();
            new ServiceMethods(_db_context).UpdateParcial(numerador, new List<string>() { nameof(AutoNumeradorEntity.IdProduto) });
            insert = entity.Id;
            return insert;
        }
        public void Update(ProdutoEntity entity)
        {
            var _db_context = _factory.CreateDbContext();
            _db_context.Produtos.Update(entity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(ProdutoEntity entity, List<string> listaPropriedadesAtualizar)
        {
            var _db_context = _factory.CreateDbContext();
            new ServiceMethods(_db_context).UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
