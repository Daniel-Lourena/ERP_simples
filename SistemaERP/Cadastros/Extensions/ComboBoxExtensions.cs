using ModuloCadastro.Enum;
using ModuloConfiguracoes.Enum;
using ModuloConfiguracoes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaERP.Cadastros.Extensions
{
    public static class ComboBoxExtensions
    {
        public static void PreencherComboBoxList<T>(this ComboBox comboBox, List<T> dataSource, string valueMember, string displayMember, bool selecionarPrimeiro = false) where T : class
        {
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            comboBox.DataSource = dataSource;
            comboBox.Refresh();

            if (selecionarPrimeiro && comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }
        public static void PreencherComboBoxEnum<E>(this ComboBox comboBox, bool selecionarPrimeiro = false) where E : Enum
        {
            //List<EnumItem> dataSource = EnumExtensions.GetList<E>();

            //comboBox.ValueMember = nameof(EnumItem.Value);
            //comboBox.DisplayMember = nameof(EnumItem.Description);
            //comboBox.DataSource = dataSource;

            comboBox.DataSource = Enum.GetValues(typeof(E));

            if (selecionarPrimeiro && comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }
    }
}
