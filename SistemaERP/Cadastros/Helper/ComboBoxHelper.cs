using ModuloCadastro.Entity;
using ModuloCadastro.Service;
using SistemaERP.Extensions;

namespace SistemaERP.Cadastros.Helper
{
    public static class ComboBoxHelper
    {
        public static void GetListEstados(this ComboBox cbEstados, EstadoService _serviceEstado)
        {
            List<EstadoEntity> estados = _serviceEstado.GetList().OrderBy(x => x.Nome).ToList();
            ComboBoxExtensions.PreencherComboBoxList(
                    cbEstados, estados, nameof(EstadoEntity.Cuf),
                    nameof(EstadoEntity.Nome), true);
        }
        public static void GetListCidades(this ComboBox cbCidades, CidadeService _serviceCidade, int estado)
        {
            List<CidadeEntity> cidades = _serviceCidade.GetListByEstado(estado).OrderBy(x => x.Dmunicipio).ToList();
            ComboBoxExtensions.PreencherComboBoxList(
                    cbCidades, cidades, nameof(CidadeEntity.Id),
                    nameof(CidadeEntity.Dmunicipio), true);
        }
    }
}
