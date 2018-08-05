namespace SiriusTimes
{
	partial class SiriusTimesForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiriusTimesForm));
			this.TaskDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TaskTitleTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.StartTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.EndTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.TaskAddButton = new System.Windows.Forms.Button();
			this.TimesheetDataGridView = new System.Windows.Forms.DataGridView();
			this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ClientColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DateColumn = new SiriusTimes.CalendarColumn();
			this.TaskColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StartTimeColumn = new SiriusTimes.TimeColumn();
			this.EndTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label5 = new System.Windows.Forms.Label();
			this.ClientComboBox = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.ProjectComboBox = new System.Windows.Forms.ComboBox();
			this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
			this.SummaryDataGridView = new System.Windows.Forms.DataGridView();
			this.ClientSummaryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DateSummaryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.HoursSummaryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calendarColumn1 = new SiriusTimes.CalendarColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CSVForClientButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.CSVLocationTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.CSVMonthComboBox = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.TimesheetDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SummaryDataGridView)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// TaskDateDateTimePicker
			// 
			this.TaskDateDateTimePicker.CustomFormat = "ddd dd MMM yyyy";
			this.TaskDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.TaskDateDateTimePicker.Location = new System.Drawing.Point(50, 50);
			this.TaskDateDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
			this.TaskDateDateTimePicker.Name = "TaskDateDateTimePicker";
			this.TaskDateDateTimePicker.Size = new System.Drawing.Size(128, 20);
			this.TaskDateDateTimePicker.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 52);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Date";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(182, 52);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Task";
			// 
			// TaskTitleTextBox
			// 
			this.TaskTitleTextBox.Location = new System.Drawing.Point(215, 50);
			this.TaskTitleTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.TaskTitleTextBox.Name = "TaskTitleTextBox";
			this.TaskTitleTextBox.Size = new System.Drawing.Size(152, 20);
			this.TaskTitleTextBox.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(370, 52);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Start";
			// 
			// StartTimeDateTimePicker
			// 
			this.StartTimeDateTimePicker.CustomFormat = "HH:mm";
			this.StartTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.StartTimeDateTimePicker.Location = new System.Drawing.Point(404, 50);
			this.StartTimeDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
			this.StartTimeDateTimePicker.Name = "StartTimeDateTimePicker";
			this.StartTimeDateTimePicker.ShowUpDown = true;
			this.StartTimeDateTimePicker.Size = new System.Drawing.Size(50, 20);
			this.StartTimeDateTimePicker.TabIndex = 5;
			// 
			// EndTimeDateTimePicker
			// 
			this.EndTimeDateTimePicker.CustomFormat = "HH:mm";
			this.EndTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.EndTimeDateTimePicker.Location = new System.Drawing.Point(489, 50);
			this.EndTimeDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
			this.EndTimeDateTimePicker.Name = "EndTimeDateTimePicker";
			this.EndTimeDateTimePicker.ShowUpDown = true;
			this.EndTimeDateTimePicker.Size = new System.Drawing.Size(50, 20);
			this.EndTimeDateTimePicker.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(460, 52);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(26, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "End";
			// 
			// TaskAddButton
			// 
			this.TaskAddButton.Location = new System.Drawing.Point(552, 48);
			this.TaskAddButton.Margin = new System.Windows.Forms.Padding(2);
			this.TaskAddButton.Name = "TaskAddButton";
			this.TaskAddButton.Size = new System.Drawing.Size(56, 23);
			this.TaskAddButton.TabIndex = 8;
			this.TaskAddButton.Text = "Add";
			this.TaskAddButton.UseVisualStyleBackColor = true;
			this.TaskAddButton.Click += new System.EventHandler(this.TaskAddButton_Click);
			// 
			// TimesheetDataGridView
			// 
			this.TimesheetDataGridView.AllowUserToAddRows = false;
			this.TimesheetDataGridView.AllowUserToDeleteRows = false;
			this.TimesheetDataGridView.AllowUserToResizeRows = false;
			this.TimesheetDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TimesheetDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.TimesheetDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.TimesheetDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.ClientColumn,
            this.ProjectColumn,
            this.DateColumn,
            this.TaskColumn,
            this.StartTimeColumn,
            this.EndTimeColumn});
			this.TimesheetDataGridView.Location = new System.Drawing.Point(9, 91);
			this.TimesheetDataGridView.Margin = new System.Windows.Forms.Padding(2);
			this.TimesheetDataGridView.MultiSelect = false;
			this.TimesheetDataGridView.Name = "TimesheetDataGridView";
			this.TimesheetDataGridView.RowHeadersVisible = false;
			this.TimesheetDataGridView.RowTemplate.Height = 24;
			this.TimesheetDataGridView.Size = new System.Drawing.Size(599, 402);
			this.TimesheetDataGridView.TabIndex = 9;
			this.TimesheetDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.TimesheetDataGridView_CellEndEdit);
			this.TimesheetDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.TimesheetDataGridView_DataError);
			// 
			// IDColumn
			// 
			this.IDColumn.DataPropertyName = "ID";
			this.IDColumn.HeaderText = "ID";
			this.IDColumn.Name = "IDColumn";
			this.IDColumn.Visible = false;
			// 
			// ClientColumn
			// 
			this.ClientColumn.DataPropertyName = "Client";
			this.ClientColumn.HeaderText = "Client";
			this.ClientColumn.Name = "ClientColumn";
			// 
			// ProjectColumn
			// 
			this.ProjectColumn.DataPropertyName = "Project";
			this.ProjectColumn.HeaderText = "Project";
			this.ProjectColumn.Name = "ProjectColumn";
			// 
			// DateColumn
			// 
			this.DateColumn.DataPropertyName = "TaskDate";
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.Format = "dd-MM-yyyy";
			this.DateColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.DateColumn.HeaderText = "Date";
			this.DateColumn.Name = "DateColumn";
			this.DateColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.DateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.DateColumn.Width = 80;
			// 
			// TaskColumn
			// 
			this.TaskColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.TaskColumn.DataPropertyName = "TaskTitle";
			this.TaskColumn.HeaderText = "Task";
			this.TaskColumn.Name = "TaskColumn";
			// 
			// StartTimeColumn
			// 
			this.StartTimeColumn.DataPropertyName = "StartTime";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.Format = "HH:mm";
			this.StartTimeColumn.DefaultCellStyle = dataGridViewCellStyle2;
			this.StartTimeColumn.HeaderText = "Start";
			this.StartTimeColumn.Name = "StartTimeColumn";
			this.StartTimeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.StartTimeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.StartTimeColumn.Width = 50;
			// 
			// EndTimeColumn
			// 
			this.EndTimeColumn.DataPropertyName = "EndTime";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.Format = "HH:mm";
			this.EndTimeColumn.DefaultCellStyle = dataGridViewCellStyle3;
			this.EndTimeColumn.HeaderText = "End";
			this.EndTimeColumn.Name = "EndTimeColumn";
			this.EndTimeColumn.Width = 50;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(267, 20);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Project";
			// 
			// ClientComboBox
			// 
			this.ClientComboBox.FormattingEnabled = true;
			this.ClientComboBox.Location = new System.Drawing.Point(50, 17);
			this.ClientComboBox.Margin = new System.Windows.Forms.Padding(2);
			this.ClientComboBox.Name = "ClientComboBox";
			this.ClientComboBox.Size = new System.Drawing.Size(214, 21);
			this.ClientComboBox.TabIndex = 12;
			this.ClientComboBox.SelectedIndexChanged += new System.EventHandler(this.ClientComboBox_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 20);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(33, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Client";
			// 
			// ProjectComboBox
			// 
			this.ProjectComboBox.FormattingEnabled = true;
			this.ProjectComboBox.Location = new System.Drawing.Point(310, 17);
			this.ProjectComboBox.Margin = new System.Windows.Forms.Padding(2);
			this.ProjectComboBox.Name = "ProjectComboBox";
			this.ProjectComboBox.Size = new System.Drawing.Size(228, 21);
			this.ProjectComboBox.TabIndex = 14;
			// 
			// UpdateTimer
			// 
			this.UpdateTimer.Enabled = true;
			this.UpdateTimer.Interval = 30000;
			this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
			// 
			// SummaryDataGridView
			// 
			this.SummaryDataGridView.AllowUserToAddRows = false;
			this.SummaryDataGridView.AllowUserToDeleteRows = false;
			this.SummaryDataGridView.AllowUserToResizeRows = false;
			this.SummaryDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SummaryDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.SummaryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.SummaryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClientSummaryColumn,
            this.DateSummaryColumn,
            this.HoursSummaryColumn});
			this.SummaryDataGridView.Location = new System.Drawing.Point(613, 91);
			this.SummaryDataGridView.Margin = new System.Windows.Forms.Padding(2);
			this.SummaryDataGridView.Name = "SummaryDataGridView";
			this.SummaryDataGridView.RowHeadersVisible = false;
			this.SummaryDataGridView.RowTemplate.Height = 24;
			this.SummaryDataGridView.Size = new System.Drawing.Size(262, 402);
			this.SummaryDataGridView.TabIndex = 15;
			// 
			// ClientSummaryColumn
			// 
			this.ClientSummaryColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ClientSummaryColumn.DataPropertyName = "Client";
			this.ClientSummaryColumn.HeaderText = "Client";
			this.ClientSummaryColumn.Name = "ClientSummaryColumn";
			// 
			// DateSummaryColumn
			// 
			this.DateSummaryColumn.DataPropertyName = "TaskDate";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.Format = "dd-MM-yyyy";
			this.DateSummaryColumn.DefaultCellStyle = dataGridViewCellStyle4;
			this.DateSummaryColumn.HeaderText = "Date";
			this.DateSummaryColumn.Name = "DateSummaryColumn";
			this.DateSummaryColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.DateSummaryColumn.Width = 70;
			// 
			// HoursSummaryColumn
			// 
			this.HoursSummaryColumn.DataPropertyName = "Hours";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N2";
			this.HoursSummaryColumn.DefaultCellStyle = dataGridViewCellStyle5;
			this.HoursSummaryColumn.HeaderText = "Hours";
			this.HoursSummaryColumn.Name = "HoursSummaryColumn";
			this.HoursSummaryColumn.Width = 50;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
			this.dataGridViewTextBoxColumn1.HeaderText = "ID";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Visible = false;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Client";
			this.dataGridViewTextBoxColumn2.HeaderText = "Client";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "Project";
			this.dataGridViewTextBoxColumn3.HeaderText = "Project";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "TaskDate";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.Format = "ddd dd MMM yyyy";
			this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewTextBoxColumn4.HeaderText = "Date";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Width = 70;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn5.DataPropertyName = "TaskTitle";
			this.dataGridViewTextBoxColumn5.HeaderText = "Task";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.DataPropertyName = "StartTime";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.Format = "HH:mm";
			this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewTextBoxColumn6.HeaderText = "Start";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.Width = 50;
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.DataPropertyName = "EndTime";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.Format = "HH:mm";
			this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewTextBoxColumn7.HeaderText = "End";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.Width = 50;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn8.DataPropertyName = "Client";
			this.dataGridViewTextBoxColumn8.HeaderText = "Client";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			// 
			// calendarColumn1
			// 
			this.calendarColumn1.DataPropertyName = "TaskDate";
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.Format = "dd-MM-yyyy";
			this.calendarColumn1.DefaultCellStyle = dataGridViewCellStyle9;
			this.calendarColumn1.HeaderText = "Date";
			this.calendarColumn1.Name = "calendarColumn1";
			this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.calendarColumn1.Width = 70;
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.DataPropertyName = "Hours";
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle10.Format = "N2";
			this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewTextBoxColumn9.HeaderText = "Hours";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.Width = 50;
			// 
			// CSVForClientButton
			// 
			this.CSVForClientButton.Location = new System.Drawing.Point(167, 44);
			this.CSVForClientButton.Name = "CSVForClientButton";
			this.CSVForClientButton.Size = new System.Drawing.Size(88, 23);
			this.CSVForClientButton.TabIndex = 16;
			this.CSVForClientButton.Text = "CSV for Client";
			this.CSVForClientButton.UseVisualStyleBackColor = true;
			this.CSVForClientButton.Click += new System.EventHandler(this.CSVForClientButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.CSVLocationTextBox);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.CSVMonthComboBox);
			this.groupBox1.Controls.Add(this.CSVForClientButton);
			this.groupBox1.Location = new System.Drawing.Point(613, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(261, 72);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Produce CSV";
			// 
			// CSVLocationTextBox
			// 
			this.CSVLocationTextBox.Location = new System.Drawing.Point(12, 16);
			this.CSVLocationTextBox.Name = "CSVLocationTextBox";
			this.CSVLocationTextBox.Size = new System.Drawing.Size(243, 20);
			this.CSVLocationTextBox.TabIndex = 19;
			this.CSVLocationTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CSVLocationTextBox_MouseDoubleClick);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(37, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "Month";
			// 
			// CSVMonthComboBox
			// 
			this.CSVMonthComboBox.FormattingEnabled = true;
			this.CSVMonthComboBox.Location = new System.Drawing.Point(52, 45);
			this.CSVMonthComboBox.Name = "CSVMonthComboBox";
			this.CSVMonthComboBox.Size = new System.Drawing.Size(109, 21);
			this.CSVMonthComboBox.TabIndex = 17;
			this.CSVMonthComboBox.SelectedIndexChanged += new System.EventHandler(this.CSVMonthComboBox_SelectedIndexChanged);
			// 
			// SiriusTimesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 503);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.SummaryDataGridView);
			this.Controls.Add(this.ProjectComboBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.ClientComboBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.TimesheetDataGridView);
			this.Controls.Add(this.TaskAddButton);
			this.Controls.Add(this.EndTimeDateTimePicker);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.StartTimeDateTimePicker);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.TaskTitleTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TaskDateDateTimePicker);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "SiriusTimesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Sirius Times";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SiriusTimesForm_FormClosing);
			this.Load += new System.EventHandler(this.SiriusTimesForm_Load);
			this.Shown += new System.EventHandler(this.SiriusTimesForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.TimesheetDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SummaryDataGridView)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker TaskDateDateTimePicker;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TaskTitleTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker StartTimeDateTimePicker;
		private System.Windows.Forms.DateTimePicker EndTimeDateTimePicker;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button TaskAddButton;
		private System.Windows.Forms.DataGridView TimesheetDataGridView;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox ClientComboBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox ProjectComboBox;
		private System.Windows.Forms.Timer UpdateTimer;
		private System.Windows.Forms.DataGridView SummaryDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private CalendarColumn calendarColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClientSummaryColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn DateSummaryColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn HoursSummaryColumn;
		private System.Windows.Forms.Button CSVForClientButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox CSVMonthComboBox;
		private System.Windows.Forms.TextBox CSVLocationTextBox;
		private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClientColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ProjectColumn;
		private CalendarColumn DateColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn TaskColumn;
		private TimeColumn StartTimeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn EndTimeColumn;
	}
}

