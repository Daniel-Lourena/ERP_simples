using ModuloCadastro.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaERP.Cadastros.Extensions.Helper
{
    public static class ComboBoxHelper
    {
        public static void PreencherComboBoxList<T>(ComboBox comboBox,List<T> dataSource,string valueMember,string displayMember, bool selecionarPrimeiro = false) where T : class
        {
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            comboBox.DataSource = dataSource;
            comboBox.Refresh();

            if (selecionarPrimeiro && comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }
        public static void PreencherComboBoxEnum<E>(ComboBox comboBox,bool selecionarPrimeiro = false) where E : Enum
        {
            List<EnumItem> dataSource = Extensions.EnumExtensions.GetList<E>();

            comboBox.ValueMember = nameof(EnumItem.Value);
            comboBox.DisplayMember = nameof(EnumItem.Name);
            comboBox.DataSource = dataSource;

            if (selecionarPrimeiro && comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }
    }
}
