using ModuloCadastro.Context;

namespace ModuloCadastro.Service
{
    public static class ServiceMethods
    {
        public static void UpdateParcial<T>(T entity, List<string> listaPropriedadesAtualizar) where T : class
        {
            using (var _context = new ModuloCadastroContext())
            {
                _context.Attach(entity);

                listaPropriedadesAtualizar.
                    ForEach(propriedadeAtualiza =>
                    _context.Entry(entity).Property(propriedadeAtualiza).IsModified = true);

                _context.SaveChanges();
            }
        }
    }
}
