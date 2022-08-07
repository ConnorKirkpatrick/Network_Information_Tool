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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Interval = new System.Windows.Forms.TextBox();
            this.Change = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ConnStat = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.Halt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Sync = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.GraphAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.GraphDate = new System.Windows.Forms.TextBox();
            this.GraphHour = new System.Windows.Forms.TextBox();
            this.lable6 = new System.Windows.Forms.Label();
            this.LATENTCHART = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label7 = new System.Windows.Forms.Label();
            this.TestStat = new System.Windows.Forms.Label();
            this.TRACETEXT = new System.Windows.Forms.DataGridView();
            this.PastData = new System.Windows.Forms.DataGridView();
            this.UpdatePastData = new System.Windows.Forms.Button();
            this.PastQuery = new System.Windows.Forms.Button();
            this.PastTime = new System.Windows.Forms.TextBox();
            this.PastDate = new System.Windows.Forms.TextBox();
            this.PastAdress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Cleandata = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CODE = new System.Windows.Forms.TextBox();
            this.PastCode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LATENTCHART)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRACETEXT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PastData)).BeginInit();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Target Adress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter Desired Interval(ms)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(579, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Status:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(934, 41);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Enter Target Adress";
            // 
            // GraphAddress
            // 
            this.GraphAddress.Location = new System.Drawing.Point(1126, 37);
            this.GraphAddress.Margin = new System.Windows.Forms.Padding(4);
            this.GraphAddress.Name = "GraphAddress";
            this.GraphAddress.Size = new System.Drawing.Size(132, 22);
            this.GraphAddress.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(934, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Enter date";
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
            // lable6
            // 
            this.lable6.AutoSize = true;
            this.lable6.Location = new System.Drawing.Point(934, 104);
            this.lable6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lable6.Name = "lable6";
            this.lable6.Size = new System.Drawing.Size(77, 17);
            this.lable6.TabIndex = 18;
            this.lable6.Text = "Enter Hour";
            this.lable6.Click += new System.EventHandler(this.label7_Click);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(373, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Status:";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1166, 812);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 31;
            this.label8.Text = "Adress";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1173, 842);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1172, 868);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 17);
            this.label10.TabIndex = 33;
            this.label10.Text = "Time";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(934, 133);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 17);
            this.label12.TabIndex = 36;
            this.label12.Text = "Enter Code";
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1173, 896);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 17);
            this.label13.TabIndex = 39;
            this.label13.Text = "Code";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.PastCode);
            this.Controls.Add(this.CODE);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Cleandata);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PastAdress);
            this.Controls.Add(this.PastDate);
            this.Controls.Add(this.PastTime);
            this.Controls.Add(this.PastQuery);
            this.Controls.Add(this.UpdatePastData);
            this.Controls.Add(this.PastData);
            this.Controls.Add(this.TRACETEXT);
            this.Controls.Add(this.TestStat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LATENTCHART);
            this.Controls.Add(this.lable6);
            this.Controls.Add(this.GraphHour);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GraphDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GraphAddress);
            this.Controls.Add(this.Sync);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Halt);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.ConnStat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.Interval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Adress);
            this.Controls.Add(this.TestConn);
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
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button TestConn;
		private System.Windows.Forms.TextBox Adress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Interval;
		private System.Windows.Forms.Button Change;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label ConnStat;
		private System.Windows.Forms.Button Start;
		private System.Windows.Forms.Button Halt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Sync;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox GraphAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox GraphDate;
        private System.Windows.Forms.TextBox GraphHour;
        private System.Windows.Forms.Label lable6;
        public System.Windows.Forms.DataVisualization.Charting.Chart LATENTCHART;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label TestStat;
        private System.Windows.Forms.DataGridView TRACETEXT;
        private System.Windows.Forms.DataGridView PastData;
        private System.Windows.Forms.Button UpdatePastData;
        private System.Windows.Forms.Button PastQuery;
        private System.Windows.Forms.TextBox PastTime;
        private System.Windows.Forms.TextBox PastDate;
        private System.Windows.Forms.TextBox PastAdress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Cleandata;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox CODE;
        private System.Windows.Forms.TextBox PastCode;
        private System.Windows.Forms.Label label13;
    }
}

