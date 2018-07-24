using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiriusTimes
{
	public partial class SiriusTimesForm : Form
	{
		private const string TIMESHEET_DATABASE = "SiriusTimes.db";

		private LiteDatabase m_timesheetDatabase = null;
		private LiteCollection<TimesheetRecord> m_timesheets = null;

		public SiriusTimesForm()
		{
			InitializeComponent();

			// this is the default
			this.WindowState = FormWindowState.Normal;
			this.StartPosition = FormStartPosition.WindowsDefaultBounds;

			// check if the saved bounds are nonzero and visible on any screen
			if (Properties.Settings.Default.WindowPosition != Rectangle.Empty &&
				IsVisibleOnAnyScreen(Properties.Settings.Default.WindowPosition))
			{
				// first set the bounds
				this.StartPosition = FormStartPosition.Manual;
				this.DesktopBounds = Properties.Settings.Default.WindowPosition;

				// afterwards set the window state to the saved value (which could be Maximized)
				this.WindowState = Properties.Settings.Default.WindowState;
			}
			else
			{
				// this resets the upper left corner of the window to windows standards
				this.StartPosition = FormStartPosition.WindowsDefaultLocation;

				// we can still apply the saved size
				if (Properties.Settings.Default.WindowPosition != Rectangle.Empty)
				{
					this.Size = Properties.Settings.Default.WindowPosition.Size;
				}
			}
		}

		private void SiriusTimesForm_Load(object sender, EventArgs e)
		{
			m_timesheetDatabase = new LiteDatabase(TIMESHEET_DATABASE);
			m_timesheets = m_timesheetDatabase.GetCollection<TimesheetRecord>();

			//m_timesheets.EnsureIndex(t => t.FolderName);
		}

		private void SiriusTimesForm_Shown(object sender, EventArgs e)
		{
			List<TimesheetRecord> allRecords = m_timesheets.FindAll().ToList();
			List<string> clients = allRecords.Select(t => t.Client).Distinct().ToList();

			ClientComboBox.DataSource = clients;

			int minuteRoundedDown = (int)(Math.Floor(DateTime.Now.Minute / 5D) * 5);
			int minuteRoundedUp = (int)(Math.Ceiling(DateTime.Now.Minute / 5D) * 5);

			StartTimeDateTimePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, minuteRoundedDown, 0);

			if (minuteRoundedUp >= 60)
			{
				EndTimeDateTimePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour+1, 0, 0);
			}
			else
			{
				EndTimeDateTimePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, minuteRoundedUp, 0);
			}

			RefreshTimesheetDataGridView();
		}

		private void SiriusTimesForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// only save the WindowState if Normal or Maximized
			switch (this.WindowState)
			{
				case FormWindowState.Normal:
				case FormWindowState.Maximized:
					Properties.Settings.Default.WindowState = this.WindowState;
					Properties.Settings.Default.WindowPosition = DesktopBounds;
					break;

				default:
					// No changes if minimized.
					break;
			}

			Properties.Settings.Default.Save();
		}

		private bool IsVisibleOnAnyScreen(Rectangle rect)
		{
			foreach (Screen screen in Screen.AllScreens)
			{
				if (screen.WorkingArea.IntersectsWith(rect))
				{
					return true;
				}
			}

			return false;
		}

		private void TaskAddButton_Click(object sender, EventArgs e)
		{
			TimesheetRecord iTimesheetRecord = new TimesheetRecord()
			{
				Client = ClientComboBox.Text,
				Project = ProjectComboBox.Text,
				TaskDate = TaskDateDateTimePicker.Value,
				TaskTitle = TaskTitleTextBox.Text,
				StartTime = StartTimeDateTimePicker.Value,
				EndTime = EndTimeDateTimePicker.Value
			};
			m_timesheets.Insert(iTimesheetRecord);

			StartTimeDateTimePicker.Value = EndTimeDateTimePicker.Value;

			RefreshTimesheetDataGridView();
		}

		private void ClientComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<TimesheetRecord> clientRecords = m_timesheets.Find(t => t.Client == ClientComboBox.Text).ToList();
			List<string> projects = clientRecords.Select(t => t.Project).Distinct().ToList();

			ProjectComboBox.DataSource = projects;
		}

		public class SummaryLine
		{
			public SummaryLine() { }

			public string Client { get; set; }
			public TaskDate TaskDate { get; set; }
			public double Hours { get; set; }
		}

		private void RefreshTimesheetDataGridView()
		{
			List<TimesheetRecord> allRecords = m_timesheets.FindAll().OrderByDescending(t => t.TaskDate).ThenByDescending(t => t.StartTime).ToList();
			TimesheetDataGridView.DataSource = allRecords;
			TimesheetDataGridView.ClearSelection();

			List<SummaryLine> summaryRecords = m_timesheets.FindAll().GroupBy(t => new { t.Client, t.TaskDate.ToDateTime })
				.Select(ts => new SummaryLine
				{
					Client = ts.First().Client,
					TaskDate = ts.First().TaskDate,
					Hours = ts.Sum(t => (t.EndTime.ToDateTime()-t.StartTime.ToDateTime()).TotalHours)
				}).OrderBy(sl => sl.TaskDate).ToList();
			SummaryDataGridView.DataSource = summaryRecords;
			SummaryDataGridView.ClearSelection();
		}

		private void UpdateTimer_Tick(object sender, EventArgs e)
		{
			if (!EndTimeDateTimePicker.Focused && DateTime.Now > EndTimeDateTimePicker.Value && DateTime.Now.Minute % 5 > 1)
			{
				int minuteRoundedUp = (int)(Math.Ceiling(DateTime.Now.Minute / 5D) * 5);
				if (minuteRoundedUp >= 60)
				{
					EndTimeDateTimePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour + 1, 0, 0);
				}
				else
				{
					EndTimeDateTimePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, minuteRoundedUp, 0);
				}
			}
		}

		private void TimesheetDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			int ID = int.Parse(TimesheetDataGridView.Rows[e.RowIndex].Cells["IDColumn"].Value.ToString());

			TimesheetRecord iTimesheetRecord = m_timesheets.FindById(ID);

			switch(TimesheetDataGridView.Columns[e.ColumnIndex].Name)
			{
				case "ClientColumn":
					iTimesheetRecord.Client = TimesheetDataGridView.Rows[e.RowIndex].Cells["ClientColumn"].Value.ToString();
					break;
				case "ProjectColumn":
					iTimesheetRecord.Project = TimesheetDataGridView.Rows[e.RowIndex].Cells["ProjectColumn"].Value.ToString();
					break;
				case "DateColumn":
					iTimesheetRecord.TaskDate.FromString(TimesheetDataGridView.Rows[e.RowIndex].Cells["DateColumn"].Value.ToString());
					break;
				case "TaskColumn":
					iTimesheetRecord.TaskTitle = TimesheetDataGridView.Rows[e.RowIndex].Cells["TaskColumn"].Value.ToString();
					break;
				case "StartTimeColumn":
					iTimesheetRecord.StartTime.FromString(TimesheetDataGridView.Rows[e.RowIndex].Cells["StartTimeColumn"].Value.ToString());
					break;
				case "EndTimeColumn":
					iTimesheetRecord.EndTime.FromString(TimesheetDataGridView.Rows[e.RowIndex].Cells["EndTimeColumn"].Value.ToString());
					break;
			}
			m_timesheets.Update(iTimesheetRecord);
		}
	}
}
