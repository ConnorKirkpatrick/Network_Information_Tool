namespace Network_Tool
{
	partial class Form1
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
            this.TestConn = new System.Windows.Forms.Button();
            this.Adress = new System.Windows.Forms.TextBox();
            this.TargetLabel = new System.Windows.Forms.Label();
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.Interval = new System.Windows.Forms.TextBox();
            this.Change = new System.Windows.Forms.Button();
            this.TestStatusLabel = new System.Windows.Forms.Label();
            this.ConnStat = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.Halt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Sync = new System.Windows.Forms.Button();
            this.PastTargetLabel = new System.Windows.Forms.Label();
            this.GraphAddress = new System.Windows.Forms.TextBox();
            this.PastDateLabel = new System.Windows.Forms.Label();
            this.GraphDate = new System.Windows.Forms.TextBox();
            this.GraphHour = new System.Windows.Forms.TextBox();
            this.PastHourLabel = new System.Windows.Forms.Label();
            this.LATENTCHART = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.TestStat = new System.Windows.Forms.Label();
            this.TRACETEXT = new System.Windows.Forms.DataGridView();
            this.PastData = new System.Windows.Forms.DataGridView();
            this.UpdatePastData = new System.Windows.Forms.Button();
            this.PastQuery = new System.Windows.Forms.Button();
            this.PastTime = new System.Windows.Forms.TextBox();
            this.PastDate = new System.Windows.Forms.TextBox();
            this.PastAdress = new System.Windows.Forms.TextBox();
            this.PastChartTargetLabel = new System.Windows.Forms.Label();
            this.PastChartDateLabel = new System.Windows.Forms.Label();
            this.PastChartTimeLabel = new System.Windows.Forms.Label();
            this.Cleandata = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.PastCodeLabel = new System.Windows.Forms.Label();
            this.CODE = new System.Windows.Forms.TextBox();
            this.PastCode = new System.Windows.Forms.TextBox();
            this.PastChartCodeLabel = new System.Windows.Forms.Label();
            this.CheckPloss = new System.Windows.Forms.CheckBox();
            this.HideFinalLat = new System.Windows.Forms.CheckBox();
            this.HideMinimum = new System.Windows.Forms.CheckBox();
            this.HideMaximum = new System.Windows.Forms.CheckBox();
            this.HideAverage = new System.Windows.Forms.CheckBox();
            this.HideJitter = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LATENTCHART)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRACETEXT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PastData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // TestConn
            // 
            this.TestConn.Location = new System.Drawing.Point(381, 22);
            this.TestConn.Margin = new System.Windows.Forms.Padding(4);
            this.TestConn.Name = "TestConn";
            this.TestConn.Size = new System.Drawing.Size(164, 25);
            this.TestConn.TabIndex = 0;
            this.TestConn.Text = "Test Connection";
            this.TestConn.UseVisualStyleBackColor = true;
            this.TestConn.Click += new System.EventHandler(this.TestConn_Click);
            // 
            // Adress
            // 
            this.Adress.Location = new System.Drawing.Point(209, 22);
            this.Adress.Margin = new System.Windows.Forms.Padding(4);
            this.Adress.Name = "Adress";
            this.Adress.Size = new System.Drawing.Size(132, 22);
            this.Adress.TabIndex = 1;
            // 
            // TargetLabel
            // 
            this.TargetLabel.AutoSize = true;
            this.TargetLabel.Location = new System.Drawing.Point(17, 26);
            this.TargetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TargetLabel.Name = "TargetLabel";
            this.TargetLabel.Size = new System.Drawing.Size(144, 17);
            this.TargetLabel.TabIndex = 2;
            this.TargetLabel.Text = "Enter Target Address";
            // 
            // IntervalLabel
            // 
            this.IntervalLabel.AutoSize = true;
            this.IntervalLabel.Location = new System.Drawing.Point(17, 69);
            this.IntervalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(173, 17);
            this.IntervalLabel.TabIndex = 3;
            this.IntervalLabel.Text = "Enter Desired Interval(ms)";
            this.IntervalLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // Interval
            // 
            this.Interval.Location = new System.Drawing.Point(209, 60);
            this.Interval.Margin = new System.Windows.Forms.Padding(4);
            this.Interval.Name = "Interval";
            this.Interval.Size = new System.Drawing.Size(132, 22);
            this.Interval.TabIndex = 4;
            // 
            // Change
            // 
            this.Change.Location = new System.Drawing.Point(381, 59);
            this.Change.Margin = new System.Windows.Forms.Padding(4);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(164, 26);
            this.Change.TabIndex = 5;
            this.Change.Text = "Change Paramaters";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // TestStatusLabel
            // 
            this.TestStatusLabel.AutoSize = true;
            this.TestStatusLabel.Location = new System.Drawing.Point(579, 30);
            this.TestStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TestStatusLabel.Name = "TestStatusLabel";
            this.TestStatusLabel.Size = new System.Drawing.Size(52, 17);
            this.TestStatusLabel.TabIndex = 6;
            this.TestStatusLabel.Text = "Status:";
            // 
            // ConnStat
            // 
            this.ConnStat.AutoSize = true;
            this.ConnStat.Location = new System.Drawing.Point(639, 30);
            this.ConnStat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConnStat.Name = "ConnStat";
            this.ConnStat.Size = new System.Drawing.Size(67, 17);
            this.ConnStat.TabIndex = 7;
            this.ConnStat.Text = "Waiting...";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(15, 99);
            this.Start.Margin = new System.Windows.Forms.Padding(4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(165, 63);
            this.Start.TabIndex = 8;
            this.Start.Text = "Start Test";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Halt
            // 
            this.Halt.Location = new System.Drawing.Point(188, 99);
            this.Halt.Margin = new System.Windows.Forms.Padding(4);
            this.Halt.Name = "Halt";
            this.Halt.Size = new System.Drawing.Size(165, 63);
            this.Halt.TabIndex = 9;
            this.Halt.Text = "Halt Test";
            this.Halt.UseVisualStyleBackColor = true;
            this.Halt.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 729);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Graph Data";
            // 
            // Sync
            // 
            this.Sync.Location = new System.Drawing.Point(1287, 33);
            this.Sync.Name = "Sync";
            this.Sync.Size = new System.Drawing.Size(165, 49);
            this.Sync.TabIndex = 12;
            this.Sync.Text = "Sync To Graph";
            this.Sync.UseVisualStyleBackColor = true;
            this.Sync.Click += new System.EventHandler(this.Sync_Click);
            // 
            // PastTargetLabel
            // 
            this.PastTargetLabel.AutoSize = true;
            this.PastTargetLabel.Location = new System.Drawing.Point(934, 41);
            this.PastTargetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PastTargetLabel.Name = "PastTargetLabel";
            this.PastTargetLabel.Size = new System.Drawing.Size(144, 17);
            this.PastTargetLabel.TabIndex = 14;
            this.PastTargetLabel.Text = "Enter Target Address";
            // 
            // GraphAddress
            // 
            this.GraphAddress.Location = new System.Drawing.Point(1126, 37);
            this.GraphAddress.Margin = new System.Windows.Forms.Padding(4);
            this.GraphAddress.Name = "GraphAddress";
            this.GraphAddress.Size = new System.Drawing.Size(132, 22);
            this.GraphAddress.TabIndex = 13;
            // 
            // PastDateLabel
            // 
            this.PastDateLabel.AutoSize = true;
            this.PastDateLabel.Location = new System.Drawing.Point(934, 73);
            this.PastDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PastDateLabel.Name = "PastDateLabel";
            this.PastDateLabel.Size = new System.Drawing.Size(74, 17);
            this.PastDateLabel.TabIndex = 16;
            this.PastDateLabel.Text = "Enter date";
            // 
            // GraphDate
            // 
            this.GraphDate.Location = new System.Drawing.Point(1126, 69);
            this.GraphDate.Margin = new System.Windows.Forms.Padding(4);
            this.GraphDate.Name = "GraphDate";
            this.GraphDate.Size = new System.Drawing.Size(132, 22);
            this.GraphDate.TabIndex = 15;
            // 
            // GraphHour
            // 
            this.GraphHour.Location = new System.Drawing.Point(1126, 99);
            this.GraphHour.Margin = new System.Windows.Forms.Padding(4);
            this.GraphHour.Name = "GraphHour";
            this.GraphHour.Size = new System.Drawing.Size(132, 22);
            this.GraphHour.TabIndex = 17;
            this.GraphHour.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PastHourLabel
            // 
            this.PastHourLabel.AutoSize = true;
            this.PastHourLabel.Location = new System.Drawing.Point(934, 104);
            this.PastHourLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PastHourLabel.Name = "PastHourLabel";
            this.PastHourLabel.Size = new System.Drawing.Size(77, 17);
            this.PastHourLabel.TabIndex = 18;
            this.PastHourLabel.Text = "Enter Hour";
            this.PastHourLabel.Click += new System.EventHandler(this.label7_Click);
            // 
            // LATENTCHART
            // 
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 16;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 5;
            chartArea1.AxisX.Title = "IP Address";
            chartArea1.Name = "ChartArea1";
            this.LATENTCHART.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.LATENTCHART.Legends.Add(legend1);
            this.LATENTCHART.Location = new System.Drawing.Point(15, 169);
            this.LATENTCHART.Name = "LATENTCHART";
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
            series2.Name = "Final Latency(ms)";
            series2.YValuesPerPoint = 10;
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Chocolate;
            series3.Legend = "Legend1";
            series3.Name = "Min Latency(ms)";
            series3.YValuesPerPoint = 10;
            series4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "Max Latency(ms)";
            series4.YValuesPerPoint = 10;
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series5.Color = System.Drawing.Color.Black;
            series5.Legend = "Legend1";
            series5.Name = "Average Latency(ms)";
            series5.YValuesPerPoint = 10;
            series6.BorderWidth = 4;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Gold;
            series6.Legend = "Legend1";
            series6.Name = "Jitter";
            series6.YValuesPerPoint = 2;
            this.LATENTCHART.Series.Add(series1);
            this.LATENTCHART.Series.Add(series2);
            this.LATENTCHART.Series.Add(series3);
            this.LATENTCHART.Series.Add(series4);
            this.LATENTCHART.Series.Add(series5);
            this.LATENTCHART.Series.Add(series6);
            this.LATENTCHART.Size = new System.Drawing.Size(1897, 557);
            this.LATENTCHART.TabIndex = 19;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(373, 121);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(52, 17);
            this.StatusLabel.TabIndex = 20;
            this.StatusLabel.Text = "Status:";
            this.StatusLabel.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // TestStat
            // 
            this.TestStat.AutoSize = true;
            this.TestStat.Location = new System.Drawing.Point(427, 121);
            this.TestStat.Name = "TestStat";
            this.TestStat.Size = new System.Drawing.Size(82, 17);
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
            this.TRACETEXT.Location = new System.Drawing.Point(16, 752);
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
            this.TRACETEXT.Size = new System.Drawing.Size(1124, 231);
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
            this.PastData.Location = new System.Drawing.Point(1323, 752);
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
            this.PastData.Size = new System.Drawing.Size(507, 231);
            this.PastData.TabIndex = 25;
            // 
            // UpdatePastData
            // 
            this.UpdatePastData.Location = new System.Drawing.Point(1836, 752);
            this.UpdatePastData.Name = "UpdatePastData";
            this.UpdatePastData.Size = new System.Drawing.Size(76, 39);
            this.UpdatePastData.TabIndex = 26;
            this.UpdatePastData.Text = "Update";
            this.UpdatePastData.UseVisualStyleBackColor = true;
            this.UpdatePastData.Click += new System.EventHandler(this.UpdatePastData_Click);
            // 
            // PastQuery
            // 
            this.PastQuery.Location = new System.Drawing.Point(1235, 936);
            this.PastQuery.Name = "PastQuery";
            this.PastQuery.Size = new System.Drawing.Size(82, 47);
            this.PastQuery.TabIndex = 27;
            this.PastQuery.Text = "Query";
            this.PastQuery.UseVisualStyleBackColor = true;
            this.PastQuery.Click += new System.EventHandler(this.PastQuery_Click);
            // 
            // PastTime
            // 
            this.PastTime.Location = new System.Drawing.Point(1217, 865);
            this.PastTime.Name = "PastTime";
            this.PastTime.Size = new System.Drawing.Size(100, 22);
            this.PastTime.TabIndex = 28;
            // 
            // PastDate
            // 
            this.PastDate.Location = new System.Drawing.Point(1217, 837);
            this.PastDate.Name = "PastDate";
            this.PastDate.Size = new System.Drawing.Size(100, 22);
            this.PastDate.TabIndex = 29;
            // 
            // PastAdress
            // 
            this.PastAdress.Location = new System.Drawing.Point(1217, 809);
            this.PastAdress.Name = "PastAdress";
            this.PastAdress.Size = new System.Drawing.Size(100, 22);
            this.PastAdress.TabIndex = 30;
            // 
            // PastChartTargetLabel
            // 
            this.PastChartTargetLabel.AutoSize = true;
            this.PastChartTargetLabel.Location = new System.Drawing.Point(1166, 812);
            this.PastChartTargetLabel.Name = "PastChartTargetLabel";
            this.PastChartTargetLabel.Size = new System.Drawing.Size(52, 17);
            this.PastChartTargetLabel.TabIndex = 31;
            this.PastChartTargetLabel.Text = "Adress";
            // 
            // PastChartDateLabel
            // 
            this.PastChartDateLabel.AutoSize = true;
            this.PastChartDateLabel.Location = new System.Drawing.Point(1173, 842);
            this.PastChartDateLabel.Name = "PastChartDateLabel";
            this.PastChartDateLabel.Size = new System.Drawing.Size(38, 17);
            this.PastChartDateLabel.TabIndex = 32;
            this.PastChartDateLabel.Text = "Date";
            // 
            // PastChartTimeLabel
            // 
            this.PastChartTimeLabel.AutoSize = true;
            this.PastChartTimeLabel.Location = new System.Drawing.Point(1172, 868);
            this.PastChartTimeLabel.Name = "PastChartTimeLabel";
            this.PastChartTimeLabel.Size = new System.Drawing.Size(39, 17);
            this.PastChartTimeLabel.TabIndex = 33;
            this.PastChartTimeLabel.Text = "Time";
            // 
            // Cleandata
            // 
            this.Cleandata.Location = new System.Drawing.Point(1287, 111);
            this.Cleandata.Name = "Cleandata";
            this.Cleandata.Size = new System.Drawing.Size(165, 41);
            this.Cleandata.TabIndex = 34;
            this.Cleandata.Text = "Clear";
            this.Cleandata.UseVisualStyleBackColor = true;
            this.Cleandata.Click += new System.EventHandler(this.Cleandata_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1203, 752);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 24);
            this.label11.TabIndex = 35;
            this.label11.Text = "Past Data";
            // 
            // PastCodeLabel
            // 
            this.PastCodeLabel.AutoSize = true;
            this.PastCodeLabel.Location = new System.Drawing.Point(934, 133);
            this.PastCodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PastCodeLabel.Name = "PastCodeLabel";
            this.PastCodeLabel.Size = new System.Drawing.Size(79, 17);
            this.PastCodeLabel.TabIndex = 36;
            this.PastCodeLabel.Text = "Enter Code";
            // 
            // CODE
            // 
            this.CODE.Location = new System.Drawing.Point(1126, 130);
            this.CODE.Margin = new System.Windows.Forms.Padding(4);
            this.CODE.Name = "CODE";
            this.CODE.Size = new System.Drawing.Size(132, 22);
            this.CODE.TabIndex = 37;
            // 
            // PastCode
            // 
            this.PastCode.Location = new System.Drawing.Point(1217, 893);
            this.PastCode.Name = "PastCode";
            this.PastCode.Size = new System.Drawing.Size(100, 22);
            this.PastCode.TabIndex = 38;
            // 
            // PastChartCodeLabel
            // 
            this.PastChartCodeLabel.AutoSize = true;
            this.PastChartCodeLabel.Location = new System.Drawing.Point(1173, 896);
            this.PastChartCodeLabel.Name = "PastChartCodeLabel";
            this.PastChartCodeLabel.Size = new System.Drawing.Size(41, 17);
            this.PastChartCodeLabel.TabIndex = 39;
            this.PastChartCodeLabel.Text = "Code";
            // 
            // CheckPloss
            // 
            this.CheckPloss.AutoSize = true;
            this.CheckPloss.Location = new System.Drawing.Point(1718, 564);
            this.CheckPloss.Name = "CheckPloss";
            this.CheckPloss.Size = new System.Drawing.Size(140, 21);
            this.CheckPloss.TabIndex = 52;
            this.CheckPloss.Text = "Hide Packet Loss";
            this.CheckPloss.UseVisualStyleBackColor = true;
            this.CheckPloss.CheckedChanged += new System.EventHandler(this.CheckPloss_CheckedChanged);
            // 
            // HideFinalLat
            // 
            this.HideFinalLat.AutoSize = true;
            this.HideFinalLat.Location = new System.Drawing.Point(1718, 591);
            this.HideFinalLat.Name = "HideFinalLat";
            this.HideFinalLat.Size = new System.Drawing.Size(147, 21);
            this.HideFinalLat.TabIndex = 53;
            this.HideFinalLat.Text = "Hide Final Latency";
            this.HideFinalLat.UseVisualStyleBackColor = true;
            this.HideFinalLat.CheckedChanged += new System.EventHandler(this.HideFinalLat_CheckedChanged);
            // 
            // HideMinimum
            // 
            this.HideMinimum.AutoSize = true;
            this.HideMinimum.Location = new System.Drawing.Point(1718, 618);
            this.HideMinimum.Name = "HideMinimum";
            this.HideMinimum.Size = new System.Drawing.Size(172, 21);
            this.HideMinimum.TabIndex = 54;
            this.HideMinimum.Text = "Hide Minimum Latency";
            this.HideMinimum.UseVisualStyleBackColor = true;
            this.HideMinimum.CheckedChanged += new System.EventHandler(this.HideMinimum_CheckedChanged);
            // 
            // HideMaximum
            // 
            this.HideMaximum.AutoSize = true;
            this.HideMaximum.Location = new System.Drawing.Point(1718, 645);
            this.HideMaximum.Name = "HideMaximum";
            this.HideMaximum.Size = new System.Drawing.Size(183, 21);
            this.HideMaximum.TabIndex = 55;
            this.HideMaximum.Text = "Hide Maximum Lantency";
            this.HideMaximum.UseVisualStyleBackColor = true;
            this.HideMaximum.CheckedChanged += new System.EventHandler(this.HideMaximum_CheckedChanged);
            // 
            // HideAverage
            // 
            this.HideAverage.AutoSize = true;
            this.HideAverage.Location = new System.Drawing.Point(1718, 672);
            this.HideAverage.Name = "HideAverage";
            this.HideAverage.Size = new System.Drawing.Size(170, 21);
            this.HideAverage.TabIndex = 56;
            this.HideAverage.Text = "Hide Average Latency";
            this.HideAverage.UseVisualStyleBackColor = true;
            this.HideAverage.CheckedChanged += new System.EventHandler(this.HideAverage_CheckedChanged);
            // 
            // HideJitter
            // 
            this.HideJitter.AutoSize = true;
            this.HideJitter.Location = new System.Drawing.Point(1718, 699);
            this.HideJitter.Name = "HideJitter";
            this.HideJitter.Size = new System.Drawing.Size(94, 21);
            this.HideJitter.TabIndex = 57;
            this.HideJitter.Text = "Hide Jitter";
            this.HideJitter.UseVisualStyleBackColor = true;
            this.HideJitter.CheckedChanged += new System.EventHandler(this.HideJitter_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1711, 557);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(201, 169);
            this.pictureBox2.TabIndex = 59;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.HideJitter);
            this.Controls.Add(this.HideAverage);
            this.Controls.Add(this.HideMaximum);
            this.Controls.Add(this.HideMinimum);
            this.Controls.Add(this.HideFinalLat);
            this.Controls.Add(this.CheckPloss);
            this.Controls.Add(this.PastChartCodeLabel);
            this.Controls.Add(this.PastCode);
            this.Controls.Add(this.CODE);
            this.Controls.Add(this.PastCodeLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Cleandata);
            this.Controls.Add(this.PastChartTimeLabel);
            this.Controls.Add(this.PastChartDateLabel);
            this.Controls.Add(this.PastChartTargetLabel);
            this.Controls.Add(this.PastAdress);
            this.Controls.Add(this.PastDate);
            this.Controls.Add(this.PastTime);
            this.Controls.Add(this.PastQuery);
            this.Controls.Add(this.UpdatePastData);
            this.Controls.Add(this.PastData);
            this.Controls.Add(this.TRACETEXT);
            this.Controls.Add(this.TestStat);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.PastHourLabel);
            this.Controls.Add(this.GraphHour);
            this.Controls.Add(this.PastDateLabel);
            this.Controls.Add(this.GraphDate);
            this.Controls.Add(this.PastTargetLabel);
            this.Controls.Add(this.GraphAddress);
            this.Controls.Add(this.Sync);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Halt);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.ConnStat);
            this.Controls.Add(this.TestStatusLabel);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.Interval);
            this.Controls.Add(this.IntervalLabel);
            this.Controls.Add(this.TargetLabel);
            this.Controls.Add(this.Adress);
            this.Controls.Add(this.TestConn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LATENTCHART);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Networking Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LATENTCHART)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRACETEXT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PastData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button TestConn;
		private System.Windows.Forms.TextBox Adress;
		private System.Windows.Forms.Label TargetLabel;
		private System.Windows.Forms.Label IntervalLabel;
		private System.Windows.Forms.TextBox Interval;
		private System.Windows.Forms.Button Change;
		private System.Windows.Forms.Label TestStatusLabel;
		private System.Windows.Forms.Label ConnStat;
		private System.Windows.Forms.Button Start;
		private System.Windows.Forms.Button Halt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Sync;
        private System.Windows.Forms.Label PastTargetLabel;
        private System.Windows.Forms.TextBox GraphAddress;
        private System.Windows.Forms.Label PastDateLabel;
        private System.Windows.Forms.TextBox GraphDate;
        private System.Windows.Forms.TextBox GraphHour;
        private System.Windows.Forms.Label PastHourLabel;
        public System.Windows.Forms.DataVisualization.Charting.Chart LATENTCHART;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label TestStat;
        private System.Windows.Forms.DataGridView TRACETEXT;
        private System.Windows.Forms.DataGridView PastData;
        private System.Windows.Forms.Button UpdatePastData;
        private System.Windows.Forms.Button PastQuery;
        private System.Windows.Forms.TextBox PastTime;
        private System.Windows.Forms.TextBox PastDate;
        private System.Windows.Forms.TextBox PastAdress;
        private System.Windows.Forms.Label PastChartTargetLabel;
        private System.Windows.Forms.Label PastChartDateLabel;
        private System.Windows.Forms.Label PastChartTimeLabel;
        private System.Windows.Forms.Button Cleandata;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label PastCodeLabel;
        private System.Windows.Forms.TextBox CODE;
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

