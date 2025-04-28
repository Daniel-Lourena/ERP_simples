using Microsoft.EntityFrameworkCore;
using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Service
{
    public interface IService<T>
    {
        T Get(int id);
        List<T> GetList();
        void Insert(T entity);
        void Update(T entity);
        void UpdateParcial(T entity, List<string> listaPropriedadesAtualizar);
    }
}
