using ModuloCadastro.Context;

namespace ModuloCadastro.Service
{
    public class ServiceMethods
    {
        private readonly ModuloCadastroContext _context;
        public ServiceMethods(ModuloCadastroContext context) => _context = context;

        public void UpdateParcial<T>(T entity, List<string> listaPropriedadesAtualizar) where T : class
        {
            _context.Attach(entity);

            listaPropriedadesAtualizar.
                ForEach(propriedadeAtualiza =>
                _context.Entry(entity).Property(propriedadeAtualiza).IsModified = true);

            _context.SaveChanges();
        }
    }
}
