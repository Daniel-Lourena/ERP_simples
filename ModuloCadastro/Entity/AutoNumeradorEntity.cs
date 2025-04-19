using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_autonumerador")]
    internal class AutoNumeradorEntity : BaseEntity<AutoNumeradorEntity>
    {
        public int id { get; set; }
        public int idCliente { get; set; }
        public int idUsuario { get; set; }
    }
}
