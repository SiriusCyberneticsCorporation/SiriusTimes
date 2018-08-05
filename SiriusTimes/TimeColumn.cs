using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiriusTimes
{
	public class TimeColumn : DataGridViewColumn
	{
		public TimeColumn()
			: base(new TimeCell())
		{

		}

		[Description("Format string for the time."),
		Category("Appearance"),
		DefaultValue("HH:mm"),
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
				// Ensure that the cell used for the template is a TimeCell.
				if (value != null && !value.GetType().IsAssignableFrom(typeof(TimeCell)))
				{
					throw new InvalidCastException("Must be a TimeCell");
				}
				base.CellTemplate = value;
			}
		}
	}
}
