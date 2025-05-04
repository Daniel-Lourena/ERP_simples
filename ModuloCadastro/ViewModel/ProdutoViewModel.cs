using ModuloCadastro.Entity;
using ModuloCadastro.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ModuloConfiguracoes.Extensions;

namespace ModuloCadastro.ViewModel
{
    public class ProdutoViewModel : INotifyPropertyChanged
    {
        private int _id;
        private string _descricao;
        private EUnidadeProduto _idUnidade;
        private string _cest;
        private string _ncm;
        private string _codigoEstoque_SKU;
        private int _categoria;
        private decimal _estoqueMinimo;
        private EOrigemProduto _origem;
        private ECst _cst_csosn;
        private bool _inativo;
        private int _usuarioCadastro;
        private DateTime? _dataCadastro;
        private DateTime? _dataAtualizacao;
        private CategoriaEntity _DadosCategoria;


        [Display(Name = "ID", Description = "")]
        public int id { get => _id; set { if (_id != value) { _id = value; OnPropertyChanged(); } } }
        [Display(Name = "Descrição", Description = "")]
        public string descricao { get => _descricao; set { if (_descricao != value) { _descricao = value; OnPropertyChanged(); } } }
        [Display(Name = "Un.", Description = "")]
        public EUnidadeProduto idUnidade { get => _idUnidade; set { if (_idUnidade != value) { _idUnidade = value; OnPropertyChanged(); } } }
        [Display(Name = "CEST", Description = "")]
        public string cest { get => _cest; set { if (_cest != value) { _cest= value; OnPropertyChanged(); } } }
        [Display(Name = "NCM", Description = "")]
        public string ncm { get => _ncm; set { if (_ncm != value) { _ncm  = value; OnPropertyChanged(); } } }
        [Display(Name = "Cód. Estoque", Description = "")]
        public string codigoEstoque_SKU { get => _codigoEstoque_SKU; set { if (_codigoEstoque_SKU!= value) { _codigoEstoque_SKU = value; OnPropertyChanged(); } } }
        [Display(Name = "Categoria", Description = "")]
        public int categoria { get => _categoria; set { if (_categoria!= value) { _categoria = value; OnPropertyChanged(); } } }
        [Display(Name = "Est. Mínimo", Description = "")]
        public decimal estoqueMinimo { get => _estoqueMinimo; set { if (_estoqueMinimo!= value) { _estoqueMinimo = value; OnPropertyChanged(); } } }
        [Display(Name = "Origem", Description = "")]
        public EOrigemProduto origem { get => _origem; set { if (_origem!= value) { _origem = value; OnPropertyChanged(); } } }
        [Display(Name = "CST/CSOSN", Description = "")]
        public ECst cst_csosn { get => _cst_csosn; set { if (_cst_csosn != value) { _cst_csosn = value; OnPropertyChanged(); } } }
        [Display(Name = "Inativo", Description = "")]
        public bool inativo { get => _inativo; set { if (_inativo!= value) { _inativo = value; OnPropertyChanged(); } } }
        [Display(Name = "Usuário Cadastro", Description = "")]
        public int usuarioCadastro { get => _usuarioCadastro; set { if (_usuarioCadastro!= value) { _usuarioCadastro = value; OnPropertyChanged(); } } }
        [Display(Name = "Dta. Cadastro", Description = "")]
        public DateTime? dataCadastro { get => _dataCadastro; set { if (_dataCadastro!= value) { _dataCadastro = value; OnPropertyChanged(); } } }
        [Display(Name = "Dta. Atualização", Description = "")]
        public DateTime? dataAtualizacao { get => _dataAtualizacao; set { if (_dataAtualizacao!= value) { _dataAtualizacao = value; OnPropertyChanged(); } } }

        [Display(Name = "Unidade", Description = "")]
        public string descricaoUnidade => idUnidade.GetDescription();
        [Display(Name = "Categoria", Description = "")]
        public string? descricaoCategoria => DadosCategoria.descricao;

        public CategoriaEntity DadosCategoria { get => _DadosCategoria; set { if (_DadosCategoria != value) { _DadosCategoria = value; OnPropertyChanged(); } } }



        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propriedade = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
        }

        public ProdutoEntity ToEntity()
        {
            return new ProdutoEntity
            {
                id = this.id,
                descricao = this.descricao,
                idUnidade = this.idUnidade,
                cest = this.cest,
                ncm = this.ncm,
                codigoEstoque_SKU = this.codigoEstoque_SKU,
                categoria = this.categoria,
                estoqueMinimo = this.estoqueMinimo,
                origem = this.origem,
                cst_csosn = this.cst_csosn,
                inativo = this.inativo,
                usuarioCadastro = this.usuarioCadastro,
                dataCadastro = this.dataCadastro,
                dataAtualizacao = this.dataAtualizacao,
                DadosCategoria = this.DadosCategoria
            };
        }
    }
}
