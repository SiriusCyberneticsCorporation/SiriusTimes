﻿namespace SiriusTimes
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
			this.label5 = new System.Windows.Forms.Label();
			this.ClientComboBox = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.ProjectComboBox = new System.Windows.Forms.ComboBox();
			this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
			this.SummaryDataGridView = new System.Windows.Forms.DataGridView();
			this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ClientColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TaskColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StartTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.EndTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ClientSummaryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DateSummaryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.HoursSummaryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.TimesheetDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SummaryDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// TaskDateDateTimePicker
			// 
			this.TaskDateDateTimePicker.CustomFormat = "ddd dd MMM yyyy";
			this.TaskDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.TaskDateDateTimePicker.Location = new System.Drawing.Point(66, 61);
			this.TaskDateDateTimePicker.Name = "TaskDateDateTimePicker";
			this.TaskDateDateTimePicker.Size = new System.Drawing.Size(170, 22);
			this.TaskDateDateTimePicker.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Date";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(242, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Task";
			// 
			// TaskTitleTextBox
			// 
			this.TaskTitleTextBox.Location = new System.Drawing.Point(287, 61);
			this.TaskTitleTextBox.Name = "TaskTitleTextBox";
			this.TaskTitleTextBox.Size = new System.Drawing.Size(201, 22);
			this.TaskTitleTextBox.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(494, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Start";
			// 
			// StartTimeDateTimePicker
			// 
			this.StartTimeDateTimePicker.CustomFormat = "HH:mm";
			this.StartTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.StartTimeDateTimePicker.Location = new System.Drawing.Point(538, 61);
			this.StartTimeDateTimePicker.Name = "StartTimeDateTimePicker";
			this.StartTimeDateTimePicker.ShowUpDown = true;
			this.StartTimeDateTimePicker.Size = new System.Drawing.Size(65, 22);
			this.StartTimeDateTimePicker.TabIndex = 5;
			// 
			// EndTimeDateTimePicker
			// 
			this.EndTimeDateTimePicker.CustomFormat = "HH:mm";
			this.EndTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.EndTimeDateTimePicker.Location = new System.Drawing.Point(652, 61);
			this.EndTimeDateTimePicker.Name = "EndTimeDateTimePicker";
			this.EndTimeDateTimePicker.ShowUpDown = true;
			this.EndTimeDateTimePicker.Size = new System.Drawing.Size(65, 22);
			this.EndTimeDateTimePicker.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(613, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(33, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "End";
			// 
			// TaskAddButton
			// 
			this.TaskAddButton.Location = new System.Drawing.Point(736, 59);
			this.TaskAddButton.Name = "TaskAddButton";
			this.TaskAddButton.Size = new System.Drawing.Size(75, 28);
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
			this.TimesheetDataGridView.Location = new System.Drawing.Point(12, 112);
			this.TimesheetDataGridView.MultiSelect = false;
			this.TimesheetDataGridView.Name = "TimesheetDataGridView";
			this.TimesheetDataGridView.RowHeadersVisible = false;
			this.TimesheetDataGridView.RowTemplate.Height = 24;
			this.TimesheetDataGridView.Size = new System.Drawing.Size(799, 495);
			this.TimesheetDataGridView.TabIndex = 9;
			this.TimesheetDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.TimesheetDataGridView_CellEndEdit);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(356, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 17);
			this.label5.TabIndex = 10;
			this.label5.Text = "Project";
			// 
			// ClientComboBox
			// 
			this.ClientComboBox.FormattingEnabled = true;
			this.ClientComboBox.Location = new System.Drawing.Point(66, 21);
			this.ClientComboBox.Name = "ClientComboBox";
			this.ClientComboBox.Size = new System.Drawing.Size(284, 24);
			this.ClientComboBox.TabIndex = 12;
			this.ClientComboBox.SelectedIndexChanged += new System.EventHandler(this.ClientComboBox_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(17, 25);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(43, 17);
			this.label6.TabIndex = 13;
			this.label6.Text = "Client";
			// 
			// ProjectComboBox
			// 
			this.ProjectComboBox.FormattingEnabled = true;
			this.ProjectComboBox.Location = new System.Drawing.Point(414, 21);
			this.ProjectComboBox.Name = "ProjectComboBox";
			this.ProjectComboBox.Size = new System.Drawing.Size(303, 24);
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
			this.SummaryDataGridView.Location = new System.Drawing.Point(817, 112);
			this.SummaryDataGridView.Name = "SummaryDataGridView";
			this.SummaryDataGridView.RowHeadersVisible = false;
			this.SummaryDataGridView.RowTemplate.Height = 24;
			this.SummaryDataGridView.Size = new System.Drawing.Size(350, 495);
			this.SummaryDataGridView.TabIndex = 15;
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
			dataGridViewCellStyle1.Format = "ddd dd MMM yyyy";
			this.DateColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.DateColumn.HeaderText = "Date";
			this.DateColumn.Name = "DateColumn";
			this.DateColumn.Width = 70;
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
			dataGridViewCellStyle4.Format = "ddd dd MMM yyyy";
			this.DateSummaryColumn.DefaultCellStyle = dataGridViewCellStyle4;
			this.DateSummaryColumn.HeaderText = "Date";
			this.DateSummaryColumn.Name = "DateSummaryColumn";
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
			// SiriusTimesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1179, 619);
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
			this.Name = "SiriusTimesForm";
			this.Text = "Sirius Times";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SiriusTimesForm_FormClosing);
			this.Load += new System.EventHandler(this.SiriusTimesForm_Load);
			this.Shown += new System.EventHandler(this.SiriusTimesForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.TimesheetDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SummaryDataGridView)).EndInit();
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
		private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClientColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ProjectColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn TaskColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn StartTimeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn EndTimeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClientSummaryColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn DateSummaryColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn HoursSummaryColumn;
	}
}

