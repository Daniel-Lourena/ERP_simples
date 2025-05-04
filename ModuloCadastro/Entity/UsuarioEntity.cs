using ModuloCadastro.Enum;
using ModuloCadastro.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloCadastro.Entity
{
    [Table("tb_usuarios")]
    public class UsuarioEntity : BaseEntity<UsuarioEntity>
    {
        [Key, Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string nome { get; set; }
        [Column(TypeName = "int")]
        public ECargo cargo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dataCadastro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dataAtualizacao { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public bool excluido { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dataExclusao { get; set; }


        public UsuarioViewModel ToViewModel()
        {
            return new UsuarioViewModel
            {
                id = this.id,
                nome = this.nome,
                cargo = this.cargo,
                dataCadastro = this.dataCadastro,
                dataAtualizacao = this.dataAtualizacao,
                dataExclusao = this.dataExclusao,
                excluido = this.excluido
            };
        }
    }
}
