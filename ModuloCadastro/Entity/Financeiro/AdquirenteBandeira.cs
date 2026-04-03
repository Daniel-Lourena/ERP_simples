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
    [Table("tb_adquirente_bandeira")]
    public class AdquirenteBandeira : BaseEntity<AdquirenteBandeira>
    {
        [Key,Column(TypeName = "int")]
        public int ConfigAdquirenteId { get; set; }
        [Key,Column(TypeName = "int")]
        public EBandeiraCartao BandeiraId { get; set; }

        public ConfigAdquirenteEntity ConfigAdquirente { get; set; }
    }
}
