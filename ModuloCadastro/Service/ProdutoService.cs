using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Context;
using ModuloCadastro.Entity;

namespace ModuloCadastro.Service
{
    public class ProdutoService : IService<ProdutoEntity>
    {
        private readonly ModuloCadastroContext _db_context;

        public ProdutoService(ModuloCadastroContext db_context) => _db_context = db_context;
        public ProdutoEntity Get(int id)
        {
            return new ModuloCadastroContext().Produtos.FirstOrDefault(x => x.Id.Equals(id))!;
        }
        public IQueryable<ProdutoEntity> GetList()
        {
            return _db_context.Produtos.AsNoTracking()
                .Include(x => x.Categoria);
        }

        public int Insert(ProdutoEntity entity)
        {
            int insert = 0;
            var autoNumeradorContext = new Service.AutoNumeradorService(_db_context);
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
            _db_context.Produtos.Update(entity);
            _db_context.SaveChanges();
        }

        public void UpdateParcial(ProdutoEntity entity, List<string> listaPropriedadesAtualizar)
        {
            new ServiceMethods(_db_context).UpdateParcial(entity, listaPropriedadesAtualizar);
        }
    }
}
