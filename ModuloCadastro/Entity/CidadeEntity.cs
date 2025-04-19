using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_cidade")]
    public class CidadeEntity : BaseEntity<CidadeEntity>
    {
        public int id { get; set; }
        public int cuf { get; set; }
        public string cmunicipio { get; set; }
        public string dmunicipio { get; set; }
    }
}
