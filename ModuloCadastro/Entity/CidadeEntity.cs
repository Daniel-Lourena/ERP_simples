using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloCadastro.Entity
{
    [Table("tb_cidades")]
    public class CidadeEntity : BaseEntity<CidadeEntity>
    {
        [Key, Display(Name = "ID", Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Display(Name = "UF", Description = ""), Column(TypeName = "int")]
        public int Cuf { get; set; }
        [Display(Name = "Cód. Município", Description = ""), Column(TypeName = "varchar(10)")]
        public string Cmunicipio { get; set; }
        [Display(Name = "Nome", Description = ""), Column(TypeName = "varchar(50)")]
        public string Dmunicipio { get; set; }

        public EstadoEntity DadosEstado { get; set; }
    }
}
