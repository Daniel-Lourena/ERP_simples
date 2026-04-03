using ModuloCadastro.Entity.Cadastro.Produto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ModuloCadastro.ViewModel.Cadastro.Produto
{
    public class CategoriaViewModel : INotifyPropertyChanged
    {
        private int _id;
        private string _descricao;

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

        [Display(Name = "Descrição", Description = "")]
        public string? descricao
        {
            get => _descricao;
            set
            {
                if (_descricao != value)
                {
                    _descricao = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propriedade = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
        }

        public CategoriaEntity ToEntity()
        {
            return new CategoriaEntity
            {
                Id = this.id,
                Descricao = this.descricao
            };
        }
    }
}
