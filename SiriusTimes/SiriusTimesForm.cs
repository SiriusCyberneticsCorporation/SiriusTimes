using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
			File.Copy(TIMESHEET_DATABASE, DateTime.Now.ToString("yyyy-MM-dd") + " " + TIMESHEET_DATABASE, true);

			var monthList = System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames.Select((item, index) => new
			{
				Month = item,
				Value = index + 1
			});

			MonthComboBox.DataSource = monthList.ToList();
			MonthComboBox.DisplayMember = "Month";
			MonthComboBox.ValueMember = "Value";

			YearComboBox.DataSource = new List<int>() { 2018, 2019, 2020, 2021, 2022, 2023, 2024 };

			m_timesheetDatabase = new LiteDatabase(TIMESHEET_DATABASE);
			m_timesheets = m_timesheetDatabase.GetCollection<TimesheetRecord>();
			//m_timesheets.EnsureIndex(t => t.FolderName);
		}

		private void SiriusTimesForm_Shown(object sender, EventArgs e)
		{
			List<TimesheetRecord> allRecords = m_timesheets.FindAll().ToList();
			List<string> clients = allRecords.Select(t => t.Client).Distinct().ToList();

			ClientComboBox.DataSource = clients;
			if(Properties.Settings.Default.LastClient.Length > 0)
			{
				ClientComboBox.SelectedItem = Properties.Settings.Default.LastClient;
			}

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

			MonthComboBox.SelectedValue = DateTime.Now.Month;
			YearComboBox.SelectedItem = DateTime.Now.Year;
			CSVLocationTextBox.Text = Properties.Settings.Default.CVSLocation;

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
				PO = POComboBox.Text,
				Project = ProjectComboBox.Text,
				TaskDate = TaskDateDateTimePicker.Value,
				TaskTitle = TaskTitleTextBox.Text,
				StartTime = StartTimeDateTimePicker.Value,
				EndTime = EndTimeDateTimePicker.Value
			};
			m_timesheets.Insert(iTimesheetRecord);

			Properties.Settings.Default.LastClient = ClientComboBox.Text;
			Properties.Settings.Default.LastProject = ProjectComboBox.Text;
			Properties.Settings.Default.LastPO = POComboBox.Text;
			Properties.Settings.Default.Save();

			StartTimeDateTimePicker.Value = EndTimeDateTimePicker.Value;

			RefreshTimesheetDataGridView();
		}

		private void ClientComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<TimesheetRecord> clientRecords = m_timesheets.Find(t => t.Client == ClientComboBox.Text).ToList();
			List<string> pos = clientRecords.Select(t => t.PO).Distinct().ToList();
			List<string> projects = clientRecords.Select(t => t.Project).Distinct().ToList();

			POComboBox.DataSource = pos;

			if (Properties.Settings.Default.LastPO.Length > 0)
			{
				POComboBox.SelectedItem = Properties.Settings.Default.LastPO;
			}

			ProjectComboBox.DataSource = projects;

			if (Properties.Settings.Default.LastProject.Length > 0)
			{
				ProjectComboBox.SelectedItem = Properties.Settings.Default.LastProject;
			}
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
			int month = DateTime.Today.Month;
			int year = DateTime.Today.Year;

			if (MonthComboBox.SelectedValue is int)
			{
				month = (int)(MonthComboBox.SelectedValue);
			}

			if (YearComboBox.SelectedValue is int)
			{
				year = (int)(YearComboBox.SelectedValue);
			}

			if (m_timesheets != null)
			{
				List<TimesheetRecord> allRecords = m_timesheets.FindAll().OrderByDescending(t => t.TaskDate).ThenByDescending(t => t.StartTime).ToList();
				TimesheetDataGridView.DataSource = allRecords;
				TimesheetDataGridView.ClearSelection();

				List<SummaryLine> summaryRecords = m_timesheets.Find(ts => ts.TaskDate.Month == month && ts.TaskDate.Year == year)
					.GroupBy(t => new { t.Client, t.TaskDate.ToDateTime })
					.Select(ts => new SummaryLine
					{
						Client = ts.First().Client,
						TaskDate = ts.First().TaskDate,
						Hours = ts.Sum(t => (t.EndTime.ToDateTime - t.StartTime.ToDateTime).TotalHours)
					}).OrderBy(sl => sl.TaskDate).ToList();
				SummaryDataGridView.DataSource = summaryRecords;
				SummaryDataGridView.ClearSelection();
			}
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
				case "POColumn":
					iTimesheetRecord.PO = TimesheetDataGridView.Rows[e.RowIndex].Cells["POColumn"].Value.ToString();
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

		private void CSVLocationTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			FolderBrowserDialog iFolderBrowserDialog = new FolderBrowserDialog()
			{
				Description = "CSV Location",
				RootFolder = Environment.SpecialFolder.MyComputer,
				SelectedPath = Properties.Settings.Default.CVSLocation
			};

			if(iFolderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				Properties.Settings.Default.CVSLocation = iFolderBrowserDialog.SelectedPath;
				Properties.Settings.Default.Save();
			}
		}

		private IEnumerable<TimesheetRecord> SelectRecords()
		{
			int month = (int)(MonthComboBox.SelectedValue);
			int year = (int)(YearComboBox.SelectedValue);
			IEnumerable<TimesheetRecord> records = null;

			if (month == 13)
			{
				if (CalendarYearRadioButton.Checked)
				{
					records = m_timesheets.Find(ts => ts.TaskDate.Year == year && ts.Client == ClientComboBox.Text).OrderBy(ts => ts.TaskDate);
				}
				else
				{
					records = m_timesheets.Find(ts => ts.Client == ClientComboBox.Text &&
															(ts.TaskDate.Month < 7 && ts.TaskDate.Year == year ||
															 ts.TaskDate.Month > 6 && ts.TaskDate.Year == year - 1)).OrderBy(ts => ts.TaskDate);
				}
			}
			else
			{
				if (CalendarYearRadioButton.Checked)
				{
					records = m_timesheets.Find(ts => ts.TaskDate.Month == month && ts.TaskDate.Year == year &&
															ts.Client == ClientComboBox.Text).OrderBy(ts => ts.TaskDate);
				}
				else
				{
					records = m_timesheets.Find(ts => ts.TaskDate.Month == month && ts.TaskDate.Year == year &&
															ts.Client == ClientComboBox.Text).OrderBy(ts => ts.TaskDate);
				}
			}

			return records;
		}

		private void CSVForClientButton_Click(object sender, EventArgs e)
		{
			IEnumerable<TimesheetRecord> timesheetRecords = SelectRecords();
			StringBuilder csvRecords = new StringBuilder();

			csvRecords.AppendLine("Date,PO,Project,Task,Start,End,Hours");

			foreach (TimesheetRecord record in timesheetRecords)
			{
				string line = record.TaskDate.ToString() + "," +
							  record.PO + "," +
							  record.Project + "," +
							  record.TaskTitle + "," +
							  record.StartTime.ToString() + "," +
							  record.EndTime.ToString() + "," +
							  (record.EndTime.ToDateTime - record.StartTime.ToDateTime).TotalHours.ToString("N2");
				csvRecords.AppendLine(line);
			}

			if (MonthComboBox.Text.Length > 1)
			{
				File.WriteAllText(Path.Combine(CSVLocationTextBox.Text, ClientComboBox.Text + " " + MonthComboBox.Text + " " + YearComboBox.Text + " Timesheet.csv"),
									csvRecords.ToString());
			}
			else
			{
				File.WriteAllText(Path.Combine(CSVLocationTextBox.Text, ClientComboBox.Text + " " + YearComboBox.Text + " Timesheet.csv"),
									csvRecords.ToString());
			}
		}

		private void XLSForClientButton_Click(object sender, EventArgs e)
		{
			string filename = string.Empty;
			IEnumerable<TimesheetRecord> timesheetRecords = SelectRecords();

			if (MonthComboBox.Text.Length > 1)
			{
				filename = Path.Combine(CSVLocationTextBox.Text, ClientComboBox.Text + " " + MonthComboBox.Text + " " + YearComboBox.Text + " Timesheet.xlsx");
			}
			else
			{
				filename = Path.Combine(CSVLocationTextBox.Text, ClientComboBox.Text + " " + YearComboBox.Text + " Timesheet.xlsx");
			}

			List<float> columnWidths = new List<float>() { 11, 10, 30, 40, 10, 10, 10 };
			ExcelExporter iExcelExporter = new ExcelExporter(filename, "Timesheet", "Timesheet", "", DateTime.Now.ToLongDateString(), true, columnWidths);

			iExcelExporter.AddRow();
			iExcelExporter.AddText("Date", 1, true, false, false, HorizontalAlignment.Center);
			iExcelExporter.AddText("PO", 1, true, false, false, HorizontalAlignment.Center);
			iExcelExporter.AddText("Project", 1, true, false, false, HorizontalAlignment.Center);
			iExcelExporter.AddText("Task", 1, true, false, false, HorizontalAlignment.Center);
			iExcelExporter.AddText("Start", 1, true, false, false, HorizontalAlignment.Center);
			iExcelExporter.AddText("End", 1, true, false, false, HorizontalAlignment.Center);
			iExcelExporter.AddText("Hours", 1, true, false, false, HorizontalAlignment.Center);

			foreach (TimesheetRecord record in timesheetRecords)
			{
				iExcelExporter.AddRow();
				iExcelExporter.AddDate(record.TaskDate.ToDateTime, 1, false, false, false, HorizontalAlignment.Right);
				iExcelExporter.AddText(record.PO, 1, false, false, false, HorizontalAlignment.Left);
				iExcelExporter.AddText(record.Project, 1, false, false, false, HorizontalAlignment.Left);
				iExcelExporter.AddText(record.TaskTitle, 1, false, false, false, HorizontalAlignment.Left);
				iExcelExporter.AddText(record.StartTime.ToString(), 1, false, false, false, HorizontalAlignment.Right);
				iExcelExporter.AddText(record.EndTime.ToString(), 1, false, false, false, HorizontalAlignment.Right);
				iExcelExporter.AddDecimal((record.EndTime.ToDateTime - record.StartTime.ToDateTime).TotalHours, 1, false, false, false, HorizontalAlignment.Right);
			}

			iExcelExporter.Finish();
		}

		private void XLSbyPOButton_Click(object sender, EventArgs e)
		{
			string filename = string.Empty;
			IEnumerable<TimesheetRecord> allTimesheetRecords = SelectRecords();

			List<string> pos = allTimesheetRecords.Select(t => t.PO).Distinct().ToList();

			foreach (string po in pos)
			{
				IEnumerable<TimesheetRecord> timesheetRecords = allTimesheetRecords.Where(t => t.PO == po);

				if (MonthComboBox.Text.Length > 1)
				{
					filename = Path.Combine(CSVLocationTextBox.Text, ClientComboBox.Text + " PO"+ po + " " + MonthComboBox.Text + " " + YearComboBox.Text + " Timesheet.xlsx");
				}
				else
				{
					filename = Path.Combine(CSVLocationTextBox.Text, ClientComboBox.Text + " PO" + po + " " + YearComboBox.Text + " Timesheet.xlsx");
				}

				List<float> columnWidths = new List<float>() { 11, 10, 30, 40, 10, 10, 10 };
				ExcelExporter iExcelExporter = new ExcelExporter(filename, "Timesheet", "Timesheet", "", DateTime.Now.ToLongDateString(), true, columnWidths);

				iExcelExporter.AddRow();
				iExcelExporter.AddText("Date", 1, true, false, false, HorizontalAlignment.Center);
				iExcelExporter.AddText("PO", 1, true, false, false, HorizontalAlignment.Center);
				iExcelExporter.AddText("Project", 1, true, false, false, HorizontalAlignment.Center);
				iExcelExporter.AddText("Task", 1, true, false, false, HorizontalAlignment.Center);
				iExcelExporter.AddText("Start", 1, true, false, false, HorizontalAlignment.Center);
				iExcelExporter.AddText("End", 1, true, false, false, HorizontalAlignment.Center);
				iExcelExporter.AddText("Hours", 1, true, false, false, HorizontalAlignment.Center);

				foreach (TimesheetRecord record in timesheetRecords)
				{
					iExcelExporter.AddRow();
					iExcelExporter.AddDate(record.TaskDate.ToDateTime, 1, false, false, false, HorizontalAlignment.Right);
					iExcelExporter.AddText(record.PO, 1, false, false, false, HorizontalAlignment.Left);
					iExcelExporter.AddText(record.Project, 1, false, false, false, HorizontalAlignment.Left);
					iExcelExporter.AddText(record.TaskTitle, 1, false, false, false, HorizontalAlignment.Left);
					iExcelExporter.AddText(record.StartTime.ToString(), 1, false, false, false, HorizontalAlignment.Right);
					iExcelExporter.AddText(record.EndTime.ToString(), 1, false, false, false, HorizontalAlignment.Right);
					iExcelExporter.AddDecimal((record.EndTime.ToDateTime - record.StartTime.ToDateTime).TotalHours, 1, false, false, false, HorizontalAlignment.Right);
				}

				iExcelExporter.Finish();
			}
		}

		private void TimesheetDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{

		}

		private void CSVMonthComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshTimesheetDataGridView();
		}

		private void YearComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshTimesheetDataGridView();
		}
    }
}
