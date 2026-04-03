using ModuloCadastro.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity.Financeiro
{
    [Table("tb_maquininhas")]
    public class MaquininhaEntity : BaseEntity<MaquininhaEntity>
    {
        [Key,Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } 
        [Column(TypeName = "varchar(50)")]
        public string Nome { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public bool Inativo { get; set; } = false;
        [Column(TypeName = "int")]
        public int AdquirenteId { get; set; } = 0;
        [Column(TypeName = "int")]
        public ETipoMaquininha TipoMaquininha { get; set; } 

        public ConfigAdquirenteEntity Adquirente { get; set; } 
    }
}
