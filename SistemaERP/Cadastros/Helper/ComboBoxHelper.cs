using ModuloCadastro.Entity;
using SistemaERP.Cadastros.Extensions;

namespace SistemaERP.Cadastros.Helper
{
    public static class ComboBoxHelper
    {
        public static void GetListEstados(this ComboBox cbEstados)
        {
            List<EstadoEntity> estados = new ModuloCadastro.Service.EstadoService().GetList().OrderBy(x => x.Nome).ToList();
            ComboBoxExtensions.PreencherComboBoxList(
                    cbEstados, estados, nameof(EstadoEntity.Cuf),
                    nameof(EstadoEntity.Nome), true);
        }
        public static void GetListCidades(this ComboBox cbCidades, int estado)
        {
            List<CidadeEntity> cidades = new ModuloCadastro.Service.CidadeService().GetListByEstado(estado).OrderBy(x => x.Dmunicipio).ToList();
            ComboBoxExtensions.PreencherComboBoxList(
                    cbCidades, cidades, nameof(CidadeEntity.Id),
                    nameof(CidadeEntity.Dmunicipio), true);
        }
        public static void GetList<T>(this ComboBox comboBox, List<T> dataSource, string valueMember, string displayMember, bool selecionarPrimeiro = false) where T : class
        {
            ComboBoxExtensions.PreencherComboBoxList(
                    comboBox, dataSource, valueMember,
                    displayMember, selecionarPrimeiro);
        }
        public static void GetListEnum<E>(this ComboBox comboBox) where E : Enum
        {
            ComboBoxExtensions.PreencherComboBoxEnum<E>(comboBox);
        }
    }
}
