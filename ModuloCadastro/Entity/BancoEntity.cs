using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloCadastro.Enum;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ModuloCadastro.Entity
{
    [Table("tb_bancos")]
    public class BancoEntity : BaseEntity<BancoEntity>, INotifyPropertyChanged 
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
        private bool  _inativo;
        private DateTime _dataCadastro;
        private DateTime _dataAtualizacao;
        private string _iban;
        private string _swiftCode;



        [Key, Display(Name = "ID", Description = ""), Column(TypeName = "int"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id
        {
            get => _id;
            set
            {
                if(_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        [Display(Name = "Nome", Description = ""), Column(TypeName = "varchar(100)")]
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
        [Display(Name = "Código", Description = ""), Column(TypeName = "varchar(5)")]
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
        [Display(Name = "N° Agência", Description = ""), Column(TypeName = "varchar(5)")]
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
        [Display(Name = "Dígito agência", Description = ""), Column(TypeName = "varchar(1)")]
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
        [Display(Name = "N° Conta", Description = ""), Column(TypeName = "varchar(5)")]
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
        [Display(Name = "Dígito conta", Description = ""), Column(TypeName = "varchar(1)")]
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
        [Display(Name = "Tipo", Description = ""), Column(TypeName = "int")]
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
        [Display(Name = "Nome titular", Description = ""), Column(TypeName = "varchar(100)")]
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
        [Display(Name = "Documento titular", Description = ""), Column(TypeName = "varchar(14)")]
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
        [Display(Name = "Chave pix", Description = ""), Column(TypeName = "varchar(100)")]
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
        [Display(Name = "Tipo pix", Description = ""), Column(TypeName = "int")]
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
        [Display(Name = "Internacional", Description = ""), Column(TypeName = "tinyint(1)")]
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
        [Display(Name = "Intivo", Description = ""), Column(TypeName = "tinyint(1)")]
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
        [Display(Name = "Cadastro", Description = ""), Column(TypeName = "datetime")]
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
        [Display(Name = "Atualização", Description = ""), Column(TypeName = "datetime")]
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

        [Display(Name = "IBAN", Description = ""), Column(TypeName = "varchar(50)")]
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
        [Display(Name = "SWIFT/BIC", Description = ""), Column(TypeName = "varchar(15)")]
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

    }
}
