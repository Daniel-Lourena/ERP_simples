using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_cidade")]
    public class CidadeEntity : BaseEntity<CidadeEntity>
    {
        [Key,Display(Name = "ID",Description = "")]
        public int id { get; set; }
        [Display(Name = "UF",Description = "")]
        public int cuf { get; set; }
        [Display(Name = "Cód. Município",Description = "")]
        public string cmunicipio { get; set; }
        [Display(Name = "Nome",Description = "")]
        public string dmunicipio { get; set; }
    }
}
