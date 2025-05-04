using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloCadastro.Entity
{
    public class BaseEntity<T>
    {
        public static string Table
        {
            get
            {
                TableAttribute tableAttribute = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
                return tableAttribute != null ? tableAttribute.Name : typeof(T).Name;
            }
        }
    }
}
