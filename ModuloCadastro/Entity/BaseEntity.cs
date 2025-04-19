using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
