namespace ModuloCadastro.Service
{
    public interface IService<T>
    {
        T Get(int id);
        List<T> GetList();
        int Insert(T entity);
        void Update(T entity);
        void UpdateParcial(T entity, List<string> listaPropriedadesAtualizar);
    }
}
