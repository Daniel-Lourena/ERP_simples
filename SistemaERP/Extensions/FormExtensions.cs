using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaERP.Extensions
{
    public static class FormExtensions
    {
        public static void ConfiguraTabIndex(this Form form)
        {
            List<Control> controles = new List<Control>();

            void AddControls(Control parent)
            {
                foreach (Control control in parent.Controls)
                {
                    controles.Add(control);
                    if (control.HasChildren)
                    {
                        AddControls(control);
                    }
                }
            }

            AddControls(form);

            List<Control> orderm = controles
                .OrderBy(c => c.Top)
                .ThenBy(c => c.Left)
                .ToList();

            for (int i = 0; i < orderm.Count; i++)
            {
                orderm[i].TabIndex = i;
            }
        }
    }
}
