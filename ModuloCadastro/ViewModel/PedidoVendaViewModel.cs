using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.ViewModel
{
    public class PedidoVendaViewModel
    {
        [Key, Display(Name = "id", Description = "")]
        public int id { get; set; }
        [Display(Name = "idCliente", Description = "")]
        public int idCliente { get; set; }
        [Display(Name = "idCriador", Description = "")]
        public int idCriador { get; set; }
        [Display(Name = "Criação", Description = "")]
        public DateTime dataCriacao { get; set; }
        [Display(Name = "Atualização", Description = "")]
        public DateTime dataAtualizacao { get; set; }
        [Display(Name = "usuarioAtualizacao", Description = "")]
        public int usuarioAtualizacao { get; set; }
        [Display(Name = "excluido", Description = "")]
        public bool excluido { get; set; }
        [Display(Name = "Exclusão", Description = "")]
        public DateTime? dataExclusao { get; set; }
        [Display(Name = "usuarioFechamento", Description = "")]
        public int usuarioFechamento { get; set; }
        [Display(Name = "Fechamento", Description = "")]
        public DateTime? dataFechamento { get; set; }
        [Display(Name = "Usuário Fechamento", Description = "")]
        public string nomeUsuarioFechamento { get; set; }
        [Display(Name = "Usuário Atualização", Description = "")]
        public string nomeUsuarioAtualizacao { get; set; }
        [Display(Name = "Usuário Criador", Description = "")]
        public string nomeUsuarioCriador { get; set; }
    }
}
