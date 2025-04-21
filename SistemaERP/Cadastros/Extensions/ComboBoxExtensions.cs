using ModuloCadastro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaERP.Cadastros.Extensions
{
    internal static class ComboBoxExtensions
    {
        public static void GetListEstados(this ComboBox cbEstados)
        {
            List<EstadoEntity> estados = new ModuloCadastro.Context.EstadoContext().GetList();
            Extensions.Helper.ComboBoxHelper.PreencherComboBoxList(
                    cbEstados, estados, nameof(EstadoEntity.cuf),
                    nameof(EstadoEntity.nome), true);
        }
        public static void GetListCidades(this ComboBox cbCidades, int estado)
        {
            List<CidadeEntity> cidades = new ModuloCadastro.Context.CidadeContext().GetListByEstado(estado);
            Extensions.Helper.ComboBoxHelper.PreencherComboBoxList(
                    cbCidades, cidades, nameof(CidadeEntity.id),
                    nameof(CidadeEntity.dmunicipio), true);
        }
        public static void GetList<T>(this ComboBox comboBox, List<T> dataSource,string valueMember,string displayMember,bool selecionarPrimeiro = false) where T : class 
        {
            Extensions.Helper.ComboBoxHelper.PreencherComboBoxList(
                    comboBox, dataSource, valueMember,
                    displayMember, selecionarPrimeiro);
        }
        public static void GetListEnum<E>(this ComboBox comboBox) where E : Enum
        {
            Extensions.Helper.ComboBoxHelper.PreencherComboBoxEnum<E>(comboBox);
        }
    }
}
