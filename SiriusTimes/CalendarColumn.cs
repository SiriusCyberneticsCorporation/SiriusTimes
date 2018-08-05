using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace SiriusTimes
{
	public class CalendarColumn : DataGridViewColumn
	{
		public CalendarColumn()
			: base(new CalendarCell())
		{
			
		}

		[Description("Format string for the date."),
		Category("Appearance"),
		DefaultValue("dd-MM-yyyy"),
		Browsable(true)]
		public string Format
		{
			get { return this.DefaultCellStyle.Format; }
			set { this.DefaultCellStyle.Format = value; }
		}

		public override DataGridViewCell CellTemplate
		{
			get { return base.CellTemplate; }
			set
			{
				// Ensure that the cell used for the template is a CalendarCell.
				if (value != null && !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
				{
					throw new InvalidCastException("Must be a CalendarCell");
				}
				base.CellTemplate = value;
			}
		}
	}
}