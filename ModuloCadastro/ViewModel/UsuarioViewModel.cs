using ModuloCadastro.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloConfiguracoes.Extensions;
using ModuloCadastro.Entity;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ModuloCadastro.ViewModel
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        private int _id;
        private string _nome;
        private ECargo _cargo;
        private DateTime? _dataCadastro;
        private DateTime? _dataAtualizacao;
        private bool _excluido;
        private DateTime? _dataExclusao;



        [Display(Name = "ID", Description = "")]
        public int id { get => _id; set { if (_id != value) { _id = value; OnPropertyChanged(); } } }
        [Display(Name = "Nome", Description = "")]
        public string nome { get => _nome; set { if (_nome != value) { _nome = value; OnPropertyChanged(); } } }
        [Display(Name = "Cargo", Description = "")]
        public ECargo cargo { get => _cargo; set { if (_cargo != value) { _cargo = value; OnPropertyChanged(); } } }
        [Display(Name = "Dta. Cadastro", Description = "")]
        public DateTime? dataCadastro { get => _dataCadastro; set { if (_dataCadastro != value) { _dataCadastro = value; OnPropertyChanged(); } } }
        [Display(Name = "Dta. Atualização", Description = "")]
        public DateTime? dataAtualizacao { get => _dataAtualizacao; set { if (_dataAtualizacao != value) { _dataAtualizacao = value; OnPropertyChanged(); } } }
        [Display(Name = "Excluído", Description = "")]
        public bool excluido { get => _excluido; set { if (_excluido != value) { _excluido = value; OnPropertyChanged(); } } }
        [Display(Name = "Dta. Exclusão", Description = "")]
        public DateTime? dataExclusao { get => _dataExclusao; set { if (_dataExclusao != value) { _dataExclusao = value; OnPropertyChanged(); } } }
        [Display(Name = "Descrição Cargo", Description = "")]
        public string _descricaoCargo => _cargo.GetDescription();


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propriedade = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
        }

        public UsuarioEntity ToEntity()
        {
            return new UsuarioEntity
            {
                id = id,
                nome = nome,
                cargo = cargo,
                dataCadastro = dataCadastro,
                dataAtualizacao = dataAtualizacao,
                dataExclusao = dataExclusao,
                excluido = excluido
            };
        }
        
    }
}
