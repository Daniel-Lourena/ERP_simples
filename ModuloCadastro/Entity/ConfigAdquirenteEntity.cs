using ModuloCadastro.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Entity
{
    [Table("tb_config_adquirente")]
    public class ConfigAdquirenteEntity : BaseEntity<ConfigAdquirenteEntity> , INotifyPropertyChanged
    {
        private int _Id;
        private EAdquirenteMaquininha _AdquirenteId;
        private decimal _TaxaDebito;
        private decimal _TaxaCreditoAVista;
        private decimal _TaxaCreditoParcelado;
        private int _NroPacelas;
        private DateTime _Vencimento;
        private decimal _TaxaAntecipacao;




        [Key, Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get => _Id; set { if (_Id  != value) { _Id  = value; OnPropertyChanged(); } } }
        [Column(TypeName = "int")]
        public EAdquirenteMaquininha AdquirenteId { get => _AdquirenteId; set { if (_AdquirenteId != value) { _AdquirenteId = value; OnPropertyChanged(); } } }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TaxaDebito { get => _TaxaDebito; set { if (_TaxaDebito != value) { _TaxaDebito = value; OnPropertyChanged(); } } }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TaxaCreditoAVista { get => _TaxaCreditoAVista; set { if (_TaxaCreditoAVista != value) { _TaxaCreditoAVista = value; OnPropertyChanged(); } } }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TaxaCreditoParcelado { get => _TaxaCreditoParcelado; set { if (_TaxaCreditoParcelado != value) { _TaxaCreditoParcelado = value; OnPropertyChanged(); } } }
        [Column(TypeName = "int")]
        public int NroPacelas { get => _NroPacelas; set { if (_NroPacelas != value) { _NroPacelas = value; OnPropertyChanged(); } } }
        [Column(TypeName = "datetime")]
        public DateTime Vencimento { get => _Vencimento; set { if (_Vencimento != value) { _Vencimento = value; OnPropertyChanged(); } } }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TaxaAntecipacao { get => _TaxaAntecipacao; set { if (_TaxaAntecipacao != value) { _TaxaAntecipacao = value; OnPropertyChanged(); } } }
        
        
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propriedade = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
        }


        [Column(TypeName = "varchar(150)")]
        public string NomeInstituicao => _dados.TryGetValue(AdquirenteId, out var info) ? info.Nome : String.Empty;
        [Column(TypeName = "varchar(20)")]
        public string Cnpj => _dados.TryGetValue(AdquirenteId, out var info) ? info.Cnpj : String.Empty;


        private static readonly Dictionary<EAdquirenteMaquininha, (string Nome, string Cnpj)> _dados =
            new()
            {
                { EAdquirenteMaquininha.REDE, ("Redecard Instituição de Pagamento S.A.", "01425787000104") },
                { EAdquirenteMaquininha.STONE, ("Stone Instituição de Pagamento S.A.", "16501555000157") },
                { EAdquirenteMaquininha.PAGSEGURO, ("PagSeguro Internet Instituição de Pagamento S.A.", "08561701000101") },
                { EAdquirenteMaquininha.SUMUP, ("SumUp Instituição de Pagamento Brasil Ltda.", "16668076000120") },
                { EAdquirenteMaquininha.GETNET, ("Getnet Adquirência e Serviços para Meios de Pagamento S.A.", "10440482000154") },
                { EAdquirenteMaquininha.CIELO, ("Cielo S.A. – Instituição de Pagamento", "01027058000191") }
            };

        public ICollection<AdquirenteBandeira> BandeirasSuportadas { get; set; }

    }
}
