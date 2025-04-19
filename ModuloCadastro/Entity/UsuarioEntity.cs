using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_usuario")]
    public class UsuarioEntity : BaseEntity<UsuarioEntity>
    { 
        public int id { get; set; }
        public string nome { get; set; }
        public string cargo { get; set; }
    }
}
