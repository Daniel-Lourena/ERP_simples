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
        [Display(Name = "ID",Description = "")] 
        public int id { get; set; }
        [Display(Name = "Nome",Description = "")] 
        public string nome { get; set; }
        [Display(Name = "Cargo",Description = "")] 
        public int cargo { get; set; }
        [Display(Name = "Dta. Cadastro",Description = "")] 
        public DateTime dataCadastro { get; set; }
        [Display(Name = "Dta. Atualização",Description = "")] 
        public DateTime dataAtualizacao { get; set; }
        [Display(Name = "Excluído",Description = "")] 
        public bool excluido { get; set; }
        [Display(Name = "Dta. Exclusão", Description = "")]
        public DateTime dataExclusao { get; set; }
    }
}
