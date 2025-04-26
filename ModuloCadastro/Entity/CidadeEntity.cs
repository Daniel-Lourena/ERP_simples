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
    [Table("tb_cidades")]
    public class CidadeEntity : BaseEntity<CidadeEntity>
    {
        [Key,Display(Name = "ID",Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Display(Name = "UF", Description = ""), Column(TypeName = "int")]
        public int cuf { get; set; }
        [Display(Name = "Cód. Município", Description = ""), Column(TypeName = "varchar(10)")]
        public string cmunicipio { get; set; }
        [Display(Name = "Nome", Description = ""), Column(TypeName = "varchar(50)")]
        public string dmunicipio { get; set; }

        public EstadoEntity DadosEstado { get; set; }
    }
}
