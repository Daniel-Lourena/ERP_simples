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
    [Table("tb_usuario")]
    public class UsuarioEntity : BaseEntity<UsuarioEntity>
    {
        [Display(Name = "ID",Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int id { get; set; }
        [Display(Name = "Nome",Description = ""), Column(TypeName = "varchar(50)")] 
        public string nome { get; set; }
        [Display(Name = "Cargo",Description = ""), Column(TypeName = "int")] 
        public int cargo { get; set; }
        [Display(Name = "Dta. Cadastro", Description = ""), Column(TypeName = "datetime")] 
        public DateTime dataCadastro { get; set; }
        [Display(Name = "Dta. Atualização", Description = ""), Column(TypeName = "datetime")] 
        public DateTime dataAtualizacao { get; set; }
        [Display(Name = "Excluído", Description = ""), Column(TypeName = "tinyint(1)")] 
        public bool excluido { get; set; }
        [Display(Name = "Dta. Exclusão", Description = ""), Column(TypeName = "datetime")]
        public DateTime dataExclusao { get; set; }
    }
}
