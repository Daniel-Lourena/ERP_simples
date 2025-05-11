using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloCadastro.Entity
{
    [Table("tb_estados")]
    public class EstadoEntity
    {
        [Key, Display(Name = "Cód. UF", Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cuf { get; set; }
        [Display(Name = "UF", Description = ""), Column(TypeName = "varchar(2)")]
        public string Uf { get; set; }
        [Display(Name = "Nome", Description = ""), Column(TypeName = "varchar(50)")]
        public string Nome { get; set; }
    }
}
