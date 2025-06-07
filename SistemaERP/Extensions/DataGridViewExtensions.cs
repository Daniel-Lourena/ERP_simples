using SistemaERP.Extensions.Personalizado.ColunasDataGridView;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace SistemaERP.Extensions
{
    public static class DataGridViewExtensions
    {
        public static void CriarColunasDataGridView<T>(this DataGridView dgvGenerico, List<T> listaDataSource, List<(string nomeColuna, bool readOnly, bool visible)> popularColunas)
        {
            dgvGenerico.AutoGenerateColumns = false;

            PropertyInfo[]? propriedades = typeof(T).GetProperties().Where(x => x.GetCustomAttribute<NotMappedAttribute>() == null).ToArray();

            if (dgvGenerico.Columns.Count == 0)
            {
                foreach (var prop in propriedades)
                {
                    var col = popularColunas.FirstOrDefault(x => x.nomeColuna.Equals(prop.Name));
                    if (!string.IsNullOrEmpty(col.nomeColuna))
                    {
                        var atributoPropriedade = prop.GetCustomAttribute<DisplayAttribute>();
                        var atributoDisplayPropriedade = prop.GetCustomAttribute<DisplayFormatAttribute>();

                        DataGridViewColumn coluna;

                        if (col.readOnly is false && (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?)))
                        {
                            coluna = new CalendarioColuna();
                        }
                        else
                        {
                            coluna = new DataGridViewTextBoxColumn();
                        }

                        coluna.DataPropertyName = prop.Name;
                        coluna.ReadOnly = col.readOnly;
                        coluna.Visible = col.visible;
                        coluna.Name = prop.Name;
                        coluna.HeaderText = atributoPropriedade == null ? prop.Name : atributoPropriedade.Name;
                        coluna.DefaultCellStyle = new DataGridViewCellStyle
                        {
                            Format = atributoDisplayPropriedade != null ?
                                atributoDisplayPropriedade.DataFormatString.Replace("{0:", "").Replace("}", "") : string.Empty
                        };

                        dgvGenerico.Columns.Add(coluna);
                    }
                }
            }

            dgvGenerico.DataSource = null;
            dgvGenerico.DataSource = new BindingList<T>(listaDataSource);
            dgvGenerico.Refresh();
        }
    }
}
