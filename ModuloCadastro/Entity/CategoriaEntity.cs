using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_categoria")]
    public class CategoriaEntity : BaseEntity<CategoriaEntity>
    {
        [Key,Display(Name = "ID",Description = "")]
        public int id { get; set; }
        [Display(Name = "Descrição",Description = "")]
        public string descricao { get; set; }
    }
}
