using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloCadastro.Entity
{
    [Table("tb_categoria")]
    public class CategoriaEntity : BaseEntity<CategoriaEntity>
    {
        [Key, Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? descricao { get; set; }
    }
}
