using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_cliente")]
    public class ClienteEntity : BaseEntity<ClienteEntity>
    {
        public int id { get; set; }
        public string razaoSocial { get; set; }
        public string fantasia { get; set; }
        public decimal limiteCredito { get; set; }
        public string end_nomeRua { get; set; }
        public string end_numero { get; set; }
        public string end_logradouro { get; set; }
        public string end_uf { get; set; }
        public string end_cidade { get; set; }

        public string enderecoCompleto
        {
            get { return $"{end_logradouro} {end_nomeRua} {end_numero},{end_cidade} - {end_uf}"; }
        }
    }
}
