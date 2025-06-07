using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaERP.Extensions.Personalizado.ColunasDataGridView
{
    public class CalendarioColuna : DataGridViewColumn
    {
        public CalendarioColuna() : base(new CalendarioCelula()) {}
        public override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;
            set
            {
                if (value is not CalendarioCelula)
                    throw new InvalidCastException("Célula precisa ser uma CalendarioCelula");
                base.CellTemplate = value;
            }
        }
    }
    public class CalendarioCelula : DataGridViewTextBoxCell
    {
        public CalendarioCelula() : base()
        {
            this.Style.Format = "dd/MM/yyyy";
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            CalendarioControle ctl = DataGridView.EditingControl as CalendarioControle;
            if (this.Value is DateTime dateTime)
            {
                ctl.Value = dateTime;
            }
            else
            {
                ctl.Value = DateTime.Now;
            }
        }

        public override Type EditType => typeof(CalendarioControle);

        public override Type ValueType => typeof(DateTime);

        public override object DefaultNewRowValue => DateTime.Now;
    }
    public class CalendarioControle : DateTimePicker, IDataGridViewEditingControl
    {
        private DataGridView dataGridView;
        private bool valueChanged = false;
        private int rowIndex;

        public CalendarioControle()
        {
            this.Format = DateTimePickerFormat.Short;
        }

        public object EditingControlFormattedValue
        {
            get => this.Value.ToShortDateString();
            set
            {
                if (DateTime.TryParse(value as string, out DateTime result))
                {
                    this.Value = result;
                }
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) => EditingControlFormattedValue;

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        public int EditingControlRowIndex
        {
            get => rowIndex;
            set => rowIndex = value;
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
            => keyData == Keys.Left || keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Right ||
               keyData == Keys.Home || keyData == Keys.End || keyData == Keys.PageDown || keyData == Keys.PageUp;

        public void PrepareEditingControlForEdit(bool selectAll) { }

        public bool RepositionEditingControlOnValueChange => false;

        public DataGridView EditingControlDataGridView
        {
            get => dataGridView;
            set => dataGridView = value;
        }

        public bool EditingControlValueChanged
        {
            get => valueChanged;
            set => valueChanged = value;
        }

        public Cursor EditingPanelCursor => base.Cursor;

        protected override void OnValueChanged(EventArgs eventargs)
        {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
}
