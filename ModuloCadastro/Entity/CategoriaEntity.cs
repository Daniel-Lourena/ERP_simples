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
        [Key,Display(Name = "ID",Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Display(Name = "Descrição",Description = ""), Column(TypeName = "varchar(100)")]
        public string? descricao { get; set; }
    }
}
