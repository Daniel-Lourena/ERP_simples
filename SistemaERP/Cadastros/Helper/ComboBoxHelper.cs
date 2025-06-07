using ModuloCadastro.Entity;
using SistemaERP.Extensions;

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
    }
}
