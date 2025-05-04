using ModuloCadastro.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ModuloCadastro.ViewModel
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        private int _id;
        private string _razaoSocial;
        private string _fantasia;
        private decimal _limiteCredito;
        private string _end_nomeRua;
        private string _end_bairro;
        private string _end_numero;
        private string _end_logradouro;
        private int _end_uf;
        private int _end_cidade;
        private DateTime? _dataCadastro;
        private DateTime? _dataAtualizacao;
        private bool _excluido;
        private DateTime? _dataExclusao;


        [Display(Name = "ID", Description = "")]
        public int id { get => _id; set { if (_id != value) { _id = value; OnPropertyChanged(); } } }
        [Display(Name = "Razão Social", Description = "")]
        public string razaoSocial { get => _razaoSocial; set { if (_razaoSocial != value) { _razaoSocial = value; OnPropertyChanged(); } } }
        [Display(Name = "Fantasia", Description = "")]
        public string fantasia { get => _fantasia; set { if (_fantasia != value) { _fantasia = value; OnPropertyChanged(); } } }
        [Display(Name = "Limite Crédito", Description = "")]
        public decimal limiteCredito { get => _limiteCredito; set { if (_limiteCredito != value) { _limiteCredito = value; OnPropertyChanged(); } } }
        [Display(Name = "Rua", Description = "")]
        public string end_nomeRua { get => _end_nomeRua; set { if (_end_nomeRua != value) { _end_nomeRua = value; OnPropertyChanged(); } } }
        [Display(Name = "Bairro", Description = "")]
        public string end_bairro { get => _end_bairro; set { if (_end_bairro != value) { _end_bairro = value; OnPropertyChanged(); } } }
        [Display(Name = "N°", Description = "")]
        public string end_numero { get => _end_numero; set { if (_end_numero != value) { _end_numero = value; OnPropertyChanged(); } } }
        [Display(Name = "Logradouro", Description = "")]
        public string end_logradouro { get => _end_logradouro; set { if (_end_logradouro != value) { _end_logradouro = value; OnPropertyChanged(); } } }
        [Display(Name = "UF", Description = "")]
        public int end_uf { get => _end_uf; set { if (_end_uf != value) { _end_uf = value; OnPropertyChanged(); } } }
        [Display(Name = "ID Cidade", Description = "")]
        public int end_cidade { get => _end_cidade; set { if (_end_cidade != value) { _end_cidade = value; OnPropertyChanged(); } } }
        [Display(Name = "Dta. Cadastro", Description = "")]
        public DateTime? dataCadastro { get => _dataCadastro; set { if (_dataCadastro != value) { _dataCadastro = value; OnPropertyChanged(); } } }
        [Display(Name = "Dta. Atualização", Description = "")]
        public DateTime? dataAtualizacao { get => _dataAtualizacao; set { if (_dataAtualizacao != value) { _dataAtualizacao = value; OnPropertyChanged(); } } }
        [Display(Name = "Excluído", Description = "")]
        public bool excluido { get => _excluido; set { if (_excluido != value) { _excluido = value; OnPropertyChanged(); } } }
        [Display(Name = "Dta. Exclusão", Description = "")]
        public DateTime? dataExclusao { get => _dataExclusao; set { if (_dataExclusao != value) { _dataExclusao = value; OnPropertyChanged(); } } }

        public CidadeEntity DadosCidade { get; set; }

        [NotMapped]
        public string enderecoCompleto
        {
            get { return $"{end_logradouro} {end_nomeRua} {end_numero},{end_cidade} - {end_uf}"; }
        }

        public ClienteEntity ToEntity()
        {
            return new ClienteEntity
            {
                id = this.id,
                razaoSocial = this.razaoSocial,
                fantasia = this.fantasia,
                limiteCredito = this.limiteCredito,
                end_nomeRua = this.end_nomeRua,
                end_bairro = this.end_bairro,
                end_numero = this.end_numero,
                end_logradouro = this.end_logradouro,
                end_uf = this.end_uf,
                end_cidade = this.end_cidade,
                dataCadastro = this.dataCadastro,
                dataAtualizacao = this.dataAtualizacao,
                excluido = this.excluido,
                dataExclusao = this.dataExclusao
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propriedade = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
        }
    }
}
