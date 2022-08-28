namespace Network_Tool
{
	partial class UiForm
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.TestConnectionButton = new System.Windows.Forms.Button();
			this.Address = new System.Windows.Forms.TextBox();
			this.TargetLabel = new System.Windows.Forms.Label();
			this.IntervalLabel = new System.Windows.Forms.Label();
			this.Interval = new System.Windows.Forms.TextBox();
			this.ChangeParametersButton = new System.Windows.Forms.Button();
			this.TestStatusLabel = new System.Windows.Forms.Label();
			this.ConnStat = new System.Windows.Forms.Label();
			this.StartTestButton = new System.Windows.Forms.Button();
			this.HaltButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.SyncToGraphButton = new System.Windows.Forms.Button();
			this.GraphAddress = new System.Windows.Forms.TextBox();
			this.NetworkInfoChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.StatusLabel = new System.Windows.Forms.Label();
			this.TestStat = new System.Windows.Forms.Label();
			this.TRACETEXT = new System.Windows.Forms.DataGridView();
			this.PastData = new System.Windows.Forms.DataGridView();
			this.QuerySQLDataButton = new System.Windows.Forms.Button();
			this.PastTime = new System.Windows.Forms.TextBox();
			this.PastDate = new System.Windows.Forms.TextBox();
			this.PastAdress = new System.Windows.Forms.TextBox();
			this.PastChartTargetLabel = new System.Windows.Forms.Label();
			this.PastChartDateLabel = new System.Windows.Forms.Label();
			this.PastChartTimeLabel = new System.Windows.Forms.Label();
			this.ClearGraphButton = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.PastCodeLabel = new System.Windows.Forms.Label();
			this.PastCode = new System.Windows.Forms.TextBox();
			this.PastChartCodeLabel = new System.Windows.Forms.Label();
			this.CheckPloss = new System.Windows.Forms.CheckBox();
			this.HideFinalLat = new System.Windows.Forms.CheckBox();
			this.HideMinimum = new System.Windows.Forms.CheckBox();
			this.HideMaximum = new System.Windows.Forms.CheckBox();
			this.HideAverage = new System.Windows.Forms.CheckBox();
			this.HideJitter = new System.Windows.Forms.CheckBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.NetworkInfoChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TRACETEXT)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PastData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// TestConnectionButton
			// 
			this.TestConnectionButton.Location = new System.Drawing.Point(286, 18);
			this.TestConnectionButton.Name = "TestConnectionButton";
			this.TestConnectionButton.Size = new System.Drawing.Size(123, 20);
			this.TestConnectionButton.TabIndex = 0;
			this.TestConnectionButton.Text = "Test Connection";
			this.TestConnectionButton.UseVisualStyleBackColor = true;
			this.TestConnectionButton.Click += new System.EventHandler(this.TestConn_Click);
			// 
			// Address
			// 
			this.Address.Location = new System.Drawing.Point(157, 18);
			this.Address.Name = "Address";
			this.Address.Size = new System.Drawing.Size(100, 20);
			this.Address.TabIndex = 1;
			// 
			// TargetLabel
			// 
			this.TargetLabel.AutoSize = true;
			this.TargetLabel.Location = new System.Drawing.Point(13, 21);
			this.TargetLabel.Name = "TargetLabel";
			this.TargetLabel.Size = new System.Drawing.Size(107, 13);
			this.TargetLabel.TabIndex = 2;
			this.TargetLabel.Text = "Enter Target Address";
			// 
			// IntervalLabel
			// 
			this.IntervalLabel.AutoSize = true;
			this.IntervalLabel.Location = new System.Drawing.Point(13, 56);
			this.IntervalLabel.Name = "IntervalLabel";
			this.IntervalLabel.Size = new System.Drawing.Size(128, 13);
			this.IntervalLabel.TabIndex = 3;
			this.IntervalLabel.Text = "Enter Desired Interval(ms)";
			this.IntervalLabel.Click += new System.EventHandler(this.label2_Click);
			// 
			// Interval
			// 
			this.Interval.Location = new System.Drawing.Point(157, 49);
			this.Interval.Name = "Interval";
			this.Interval.Size = new System.Drawing.Size(100, 20);
			this.Interval.TabIndex = 4;
			// 
			// ChangeParametersButton
			// 
			this.ChangeParametersButton.Location = new System.Drawing.Point(286, 48);
			this.ChangeParametersButton.Name = "ChangeParametersButton";
			this.ChangeParametersButton.Size = new System.Drawing.Size(123, 21);
			this.ChangeParametersButton.TabIndex = 5;
			this.ChangeParametersButton.Text = "Change Paramaters";
			this.ChangeParametersButton.UseVisualStyleBackColor = true;
			this.ChangeParametersButton.Click += new System.EventHandler(this.Change_Click);
			// 
			// TestStatusLabel
			// 
			this.TestStatusLabel.AutoSize = true;
			this.TestStatusLabel.Location = new System.Drawing.Point(434, 24);
			this.TestStatusLabel.Name = "TestStatusLabel";
			this.TestStatusLabel.Size = new System.Drawing.Size(40, 13);
			this.TestStatusLabel.TabIndex = 6;
			this.TestStatusLabel.Text = "Status:";
			// 
			// ConnStat
			// 
			this.ConnStat.AutoSize = true;
			this.ConnStat.Location = new System.Drawing.Point(479, 24);
			this.ConnStat.Name = "ConnStat";
			this.ConnStat.Size = new System.Drawing.Size(52, 13);
			this.ConnStat.TabIndex = 7;
			this.ConnStat.Text = "Waiting...";
			// 
			// StartTestButton
			// 
			this.StartTestButton.Location = new System.Drawing.Point(11, 80);
			this.StartTestButton.Name = "StartTestButton";
			this.StartTestButton.Size = new System.Drawing.Size(124, 51);
			this.StartTestButton.TabIndex = 8;
			this.StartTestButton.Text = "Start Test";
			this.StartTestButton.UseVisualStyleBackColor = true;
			this.StartTestButton.Click += new System.EventHandler(this.Start_Click);
			// 
			// HaltButton
			// 
			this.HaltButton.Location = new System.Drawing.Point(141, 80);
			this.HaltButton.Name = "HaltButton";
			this.HaltButton.Size = new System.Drawing.Size(124, 51);
			this.HaltButton.TabIndex = 9;
			this.HaltButton.Text = "Halt Test";
			this.HaltButton.UseVisualStyleBackColor = true;
			this.HaltButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 592);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 18);
			this.label4.TabIndex = 10;
			this.label4.Text = "Graph Data";
			// 
			// SyncToGraphButton
			// 
			this.SyncToGraphButton.Location = new System.Drawing.Point(764, 63);
			this.SyncToGraphButton.Margin = new System.Windows.Forms.Padding(2);
			this.SyncToGraphButton.Name = "SyncToGraphButton";
			this.SyncToGraphButton.Size = new System.Drawing.Size(124, 40);
			this.SyncToGraphButton.TabIndex = 12;
			this.SyncToGraphButton.Text = "Sync To Graph";
			this.SyncToGraphButton.UseVisualStyleBackColor = true;
			this.SyncToGraphButton.Click += new System.EventHandler(this.Sync_Click);
			// 
			// GraphAddress
			// 
			this.GraphAddress.Location = new System.Drawing.Point(860, 38);
			this.GraphAddress.Name = "GraphAddress";
			this.GraphAddress.Size = new System.Drawing.Size(157, 20);
			this.GraphAddress.TabIndex = 13;
			// 
			// NetworkInfoChart
			// 
			chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
			chartArea1.AxisX.IsLabelAutoFit = false;
			chartArea1.AxisX.LabelAutoFitMaxFontSize = 16;
			chartArea1.AxisX.LabelAutoFitMinFontSize = 5;
			chartArea1.AxisX.Title = "IP Address";
			chartArea1.Name = "ChartArea1";
			this.NetworkInfoChart.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.NetworkInfoChart.Legends.Add(legend1);
			this.NetworkInfoChart.Location = new System.Drawing.Point(11, 137);
			this.NetworkInfoChart.Margin = new System.Windows.Forms.Padding(2);
			this.NetworkInfoChart.Name = "NetworkInfoChart";
			series1.ChartArea = "ChartArea1";
			series1.Color = System.Drawing.Color.RoyalBlue;
			series1.Legend = "Legend1";
			series1.Name = "Packet loss";
			series1.YValuesPerPoint = 10;
			series2.BorderWidth = 5;
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			series2.Color = System.Drawing.Color.Purple;
			series2.LabelAngle = 45;
			series2.Legend = "Legend1";
			series2.Name = "Latency(ms)";
			series2.YValuesPerPoint = 10;
			series3.BorderWidth = 3;
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series3.Color = System.Drawing.Color.Fuchsia;
			series3.Legend = "Legend1";
			series3.Name = "Average Latency(ms)";
			series3.YValuesPerPoint = 10;
			series4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
			series4.BorderWidth = 3;
			series4.ChartArea = "ChartArea1";
			series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series4.Color = System.Drawing.Color.Lime;
			series4.Legend = "Legend1";
			series4.Name = "Min Latency(ms)";
			series4.YValuesPerPoint = 10;
			series5.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
			series5.BorderWidth = 3;
			series5.ChartArea = "ChartArea1";
			series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series5.Color = System.Drawing.Color.Red;
			series5.Legend = "Legend1";
			series5.Name = "Max Latency(ms)";
			series5.YValuesPerPoint = 10;
			series6.BorderWidth = 4;
			series6.ChartArea = "ChartArea1";
			series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series6.Color = System.Drawing.Color.Gold;
			series6.Legend = "Legend1";
			series6.Name = "Jitter";
			series6.YValuesPerPoint = 2;
			this.NetworkInfoChart.Series.Add(series1);
			this.NetworkInfoChart.Series.Add(series2);
			this.NetworkInfoChart.Series.Add(series3);
			this.NetworkInfoChart.Series.Add(series4);
			this.NetworkInfoChart.Series.Add(series5);
			this.NetworkInfoChart.Series.Add(series6);
			this.NetworkInfoChart.Size = new System.Drawing.Size(1423, 453);
			this.NetworkInfoChart.TabIndex = 19;
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = true;
			this.StatusLabel.Location = new System.Drawing.Point(280, 98);
			this.StatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(40, 13);
			this.StatusLabel.TabIndex = 20;
			this.StatusLabel.Text = "Status:";
			this.StatusLabel.Click += new System.EventHandler(this.label7_Click_1);
			// 
			// TestStat
			// 
			this.TestStat.AutoSize = true;
			this.TestStat.Location = new System.Drawing.Point(320, 98);
			this.TestStat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.TestStat.Name = "TestStat";
			this.TestStat.Size = new System.Drawing.Size(62, 13);
			this.TestStat.TabIndex = 21;
			this.TestStat.Text = "Not running";
			// 
			// TRACETEXT
			// 
			this.TRACETEXT.AllowUserToAddRows = false;
			this.TRACETEXT.AllowUserToDeleteRows = false;
			this.TRACETEXT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.TRACETEXT.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.TRACETEXT.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.TRACETEXT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.TRACETEXT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.TRACETEXT.DefaultCellStyle = dataGridViewCellStyle2;
			this.TRACETEXT.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.TRACETEXT.Location = new System.Drawing.Point(12, 611);
			this.TRACETEXT.Margin = new System.Windows.Forms.Padding(2);
			this.TRACETEXT.Name = "TRACETEXT";
			this.TRACETEXT.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.TRACETEXT.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.TRACETEXT.RowTemplate.Height = 24;
			this.TRACETEXT.Size = new System.Drawing.Size(843, 188);
			this.TRACETEXT.TabIndex = 24;
			// 
			// PastData
			// 
			this.PastData.AllowUserToAddRows = false;
			this.PastData.AllowUserToDeleteRows = false;
			this.PastData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.PastData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.PastData.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.PastData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.PastData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.PastData.DefaultCellStyle = dataGridViewCellStyle5;
			this.PastData.GridColor = System.Drawing.SystemColors.ActiveCaption;
			this.PastData.Location = new System.Drawing.Point(992, 611);
			this.PastData.Margin = new System.Windows.Forms.Padding(2);
			this.PastData.Name = "PastData";
			this.PastData.ReadOnly = true;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.PastData.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.PastData.RowTemplate.Height = 24;
			this.PastData.Size = new System.Drawing.Size(380, 188);
			this.PastData.TabIndex = 25;
			// 
			// QuerySQLDataButton
			// 
			this.QuerySQLDataButton.Location = new System.Drawing.Point(926, 760);
			this.QuerySQLDataButton.Margin = new System.Windows.Forms.Padding(2);
			this.QuerySQLDataButton.Name = "QuerySQLDataButton";
			this.QuerySQLDataButton.Size = new System.Drawing.Size(62, 38);
			this.QuerySQLDataButton.TabIndex = 27;
			this.QuerySQLDataButton.Text = "Query";
			this.QuerySQLDataButton.UseVisualStyleBackColor = true;
			this.QuerySQLDataButton.Click += new System.EventHandler(this.PastQuery_Click);
			// 
			// PastTime
			// 
			this.PastTime.Location = new System.Drawing.Point(913, 703);
			this.PastTime.Margin = new System.Windows.Forms.Padding(2);
			this.PastTime.Name = "PastTime";
			this.PastTime.Size = new System.Drawing.Size(76, 20);
			this.PastTime.TabIndex = 28;
			// 
			// PastDate
			// 
			this.PastDate.Location = new System.Drawing.Point(913, 680);
			this.PastDate.Margin = new System.Windows.Forms.Padding(2);
			this.PastDate.Name = "PastDate";
			this.PastDate.Size = new System.Drawing.Size(76, 20);
			this.PastDate.TabIndex = 29;
			// 
			// PastAdress
			// 
			this.PastAdress.Location = new System.Drawing.Point(913, 657);
			this.PastAdress.Margin = new System.Windows.Forms.Padding(2);
			this.PastAdress.Name = "PastAdress";
			this.PastAdress.Size = new System.Drawing.Size(76, 20);
			this.PastAdress.TabIndex = 30;
			// 
			// PastChartTargetLabel
			// 
			this.PastChartTargetLabel.AutoSize = true;
			this.PastChartTargetLabel.Location = new System.Drawing.Point(874, 660);
			this.PastChartTargetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.PastChartTargetLabel.Name = "PastChartTargetLabel";
			this.PastChartTargetLabel.Size = new System.Drawing.Size(39, 13);
			this.PastChartTargetLabel.TabIndex = 31;
			this.PastChartTargetLabel.Text = "Adress";
			// 
			// PastChartDateLabel
			// 
			this.PastChartDateLabel.AutoSize = true;
			this.PastChartDateLabel.Location = new System.Drawing.Point(880, 684);
			this.PastChartDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.PastChartDateLabel.Name = "PastChartDateLabel";
			this.PastChartDateLabel.Size = new System.Drawing.Size(30, 13);
			this.PastChartDateLabel.TabIndex = 32;
			this.PastChartDateLabel.Text = "Date";
			// 
			// PastChartTimeLabel
			// 
			this.PastChartTimeLabel.AutoSize = true;
			this.PastChartTimeLabel.Location = new System.Drawing.Point(879, 705);
			this.PastChartTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.PastChartTimeLabel.Name = "PastChartTimeLabel";
			this.PastChartTimeLabel.Size = new System.Drawing.Size(30, 13);
			this.PastChartTimeLabel.TabIndex = 33;
			this.PastChartTimeLabel.Text = "Time";
			// 
			// ClearGraphButton
			// 
			this.ClearGraphButton.Location = new System.Drawing.Point(892, 63);
			this.ClearGraphButton.Margin = new System.Windows.Forms.Padding(2);
			this.ClearGraphButton.Name = "ClearGraphButton";
			this.ClearGraphButton.Size = new System.Drawing.Size(125, 40);
			this.ClearGraphButton.TabIndex = 34;
			this.ClearGraphButton.Text = "Clear Graph";
			this.ClearGraphButton.UseVisualStyleBackColor = true;
			this.ClearGraphButton.Click += new System.EventHandler(this.Cleandata_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(902, 611);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(82, 18);
			this.label11.TabIndex = 35;
			this.label11.Text = "Past Data";
			// 
			// PastCodeLabel
			// 
			this.PastCodeLabel.Location = new System.Drawing.Point(0, 0);
			this.PastCodeLabel.Name = "PastCodeLabel";
			this.PastCodeLabel.Size = new System.Drawing.Size(100, 23);
			this.PastCodeLabel.TabIndex = 58;
			// 
			// PastCode
			// 
			this.PastCode.Location = new System.Drawing.Point(913, 726);
			this.PastCode.Margin = new System.Windows.Forms.Padding(2);
			this.PastCode.Name = "PastCode";
			this.PastCode.Size = new System.Drawing.Size(76, 20);
			this.PastCode.TabIndex = 38;
			// 
			// PastChartCodeLabel
			// 
			this.PastChartCodeLabel.AutoSize = true;
			this.PastChartCodeLabel.Location = new System.Drawing.Point(880, 728);
			this.PastChartCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.PastChartCodeLabel.Name = "PastChartCodeLabel";
			this.PastChartCodeLabel.Size = new System.Drawing.Size(32, 13);
			this.PastChartCodeLabel.TabIndex = 39;
			this.PastChartCodeLabel.Text = "Code";
			// 
			// CheckPloss
			// 
			this.CheckPloss.AutoSize = true;
			this.CheckPloss.Location = new System.Drawing.Point(1288, 458);
			this.CheckPloss.Margin = new System.Windows.Forms.Padding(2);
			this.CheckPloss.Name = "CheckPloss";
			this.CheckPloss.Size = new System.Drawing.Size(110, 17);
			this.CheckPloss.TabIndex = 52;
			this.CheckPloss.Text = "Hide Packet Loss";
			this.CheckPloss.UseVisualStyleBackColor = true;
			this.CheckPloss.CheckedChanged += new System.EventHandler(this.CheckPloss_CheckedChanged);
			// 
			// HideFinalLat
			// 
			this.HideFinalLat.AutoSize = true;
			this.HideFinalLat.Location = new System.Drawing.Point(1288, 480);
			this.HideFinalLat.Margin = new System.Windows.Forms.Padding(2);
			this.HideFinalLat.Name = "HideFinalLat";
			this.HideFinalLat.Size = new System.Drawing.Size(114, 17);
			this.HideFinalLat.TabIndex = 53;
			this.HideFinalLat.Text = "Hide Final Latency";
			this.HideFinalLat.UseVisualStyleBackColor = true;
			this.HideFinalLat.CheckedChanged += new System.EventHandler(this.HideFinalLat_CheckedChanged);
			// 
			// HideMinimum
			// 
			this.HideMinimum.AutoSize = true;
			this.HideMinimum.Location = new System.Drawing.Point(1288, 502);
			this.HideMinimum.Margin = new System.Windows.Forms.Padding(2);
			this.HideMinimum.Name = "HideMinimum";
			this.HideMinimum.Size = new System.Drawing.Size(133, 17);
			this.HideMinimum.TabIndex = 54;
			this.HideMinimum.Text = "Hide Minimum Latency";
			this.HideMinimum.UseVisualStyleBackColor = true;
			this.HideMinimum.CheckedChanged += new System.EventHandler(this.HideMinimum_CheckedChanged);
			// 
			// HideMaximum
			// 
			this.HideMaximum.AutoSize = true;
			this.HideMaximum.Location = new System.Drawing.Point(1288, 524);
			this.HideMaximum.Margin = new System.Windows.Forms.Padding(2);
			this.HideMaximum.Name = "HideMaximum";
			this.HideMaximum.Size = new System.Drawing.Size(142, 17);
			this.HideMaximum.TabIndex = 55;
			this.HideMaximum.Text = "Hide Maximum Lantency";
			this.HideMaximum.UseVisualStyleBackColor = true;
			this.HideMaximum.CheckedChanged += new System.EventHandler(this.HideMaximum_CheckedChanged);
			// 
			// HideAverage
			// 
			this.HideAverage.AutoSize = true;
			this.HideAverage.Location = new System.Drawing.Point(1288, 546);
			this.HideAverage.Margin = new System.Windows.Forms.Padding(2);
			this.HideAverage.Name = "HideAverage";
			this.HideAverage.Size = new System.Drawing.Size(132, 17);
			this.HideAverage.TabIndex = 56;
			this.HideAverage.Text = "Hide Average Latency";
			this.HideAverage.UseVisualStyleBackColor = true;
			this.HideAverage.CheckedChanged += new System.EventHandler(this.HideAverage_CheckedChanged);
			// 
			// HideJitter
			// 
			this.HideJitter.AutoSize = true;
			this.HideJitter.Location = new System.Drawing.Point(1288, 568);
			this.HideJitter.Margin = new System.Windows.Forms.Padding(2);
			this.HideJitter.Name = "HideJitter";
			this.HideJitter.Size = new System.Drawing.Size(73, 17);
			this.HideJitter.TabIndex = 57;
			this.HideJitter.Text = "Hide Jitter";
			this.HideJitter.UseVisualStyleBackColor = true;
			this.HideJitter.CheckedChanged += new System.EventHandler(this.HideJitter_CheckedChanged);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(1283, 453);
			this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(151, 137);
			this.pictureBox2.TabIndex = 59;
			this.pictureBox2.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(748, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 13);
			this.label1.TabIndex = 60;
			this.label1.Text = "Enter Target Address";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// UiForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(1443, 857);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.HideJitter);
			this.Controls.Add(this.HideAverage);
			this.Controls.Add(this.HideMaximum);
			this.Controls.Add(this.HideMinimum);
			this.Controls.Add(this.HideFinalLat);
			this.Controls.Add(this.CheckPloss);
			this.Controls.Add(this.PastChartCodeLabel);
			this.Controls.Add(this.PastCode);
			this.Controls.Add(this.PastCodeLabel);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.ClearGraphButton);
			this.Controls.Add(this.PastChartTimeLabel);
			this.Controls.Add(this.PastChartDateLabel);
			this.Controls.Add(this.PastChartTargetLabel);
			this.Controls.Add(this.PastAdress);
			this.Controls.Add(this.PastDate);
			this.Controls.Add(this.PastTime);
			this.Controls.Add(this.QuerySQLDataButton);
			this.Controls.Add(this.PastData);
			this.Controls.Add(this.TRACETEXT);
			this.Controls.Add(this.TestStat);
			this.Controls.Add(this.StatusLabel);
			this.Controls.Add(this.GraphAddress);
			this.Controls.Add(this.SyncToGraphButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.HaltButton);
			this.Controls.Add(this.StartTestButton);
			this.Controls.Add(this.ConnStat);
			this.Controls.Add(this.TestStatusLabel);
			this.Controls.Add(this.ChangeParametersButton);
			this.Controls.Add(this.Interval);
			this.Controls.Add(this.IntervalLabel);
			this.Controls.Add(this.TargetLabel);
			this.Controls.Add(this.Address);
			this.Controls.Add(this.TestConnectionButton);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.NetworkInfoChart);
			this.Name = "UiForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Networking Tool";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.NetworkInfoChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TRACETEXT)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PastData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.Label label1;

		#endregion

		private System.Windows.Forms.Button TestConnectionButton;
		private System.Windows.Forms.TextBox Address;
		private System.Windows.Forms.Label TargetLabel;
		private System.Windows.Forms.Label IntervalLabel;
		private System.Windows.Forms.TextBox Interval;
		private System.Windows.Forms.Button ChangeParametersButton;
		private System.Windows.Forms.Label TestStatusLabel;
		private System.Windows.Forms.Label ConnStat;
		private System.Windows.Forms.Button StartTestButton;
		private System.Windows.Forms.Button HaltButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SyncToGraphButton;
        private System.Windows.Forms.TextBox GraphAddress;
        public System.Windows.Forms.DataVisualization.Charting.Chart NetworkInfoChart;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label TestStat;
        private System.Windows.Forms.DataGridView TRACETEXT;
        private System.Windows.Forms.DataGridView PastData;
        private System.Windows.Forms.Button QuerySQLDataButton;
        private System.Windows.Forms.TextBox PastTime;
        private System.Windows.Forms.TextBox PastDate;
        private System.Windows.Forms.TextBox PastAdress;
        private System.Windows.Forms.Label PastChartTargetLabel;
        private System.Windows.Forms.Label PastChartDateLabel;
        private System.Windows.Forms.Label PastChartTimeLabel;
        private System.Windows.Forms.Button ClearGraphButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label PastCodeLabel;
        private System.Windows.Forms.TextBox PastCode;
        private System.Windows.Forms.Label PastChartCodeLabel;
        private System.Windows.Forms.CheckBox CheckPloss;
        private System.Windows.Forms.CheckBox HideFinalLat;
        private System.Windows.Forms.CheckBox HideMinimum;
        private System.Windows.Forms.CheckBox HideMaximum;
        private System.Windows.Forms.CheckBox HideAverage;
        private System.Windows.Forms.CheckBox HideJitter;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

