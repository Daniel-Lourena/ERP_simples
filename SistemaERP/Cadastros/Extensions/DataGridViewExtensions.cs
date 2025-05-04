using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ModuloConfiguracoes.Extensions;
using System.ComponentModel;

namespace SistemaERP.Cadastros.Extensions
{
    public static class DataGridViewExtensions
    {
        public static void CriarColunasDataGridView<T>(this DataGridView dgvGenerico,List<T> listaDataSource, List<(string nomeColuna,bool readOnly,bool visible)> popularColunas)
        {
            dgvGenerico.AutoGenerateColumns = false;

            PropertyInfo[]? propriedades = typeof(T).GetProperties().Where(x => x.GetCustomAttribute<NotMappedAttribute>() == null).ToArray();

            if (dgvGenerico.Columns.Count == 0)
            {
                foreach (var prop in propriedades)
                {
                    var col = popularColunas.FirstOrDefault(x => x.nomeColuna.Equals(prop.Name));
                    if (!String.IsNullOrEmpty(col.nomeColuna))
                    {
                        var atributoPropriedade = prop.GetCustomAttribute<DisplayAttribute>();
                        DataGridViewTextBoxColumn coluna = new()
                        {
                            DataPropertyName = prop.Name,
                            ReadOnly = col.readOnly,
                            Visible = col.visible,
                            Name = prop.Name,
                            HeaderText = atributoPropriedade == null ? prop.Name : atributoPropriedade.Name
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
