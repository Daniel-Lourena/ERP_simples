using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuloConfiguracoes.Extensions
{
    public static class MySqlDataReaderExtensions
    {
        public static T MapTo<T>(this MySqlDataReader reader) where T : new()
        {
            T obj = new T();
            Type objType = typeof(T);

            DataTable schemaTable = reader.GetSchemaTable();
            HashSet<string> columnNames = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

            foreach (DataRow row in schemaTable.Rows)
            {
                columnNames.Add(row["ColumnName"].ToString());
            }

            Dictionary<string, PropertyInfo> properties = objType.GetProperties()
                                .Where(prop => columnNames.Contains(prop.Name))
                                .ToDictionary(prop => prop.Name, prop => prop);

            foreach (KeyValuePair<string, PropertyInfo> entry in properties)
            {
                PropertyInfo prop = entry.Value;
                int ordinal = reader.GetOrdinal(entry.Key);

                if (reader.IsDBNull(ordinal)) continue;

                Type propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                object safeValue = null;

                if (propType.IsEnum)
                {
                    int intValue = reader.GetInt32(ordinal);
                    safeValue = System.Enum.ToObject(propType, intValue);
                }
                else if (propType == typeof(int))
                {
                    if (reader.GetFieldType(ordinal) == typeof(string))
                    {
                        string stringValue = reader.GetString(ordinal);
                        if (int.TryParse(stringValue, out int intValue))
                        {
                            safeValue = intValue;
                        }
                        else
                        {
                            throw new InvalidCastException($"Não foi possível converter o valor '{stringValue}' para o tipo int na propriedade '{prop.Name}'.");
                        }
                    }
                    else
                    {
                        safeValue = reader.GetInt32(ordinal);
                    }
                }
                else if (propType == typeof(string))
                {
                    safeValue = reader.GetString(ordinal);
                }
                else if (propType == typeof(bool))
                {
                    safeValue = reader.GetBoolean(ordinal);
                }
                else if (propType == typeof(DateTime))
                {
                    safeValue = reader.GetDateTime(ordinal);
                }
                else if (propType == typeof(decimal))
                {
                    safeValue = reader.GetDecimal(ordinal);
                }
                else if (propType == typeof(byte[]))
                {
                    safeValue = reader[ordinal] as byte[];
                }
                else if (propType == typeof(System.Drawing.Color))
                {
                    if (reader.GetFieldType(ordinal) == typeof(string))
                    {
                        string stringValue = reader.GetString(ordinal);
                        if (int.TryParse(stringValue, out int intValue))
                        {
                            safeValue = System.Drawing.Color.FromArgb(intValue);
                        }
                        else
                        {
                            throw new InvalidCastException($"Não foi possível converter o valor '{stringValue}' para o tipo int na propriedade '{prop.Name}'.");
                        }
                    }
                    else
                    {
                        int argbValue = reader.GetInt32(ordinal);
                        safeValue = System.Drawing.Color.FromArgb(argbValue);
                    }
                }
                else
                {
                    safeValue = Convert.ChangeType(reader[ordinal], propType);
                }

                prop.SetValue(obj, safeValue, null);
            }
            return obj;
        }
    }
}
