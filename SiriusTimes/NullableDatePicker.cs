using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SiriusTimes
{
	public class NullableDatePicker : DateTimePicker
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private bool m_isRealDate = true;
		private bool m_calendarOpen = false;
		private bool m_settingDateOrFormat = false;
		private string m_oldCustomFormat = string.Empty;
		private DateTimePickerFormat m_oldFormat;

		public NullableDatePicker()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			this.MaxDate = new DateTime(2079, 1, 1);
		}

		public bool IsNull { get { return !m_isRealDate; } }
		public bool CalendarOpen { get { return m_calendarOpen; } }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		
		#endregion

		public DateTime DateTimeValue
		{
			get
			{
				if (m_isRealDate)
				{
					return base.Value.Date;
				}
				else
				{
					return DateTime.MinValue;
				}
			}
		}

		// Bindable true: so we can bind to the property
		// Browsable false: if browsable is set to false, the property does not appear in the property panel in the form designer
		// Browsable is by default true (a public property normally appears in the property panel)
		[Bindable(true), Browsable(false)]
		public new object Value
		{
			get
			{
				if (m_isRealDate)
				{
					return base.Value.Date;
				}
				else
				{
					return DBNull.Value; // If not a real date, sent DBNull to the bound field
				}
			}
			set
			{
				if (!m_settingDateOrFormat)
				{
					m_settingDateOrFormat = true;
					if (Convert.IsDBNull(value) || Convert.ToDateTime(value) == DateTime.MinValue)
					{
						if (m_isRealDate)
						{
							m_isRealDate = false;
							m_oldFormat = Format; // Store the Format of the DateTimePicker
							m_oldCustomFormat = CustomFormat;
						}

						// Setting the format to a blank custom format makes the DateTimePicker show blank.
						Format = DateTimePickerFormat.Custom;
						CustomFormat = " "; // With this custom format, the DateTimePicker is empty
					}
					else
					{
						if (!m_isRealDate)
						{
							m_isRealDate = true;
							Format = m_oldFormat; // Restore the Format of the DateTimePicker
							CustomFormat = m_oldCustomFormat;
						}
						base.Value = Convert.ToDateTime(value);
					}
					m_settingDateOrFormat = false;
				}
			}
		}

		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Delete)
			{
				Value = MinDate; // Trigger changed
				Value = DateTime.Today; // For drop down
				Value = DBNull.Value; // To DBNull
			}
			else
			{
				if (!m_isRealDate)
				{
					// If no date present and edit started, start at the current date...
					m_settingDateOrFormat = true;
					Format = m_oldFormat; // Restore the format for a real date.
					CustomFormat = m_oldCustomFormat; // If you don't reset the custom format to 'null' the DateTimePicker will stay empty
					m_isRealDate = true;
					Value = DateTime.Today;
					m_settingDateOrFormat = false;
					OnValueChanged(null);
				}
			}
		}

		protected override void OnDropDown(EventArgs eventargs)
		{
			m_calendarOpen = true;
			base.OnDropDown(eventargs);
		}

		protected override void OnCloseUp(EventArgs eventargs)
		{
			m_calendarOpen = false;
			// This is the magic touch!!!!
			if (Control.MouseButtons == MouseButtons.None)
			{
				if (!m_isRealDate)
				{
					m_settingDateOrFormat = true;
					Format = m_oldFormat; //Restore the format for a real date
					CustomFormat = m_oldCustomFormat; //If you don't reset the custom format to 'null' the DateTimePicker will stay empty
					m_isRealDate = true;
					DateTime tempdate;
					tempdate = (DateTime)Value;
					Value = MinDate;
					Value = tempdate;
					m_settingDateOrFormat = false;
					OnValueChanged(null);
				}
			}
			base.OnCloseUp(eventargs);
		}

		public string ToFormattedString()
		{
			if (!m_isRealDate)
			{
				return String.Empty;
			}
			else
			{
				switch(Format)
				{
					case DateTimePickerFormat.Custom:
						return base.Text;//.Value.ToString(CustomFormat);
					case DateTimePickerFormat.Long:
						return base.Value.ToLongDateString();
					case DateTimePickerFormat.Short:
						return base.Value.ToShortDateString();
					case DateTimePickerFormat.Time:
						return base.Value.ToShortTimeString();
					default:
						return base.Value.ToShortDateString();
				}
			}
		}
	}
}
