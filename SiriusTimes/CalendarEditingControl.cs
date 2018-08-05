using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace SiriusTimes
{
	class CalendarEditingControl : NullableDatePicker, IDataGridViewEditingControl
	{
		private int m_rowIndex;
		private bool m_valueChanged = false;
		private DataGridView m_dataGridView = null;

		public CalendarEditingControl()
		{
		}

		// Implements the IDataGridViewEditingControl.EditingControlFormattedValue property.
		public object EditingControlFormattedValue
		{
			get { return this.ToFormattedString(); }
			set
			{
				if (value is String)
				{
					this.Value = DateTime.Parse((String)value);
				}
			}
		}

		// Implements the IDataGridViewEditingControl.GetEditingControlFormattedValue method.
		public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
		{
			return EditingControlFormattedValue;
		}

		// Implements the IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
		public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
		{
			this.Font = dataGridViewCellStyle.Font;
			this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
			this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
			this.Format = DateTimePickerFormat.Custom;
			this.CustomFormat = dataGridViewCellStyle.Format;
		}

		// Implements the IDataGridViewEditingControl.EditingControlRowIndex property.
		public int EditingControlRowIndex
		{
			get { return m_rowIndex; }
			set { m_rowIndex = value; }
		}

		// Implements the IDataGridViewEditingControl.EditingControlWantsInputKey method.
		public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
		{
			// Let the DateTimePicker handle the keys listed.
			switch (key & Keys.KeyCode)
			{
				case Keys.Left:
				case Keys.Up:
				case Keys.Down:
				case Keys.Right:
				case Keys.Home:
				case Keys.End:
				case Keys.PageDown:
				case Keys.PageUp:
				case Keys.Tab:
					return true;
				default:
					return !dataGridViewWantsInputKey;
			}
		}

		// Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit method.
		public void PrepareEditingControlForEdit(bool selectAll)
		{
			// No preparation needs to be done.
		}

		// Implements the IDataGridViewEditingControl.RepositionEditingControlOnValueChange property.
		public bool RepositionEditingControlOnValueChange
		{
			get { return false; }
		}

		// Implements the IDataGridViewEditingControl.EditingControlDataGridView property.
		public DataGridView EditingControlDataGridView
		{
			get { return m_dataGridView; }
			set { m_dataGridView = value; }
		}

		// Implements the IDataGridViewEditingControl.EditingControlValueChanged property.
		public bool EditingControlValueChanged
		{
			get { return m_valueChanged; }
			set { m_valueChanged = value; }
		}

		// Implements the IDataGridViewEditingControl.EditingPanelCursor property.
		public Cursor EditingPanelCursor
		{
			get { return base.Cursor; }
		}

		/// <summary>
		/// When the value changes mark it as changed and tell the DataGridView that the cell has changed.
		/// If this is not done then the value will not be shown and any underlying DataSource will not be updated.
		/// </summary>
		/// <param name="eventargs"></param>
		protected override void OnValueChanged(EventArgs eventargs)
		{
			// Notify the DataGridView that the contents of the cell have changed.
			m_valueChanged = true;
			this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
			base.OnValueChanged(eventargs);
		}

		public static DateTime GetDateTime(object dataTableValue)
		{
			DateTime result = DateTime.MinValue;

			if (dataTableValue != null && !Convert.IsDBNull(dataTableValue))
			{
				DateTime.TryParse(dataTableValue.ToString(), out result);
			}

			return result;
		}

		/// <summary>
		/// If the user drops down the calendar control and then either selects the date that is already selected 
		/// or simply closes the calendar control then the OnValueChanged event is not triggered. This happens even
		/// when the cell grid previously displayed blank.
		/// In order to solve this problem and not generate bogus value changed notifications for users simply
		/// browsing the displayed information it is necessary to compare the cell value against the calendar
		/// controls value. If they differ then mark the cell as changed.
		/// </summary>
		/// <param name="eventargs"></param>
		protected override void OnCloseUp(EventArgs eventargs)
		{
			if (m_dataGridView != null && m_dataGridView.CurrentCell != null)
			{
				DateTime cellValue = GetDateTime(m_dataGridView.CurrentCell.Value);

				if (cellValue != this.DateTimeValue)
				{
					// Notify the DataGridView that the contents of the cell have changed.
					m_valueChanged = true;
					this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
				}
			}
			base.OnCloseUp(eventargs);
		}

		/// <summary>
		/// If the user tabs into a calendar cell types a single digit and then tabs out again the calendar
		/// control is never shown so the OnCloseUp event is not triggered. It is also possible that the OnValueChanged
		/// event will not be triggered. It is therefore necessary to trap the validation event and check to see
		/// if the cell being validated and the calendar control have different values - if so then save the new
		/// value into the cell and mark the cell as dirty.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnValidating(CancelEventArgs e)
		{
			if (m_dataGridView != null && m_dataGridView.CurrentCell != null)
			{
				DateTime cellValue = GetDateTime(m_dataGridView.CurrentCell.Value);

				if (cellValue != this.DateTimeValue)
				{
					m_dataGridView.CurrentCell.Value = this.DateTimeValue;
					// Notify the DataGridView that the contents of the cell have changed.
					m_valueChanged = true;
					this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
				}
			}
			base.OnValidating(e);
		}
	}
}