using ModuloCadastro.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_recebimento_venda")]
    public class RecebimentoVendaEntity: BaseEntity<RecebimentoVendaEntity>
    {
        [Key, Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "int")]
        public int PedidoId { get; set; }
        [Column(TypeName = "int")]
        public ERecebimentoEspecie Especie { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        [Column(TypeName = "int")]
        public int NroParcela { get; set; }
        [Column(TypeName = "int")]
        public int TotalParcela { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Descricao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Vencimento { get; set; }
    }
}
