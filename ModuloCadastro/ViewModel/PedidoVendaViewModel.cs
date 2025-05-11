using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModuloCadastro.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace ModuloCadastro.ViewModel
{
    public class PedidoVendaViewModel : INotifyPropertyChanged
    {
        private int _id;
        private int _idCliente;
        private int _idCriador;
        private DateTime? _dataCriacao;
        private DateTime? _dataAtualizacao;
        private int _usuarioAtualizacao;
        private bool _excluido;
        private DateTime? _dataExclusao;
        private int _usuarioFechamento;
        private DateTime? _dataFechamento;
        private string _nomeUsuarioFechamento;
        private string _nomeUsuarioAtualizacao;
        private string _nomeUsuarioCriador;


        [Display(Name = "id", Description = "")]
        public int id { get => _id; set { if (_id != value) { _id = value; OnPropertyChanged(); } } }
        [Display(Name = "idCliente", Description = "")]
        public int idCliente { get => _idCliente; set { if (_idCliente != value) { _idCliente = value; OnPropertyChanged(); } } }
        [Display(Name = "idCriador", Description = "")]
        public int idCriador { get => _idCriador; set { if (_idCriador != value) { _idCriador = value; OnPropertyChanged(); } } }
        [Display(Name = "Criação", Description = "")]
        public DateTime? dataCriacao { get => _dataCriacao; set { if (_dataCriacao != value) { _dataCriacao = value; OnPropertyChanged(); } } }
        [Display(Name = "Atualização", Description = "")]
        public DateTime? dataAtualizacao { get => _dataAtualizacao; set { if (_dataAtualizacao != value) { _dataAtualizacao = value; OnPropertyChanged(); } } }
        [Display(Name = "usuarioAtualizacao", Description = "")]
        public int usuarioAtualizacao { get => _usuarioAtualizacao; set { if (_usuarioAtualizacao != value) { _usuarioAtualizacao = value; OnPropertyChanged(); } } }
        [Display(Name = "excluido", Description = "")]
        public bool excluido { get => _excluido; set { if (_excluido != value) { _excluido = value; OnPropertyChanged(); } } }
        [Display(Name = "Exclusão", Description = "")]
        public DateTime? dataExclusao { get => _dataExclusao; set { if (_dataExclusao != value) { _dataExclusao = value; OnPropertyChanged(); } } }
        [Display(Name = "usuarioFechamento", Description = "")]
        public int usuarioFechamento { get => _usuarioFechamento; set { if (_usuarioFechamento != value) { _usuarioFechamento = value; OnPropertyChanged(); } } }
        [Display(Name = "Fechamento", Description = "")]
        public DateTime? dataFechamento { get => _dataFechamento; set { if (_dataFechamento != value) { _dataFechamento = value; OnPropertyChanged(); } } }
        [Display(Name = "Usuário Fechamento", Description = "")]
        public string nomeUsuarioFechamento { get => _nomeUsuarioFechamento; set { if (_nomeUsuarioFechamento != value) { _nomeUsuarioFechamento = value; OnPropertyChanged(); } } }
        [Display(Name = "Usuário Atualização", Description = "")]
        public string nomeUsuarioAtualizacao { get => _nomeUsuarioAtualizacao; set { if (_nomeUsuarioAtualizacao != value) { _nomeUsuarioAtualizacao = value; OnPropertyChanged(); } } }
        [Display(Name = "Usuário Criador", Description = "")]
        public string nomeUsuarioCriador { get => _nomeUsuarioCriador; set { if (_nomeUsuarioCriador != value) { _nomeUsuarioCriador = value; OnPropertyChanged(); } } }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propriedade = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
        }

        public PedidoVendaEntity ToEntity()
        {
            return new PedidoVendaEntity
            {
                Id = this.id,
                ClienteId = this.idCliente,
                UsuarioCriacaoId = this.idCriador,
                DataCriacao = this.dataCriacao,
                DataAtualizacao = this.dataAtualizacao,
                UsuarioAtualizacaoId = this.usuarioAtualizacao,
                Excluido = this.excluido,
                DataExclusao = this.dataExclusao,
                UsuarioFechamentoId = this.usuarioFechamento,
                DataFechamento = this.dataFechamento
            };
        }
    }
}
