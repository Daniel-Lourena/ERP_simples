using ModuloCadastro.Entity.Cadastro.Cliente;

namespace ModuloCadastro.Tests.Geral.Builders
{
    public class ClienteBuilder
    {
        private string _razaoSocial = "Cliente Teste";
        private string _fantasia = "Fantasia Teste";
        private int _cidadeId = 1;
        private int _estadoId = 35;
        private decimal _limiteCredito = 0;

        public ClienteBuilder ComRazaoSocial(string valor) { _razaoSocial = valor; return this; }
        public ClienteBuilder ComFantasia(string valor) { _fantasia = valor; return this; }
        public ClienteBuilder ComCidadeId(int id) { _cidadeId = id; return this; }
        public ClienteBuilder ComEstadoId(int id) { _estadoId = id; return this; }
        public ClienteBuilder ComLimiteCredito(decimal valor) { _limiteCredito = valor; return this; }

        public ClienteEntity Build() => new ClienteEntity
        {
            RazaoSocial = _razaoSocial,
            Fantasia = _fantasia,
            CidadeId = _cidadeId,
            EstadoId = _estadoId,
            LimiteCredito = _limiteCredito,
            End_nomeRua = "",
            End_bairro = "",
            End_numero = "",
            End_logradouro = "",
            DataCadastro = DateTime.Now,
            Excluido = false
        };
    }
}
