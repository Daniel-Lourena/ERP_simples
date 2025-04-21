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
        [Key,Display(Name = "Cód. UF",Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cuf { get; set; }
        [Display(Name = "UF",Description = ""), Column(TypeName = "varchar(2)")]
        public string uf { get; set; }
        [Display(Name = "Nome",Description = ""), Column(TypeName = "varchar(50)")]
        public string nome { get; set; }
    }
}
