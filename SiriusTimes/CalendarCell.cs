using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace SiriusTimes
{
	public class CalendarCell : DataGridViewTextBoxCell
	{
		public CalendarCell() : base()
		{
		}

		public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
		{
			// Set the value of the editing control to the current cell value.
			base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
			CalendarEditingControl iCalendarEditingControl = DataGridView.EditingControl as CalendarEditingControl;

			if (Value != null && Value != DBNull.Value)
			{
				if (Value is TaskDate)
				{
					iCalendarEditingControl.Value = ((TaskDate)Value).ToDateTime;
				}
				else
				{
					iCalendarEditingControl.Value = (DateTime)Value;
				}
			}
		}

		public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter)
		{
			return new TaskDate(formattedValue);
		}

		public override Type EditType
		{
			// Return the type of the editing control that CalendarCell uses.
			get { return typeof(CalendarEditingControl); }
		}

		public override Type ValueType
		{
			// Return the type of the value that CalendarCell contains.
			get { return typeof(DateTime); }
		}

		public override object DefaultNewRowValue
		{
			// Use the current date and time as the default value.
			get { return DateTime.Now; }
		}
	}
}