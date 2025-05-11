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
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Nome { get; set; }
        [Column(TypeName = "int")]
        public ECargo Cargo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCadastro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public bool Excluido { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }


        public UsuarioViewModel ToViewModel()
        {
            return new UsuarioViewModel
            {
                id = this.Id,
                nome = this.Nome,
                cargo = this.Cargo,
                dataCadastro = this.DataCadastro,
                dataAtualizacao = this.DataAtualizacao,
                dataExclusao = this.DataExclusao,
                excluido = this.Excluido
            };
        }
    }
}
