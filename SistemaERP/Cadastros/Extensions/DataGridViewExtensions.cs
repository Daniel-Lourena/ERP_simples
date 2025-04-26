using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SistemaERP.Cadastros.Extensions
{
    public static class DataGridViewExtensions
    {
        public static void CriarColunasDataGridView<T>(this DataGridView dgvGenerico,List<T> listaDataSource, List<(string nomeColuna,bool readOnly)> popularColunas)
        {
            dgvGenerico.Columns.Clear();
            dgvGenerico.Refresh();

            PropertyInfo[]? propriedades = typeof(T).GetProperties().Where(x => x.GetCustomAttribute<NotMappedAttribute>() == null).ToArray();

            foreach (var prop in propriedades)
            {
                var col = popularColunas.FirstOrDefault(x => x.nomeColuna.Equals(prop.Name));
                if (!String.IsNullOrEmpty(col.nomeColuna))
                {
                    DataGridViewTextBoxColumn coluna = new()
                    {
                        DataPropertyName = prop.Name,
                        ReadOnly = col.readOnly,
                        Name = prop.Name,
                        HeaderText = prop.GetCustomAttribute<DisplayAttribute>().Name ?? prop.Name
                    };
                    dgvGenerico.Columns.Add(coluna);
                }
            }

            foreach (var item in listaDataSource)
            {
                object[] valores = popularColunas.Select(col =>
                {
                    var propriedade = item.GetType().GetProperty(col.nomeColuna);
                    var valor = propriedade?.GetValue(item);

                    if (valor is Enum enumValor)
                        return enumValor.GetDescription(); 

                    return valor;
                }).ToArray(); 
                
                dgvGenerico.Rows.Add(valores);
            }

            dgvGenerico.Refresh();
        }
    }
}
