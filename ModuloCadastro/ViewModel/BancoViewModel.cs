using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ModuloCadastro.ViewModel
{
    public class BancoViewModel : INotifyPropertyChanged
    {
        private int _id;
        private string _nome;
        private string _codigo;
        private string _agencia;
        private string _agenciaDigito;
        private string _conta;
        private string _contaDigito;
        private ETipoContaBanco _tipoConta;
        private string _titularNome;
        private string _titularDocumento;
        private string _pixChave;
        private ETipoChavePix _pixTipoChave;
        private bool _contaInternacional;
        private bool _inativo;
        private DateTime _dataCadastro;
        private DateTime _dataAtualizacao;
        private string _iban;
        private string _swiftCode;


        [Display(Name = "ID", Description = "")]
        public int id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        [Display(Name = "Nome", Description = "")]
        public string nome
        {
            get => _nome;
            set
            {
                if (_nome != value)
                {
                    _nome = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "Código", Description = "")]
        public string codigo
        {
            get => _codigo;
            set
            {
                if (_codigo != value)
                {
                    _codigo = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "N° Agência", Description = "")]
        public string agencia
        {
            get => _agencia;
            set
            {
                if (agencia != value)
                {
                    _agencia = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "Dígito agência", Description = "")]
        public string agenciaDigito
        {
            get => _agenciaDigito;
            set
            {
                if (_agenciaDigito != value)
                {
                    _agenciaDigito = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "N° Conta", Description = "")]
        public string conta
        {
            get => _conta;
            set
            {
                if (_conta != value)
                {
                    _conta = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "Dígito conta", Description = "")]
        public string contaDigito
        {
            get => _contaDigito;
            set
            {
                if (_contaDigito != value)
                {
                    _contaDigito = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "Tipo", Description = "")]
        public ETipoContaBanco tipoConta
        {
            get => _tipoConta;
            set
            {
                if (_tipoConta != value)
                {
                    _tipoConta = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "Nome titular", Description = "")]
        public string titularNome
        {
            get => _titularNome;
            set
            {
                if (_titularNome != value)
                {
                    _titularNome = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "Documento titular", Description = "")]
        public string titularDocumento
        {
            get => _titularDocumento;
            set
            {
                if (_titularDocumento != value)
                {
                    _titularDocumento = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "Chave pix", Description = "")]
        public string? pixChave
        {
            get => _pixChave;
            set
            {
                if (_pixChave != value)
                {
                    _pixChave = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "Tipo pix", Description = "")]
        public ETipoChavePix pixTipoChave
        {
            get => _pixTipoChave;
            set
            {
                if (_pixTipoChave != value)
                {
                    _pixTipoChave = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "Internacional", Description = "")]
        public bool contaInternacional
        {
            get => _contaInternacional;
            set
            {
                if (_contaInternacional != value)
                {
                    _contaInternacional = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "Intivo", Description = "")]
        public bool inativo
        {
            get => _inativo;
            set
            {
                if (_inativo != value)
                {
                    _inativo = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "Cadastro", Description = "")]
        public DateTime dataCadastro
        {
            get => _dataCadastro;
            set
            {
                if (_dataCadastro != value)
                {
                    _dataCadastro = value;
                    OnPropertyChanged();
                }
            }
        }
        [Display(Name = "Atualização", Description = "")]
        public DateTime dataAtualizacao
        {
            get => _dataAtualizacao;
            set
            {
                if (_dataAtualizacao != value)
                {
                    _dataAtualizacao = value;
                    OnPropertyChanged();
                }
            }
        }

        [Display(Name = "IBAN", Description = "")]
        public string iban
        {
            get => _iban;
            set
            {
                if (_iban != value)
                {
                    _iban = value;
                    OnPropertyChanged();
                }
            }
        }// Se for conta no exterior
        [Display(Name = "SWIFT/BIC", Description = "")]
        public string swiftCode
        {
            get => _swiftCode;
            set
            {
                if (_swiftCode != value)
                {
                    _swiftCode = value;
                    OnPropertyChanged();
                }
            }
        } // SWIFT/BIC


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propriedade = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
        }

        public BancoEntity ToEntity() 
        {
            return new BancoEntity
            {
                id = this.id,
                nome = this.nome,
                codigo = this.codigo,
                agencia = this.agencia,
                agenciaDigito = this.agenciaDigito,
                conta = this.conta,
                contaDigito = this.contaDigito,
                tipoConta = this.tipoConta,
                titularNome = this.titularNome,
                titularDocumento = this.titularDocumento,
                pixChave = this.pixChave,
                pixTipoChave = this.pixTipoChave,
                contaInternacional = this.contaInternacional,
                inativo = this.inativo,
                dataCadastro = this.dataCadastro,
                dataAtualizacao = this.dataAtualizacao,
                iban = this.iban,
                swiftCode = this.swiftCode
            };
        }
    }
}
