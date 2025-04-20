using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_estado")]
    public class EstadoEntity
    {
        [Key,Display(Name = "Cód. UF",Description = "")]
        public int cuf { get; set; }
        [Display(Name = "UF",Description = "")]
        public string uf { get; set; }
        [Display(Name = "Nome",Description = "")]
        public string nome { get; set; }
    }
}
