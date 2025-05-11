using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloCadastro.Entity
{
    [Table("tb_setorestoque")]
    public class SetorEstoqueEntity : BaseEntity<SetorEstoqueEntity>
    {
        [Key, Display(Name = "ID", Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Descrição", Description = ""), Column(TypeName = "varchar(100)")]
        public string? Descricao { get; set; }
    }
}
