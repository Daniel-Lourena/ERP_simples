using ModuloCadastro.Entity;
using SistemaERP.Cadastros.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaERP.Cadastros.Helper
{
    public static class ComboBoxHelper
    {
        public static void GetListEstados(this ComboBox cbEstados)
        {
            List<EstadoEntity> estados = new ModuloCadastro.Service.EstadoService().GetList().OrderBy(x => x.nome).ToList();
            ComboBoxExtensions.PreencherComboBoxList(
                    cbEstados, estados, nameof(EstadoEntity.cuf),
                    nameof(EstadoEntity.nome), true);
        }
        public static void GetListCidades(this ComboBox cbCidades, int estado)
        {
            List<CidadeEntity> cidades = new ModuloCadastro.Service.CidadeService().GetListByEstado(estado).OrderBy(x => x.dmunicipio).ToList();
            ComboBoxExtensions.PreencherComboBoxList(
                    cbCidades, cidades, nameof(CidadeEntity.id),
                    nameof(CidadeEntity.dmunicipio), true);
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
