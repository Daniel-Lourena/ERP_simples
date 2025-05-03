using ModuloConfiguracoes.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuloConfiguracoes.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this System.Enum @enum)
        {
            if (@enum == null)
                return null;

            var field = @enum.GetType().GetField(@enum.ToString());
            if (field == null)
                return @enum.ToString();

            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? @enum.ToString() : attribute.Description;
        }

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
