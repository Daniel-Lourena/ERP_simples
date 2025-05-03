using ModuloCadastro.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloConfiguracoes.Extensions;

namespace ModuloCadastro.ViewModel
{
    public class UsuarioViewModel
    {
        [Display(Name = "ID", Description = "")]
        public int id { get; set; }
        [Display(Name = "Nome", Description = "")]
        public string nome { get; set; }
        [Display(Name = "Cargo", Description = "")]
        public ECargo cargo { get; set; }
        [Display(Name = "Dta. Cadastro", Description = "")]
        public DateTime dataCadastro { get; set; }
        [Display(Name = "Dta. Atualização", Description = "")]
        public DateTime dataAtualizacao { get; set; }
        [Display(Name = "Excluído", Description = "")]
        public bool excluido { get; set; }
        [Display(Name = "Dta. Exclusão", Description = "")]
        public DateTime? dataExclusao { get; set; }
        [Display(Name = "Descrição Cargo", Description = "")]
        public string descricaoCargo => cargo.GetDescription();
        
    }
}
