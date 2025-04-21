using ModuloCadastro.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SistemaERP.Cadastros.Extensions
{
    public static class EnumExtensions
    {
        public static List<EnumItem> GetList<TEnum>() where TEnum : System.Enum
        {
            List<EnumItem> enumList = new();

            foreach (object value in System.Enum.GetValues(typeof(TEnum)))
            {
                string name = value.ToString();
                int intValue = (int)value;

                FieldInfo fi = typeof(TEnum).GetField(name);
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                string description = attributes.Length > 0 ? attributes[0].Description : name;

                enumList.Add(new EnumItem { Name = name, Description = description, Value = intValue });
            }

            return enumList;
        }
    }
}
