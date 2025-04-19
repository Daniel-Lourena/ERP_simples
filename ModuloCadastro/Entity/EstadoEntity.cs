using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_estado")]
    public class EstadoEntity
    {
        public int cuf { get; set; }
        public string uf { get; set; }
        public string nome { get; set; }
    }
}
