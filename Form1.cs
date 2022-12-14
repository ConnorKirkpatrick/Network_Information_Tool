using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Timers;
using System.Net.NetworkInformation;

namespace Network_Tool
{
	public partial class Form1 : Form
	{
        /// <summary>
        /// intial startup processes, includes clearing volatile databases and eneabling/disabling specific tools.
        /// </summary>
        int Click = 0;
        int tick = 0;
		static System.Timers.Timer Time;
        static System.Timers.Timer Holder;
		public Form1()
		{
			InitializeComponent();
			Change.Enabled = false;
			Start.Enabled = false;
			Halt.Enabled = false;

            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand clearHop = new SqlCommand("delete from hops", con);
            SqlCommand getTick = new SqlCommand("select * from tick");
            getTick.Connection = con;
            SqlDataAdapter adapt = new SqlDataAdapter(getTick);
            con.Open();
            clearHop.ExecuteNonQuery();
            adapt.Fill(dt);
            con.Close();
            int Gtick = Convert.ToInt32(dt.Rows[0][0].ToString());
            Console.WriteLine(tick.ToString());
            pastupdate();
            tick = tick + Gtick;
        }

        public void pastupdate()
        {
            SqlConnection con = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            DataTable build = new DataTable();
            build.Columns.Add("Adress", typeof(string));
            build.Columns.Add("Date", typeof(string));
            build.Columns.Add("Time", typeof(string));
            SqlCommand buildpast = new SqlCommand("Select * from previous order by code");
            buildpast.Connection = con;
            SqlDataAdapter adapt = new SqlDataAdapter(buildpast);
            
            con.Open();
            adapt.Fill(build);
            con.Close();
            PastData.DataSource = build;
            PastData.Update();
        }


		private void TestConn_Click(object sender, EventArgs e)
		{
            ///testing the users inputs for the tool are valid. includes use of component 2
            Adress.ReadOnly = true;
            Interval.ReadOnly = true;
			SqlConnection con = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {
                if (Convert.ToInt32(Interval.Text) > 0)
                {
                    TestConn.Enabled = false;
                    Change.Enabled = true;
                    Start.Enabled = true;

                    int test = Component2.Testcon(Adress.Text, Interval.Text);
                    if (test == 0)
                    {
                        ConnStat.Text = "Connected to" + Adress.Text;
                    }
                    if (test == 1)
                    {
                        ConnStat.Text = "Failed to connect to" + Adress.Text;
                        Start.Enabled = false;
                        Interval.ReadOnly = false;
                        Adress.ReadOnly = false;
                        Change.Enabled = true;
                        TestConn.Enabled = true;
                    }
                    if (test == 2)
                    {
                        ConnStat.Text = "Invalid IP adress";
                        TestConn.Enabled = true;
                        Start.Enabled = false;
                        Interval.ReadOnly = false;
                        Adress.ReadOnly = false;
                        Change.Enabled = true;
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Interval Entered");
                    TestConn.Enabled = true;
                    Start.Enabled = false;
                    Interval.ReadOnly = false;
                    Adress.ReadOnly = false;
                    Change.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Invalid interval");
                TestConn.Enabled = false;
                Change.Enabled = true;
            }
			
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
            ///function for selection of the halt button.
            Time.Stop();
            tick += 1;
            Halt.Enabled = false;
			
            TestStat.Text = "Not Running";


            Holder = new System.Timers.Timer(Convert.ToDouble(5000));
            Holder.Elapsed += new ElapsedEventHandler(Time_Passed);
            Holder.Enabled = true;
            SqlConnection con = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand deltick = new SqlCommand("delete from tick");
            SqlDataAdapter newtick = new SqlDataAdapter();
            newtick.InsertCommand = new SqlCommand("Insert into tick(tick) values (@tick)",con);
            newtick.InsertCommand.Parameters.Add("@tick", SqlDbType.Int).Value = tick;
            deltick.Connection = con;

            con.Open();
            deltick.ExecuteNonQuery();
            newtick.InsertCommand.ExecuteNonQuery();
            Holder.Start();
            



        }

        private void Time_Passed(object sender, ElapsedEventArgs e)
        {
            ///using a timer to run selected functions in timed intervals
            if (Click < 1)
            {
                Start.Invoke(new Action(() => Start.Enabled = true));
                Change.Invoke(new Action(() => Change.Enabled = true));
                Sync.Invoke(new Action(() => Sync.Enabled = true));
                Click += 1;
            }
            else
            {
                KILL();
            }
            
        }
        public void KILL()
        {
            ///function to halt the timer "holder"
            Holder.Stop();
            Click = 0;
        }
        private void Start_Click(object sender, EventArgs e)
		{
            ClearData();
            string date = DateTime.Now.Date.ToString();
            string time = DateTime.Now.Hour.ToString();
            SqlConnection Conn = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter addPast = new SqlDataAdapter();
            addPast.InsertCommand = new SqlCommand("insert into previous(Adress, date, time,code) values (@host, @date, @time, @code)",Conn);
            addPast.InsertCommand.Parameters.Add("@host", SqlDbType.Text).Value = Adress.Text.ToString();
            addPast.InsertCommand.Parameters.Add("@date", SqlDbType.Text).Value = date;
            addPast.InsertCommand.Parameters.Add("@time", SqlDbType.Text).Value = time;
            addPast.InsertCommand.Parameters.Add("@code", SqlDbType.Int).Value = tick;
            Conn.Open();
            addPast.InsertCommand.ExecuteNonQuery();
            Conn.Close();

            ///function for clicking the start button for the tests and the events that follow
            Sync.Enabled = false;
            TestStat.Text = "Running";
			Start.Enabled = false;
			Change.Enabled = false;
			Halt.Enabled = true;
            Time = new System.Timers.Timer(Convert.ToDouble(Interval.Text));
			Time.Elapsed += new ElapsedEventHandler(Time_Elapsed);
			Time.Enabled = true;
			Time.Start();
			
		}
        public void clear()
        {
            ///clearing the graph, invokes used due to multiple threads in execution
            if (this.LATENTCHART.InvokeRequired)
            {
                LATENTCHART.Invoke(new Action(() => LATENTCHART.Series["Final Latency(ms)"].Points.Clear()));
                LATENTCHART.Invoke(new Action(() => LATENTCHART.Series["Min Latency(ms)"].Points.Clear()));
                LATENTCHART.Invoke(new Action(() => LATENTCHART.Series["Max Latency(ms)"].Points.Clear()));
                LATENTCHART.Invoke(new Action(() => LATENTCHART.Series["Average Latency(ms)"].Points.Clear()));
                LATENTCHART.Invoke(new Action(() => LATENTCHART.Series["Jitter"].Points.Clear()));
                LATENTCHART.Invoke(new Action(() => LATENTCHART.Series["Packet loss"].Points.Clear()));
            }
            else
            {
                LATENTCHART.Series["Final Latency(ms)"].Points.Clear();
                LATENTCHART.Series["Min Latency(ms)"].Points.Clear();
                LATENTCHART.Series["Max Latency(ms)"].Points.Clear();
                LATENTCHART.Series["Average Latency(ms)"].Points.Clear();
                LATENTCHART.Series["Jitter"].Points.Clear();
                LATENTCHART.Series["Packet loss"].Points.Clear();
            }
            
        }
		private void Time_Elapsed(object sender, ElapsedEventArgs e)
		{
            ///Primary timer for providing interleaved function execution
            ///function for actualy running the network trace tool in component 3/4
            string target = Adress.Text;
            string INT = Interval.Text;
            while (Halt.Enabled == true)
			{
                //running the trace tool in component 3, clearing the graph and redrawing the points.
				Component3.Times(target, INT, tick);
                clear();
                string date = DateTime.Now.Date.ToString();
                string adress = Adress.Text.ToString();
                string hour = DateTime.Now.Hour.ToString();
                drawTrace(date, adress, hour);


            }
            
		}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Sync_Click(object sender, EventArgs e)
        {
            bool Valid = false;
            while (Valid == false)
            {
                /*
                if (CODE.Text == "" && GraphAddress.Text == "" && GraphDate.Text == "" && GraphHour.Text == "")
                {
                    MessageBox.Show("Please fill at least one of the fields");
                }
                if (GraphHour.Text != "" && GraphDate.Text != "" && GraphAddress.Text == "")
                {
                    MessageBox.Show("Please specify the target adress");
                }
                */
                if (CODE.Text != "")
                {
                    Valid = true;
                    break;
                }
                if (GraphAddress.Text == "")
                {
                    MessageBox.Show("Please enter an adress or code");
                    break;
                }
                if(GraphDate.Text == "")
                {
                    MessageBox.Show("Please enter a date or code");
                    break;
                }
                if (GraphHour.Text == "")
                {
                    MessageBox.Show("Please enter an hour or code");
                    break;
                }
                else
                {
                    Valid = true;
                    Console.WriteLine("VALID CHANGED");
                    break;
                }
            }
            syncauthenticate();

            

        }
        
        public void syncauthenticate()
        {
            GraphAddress.ReadOnly = true;
            GraphDate.ReadOnly = true;
            GraphHour.ReadOnly = true;
            CODE.ReadOnly = true;
            SqlConnection connection = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand trim = new SqlCommand("Delete from data where convert(varchar,hop) = ''");
            trim.Connection = connection;
            connection.Open();
            trim.ExecuteNonQuery();
            connection.Close();
            ///function used to sync past data to graph
            clear();
            string date = GraphDate.Text.ToString();
            string adress = GraphAddress.Text.ToString();
            string hour = GraphHour.Text.ToString();
            date = date + " 00:00:00";
            DrawtoGraph(date, adress, hour);
        }
        private void Change_Click(object sender, EventArgs e)
        {
            //enabling and disabling specific buttons when the user opts to change the target adress or interval.
            Adress.ReadOnly = false;
            Interval.ReadOnly = false;
            Start.Enabled = false;
            Halt.Enabled = false;
            TestConn.Enabled = true;
            Change.Enabled = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void TraceText_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click_1(object sender, EventArgs e)
        {

        }
        private void TraceText_TextChanged(object sender, EventArgs e)
        {

        }

        public void drawTrace(string date, string adress, string hour)
        {
            ///function used for real time tracing of a ping and displaying the points in a text box on the GUI
            DataTable dt = new DataTable();
            dt.Columns.Add("HopNum", typeof(int));
            dt.Columns.Add("Adress", typeof(string));
            dt.Columns.Add("Final latency(ms)", typeof(int));
            dt.Columns.Add("Min latency(ms)", typeof(int));
            dt.Columns.Add("Max latency(ms)", typeof(int));
            dt.Columns.Add("average latency(ms)", typeof(int));
            dt.Columns.Add("Packet Loss", typeof(int));
            dt.Columns.Add("Jitter", typeof(int));

            

            SqlConnection Conn = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            DataTable data = new DataTable();
            SqlCommand graph = new SqlCommand();
            graph.Connection = Conn;
            string tickcode = CODE.Text.ToString();
            graph.CommandText = "select * from data where CONVERT(varchar, host) like '%" + adress + "%' and CONVERT(varchar, date) like '%" + date + "%' and CONVERT(varchar, time) like '%" + hour + "%' and Convert(varchar,code) like '%"+tickcode+"%' order by seq";
            graph.CommandType = CommandType.Text;
            try
            {
                Conn.Open();
            }
            catch
            {
                MessageBox.Show("Database Error");
            }
            SqlDataAdapter fill = new SqlDataAdapter(graph);
            fill.Fill(data);
            Conn.Close();

            DataView view = new DataView(data);
            DataTable distinct = view.ToTable(true, "hop");


            DataRow[] selectunique;
            selectunique = distinct.Select();

            //the process for selecting the data in the data table, grouping the points together and generating important data points
            for (int i = 0; i < selectunique.Length; i++)
            {
                string unique = selectunique[i][0].ToString();
                int x = 0;
                if (unique != "X")
                {
                    x += 1;
                    DataRow[] selected;
                    selected = data.Select("hop = '" + unique + "'");

                    int mxlat = 0;
                    int mnlat = 2000;

                    int avelat = 0;
                    int count = 0;
                    int totlat = 0;

                    int jitter = 0;
                    int totPL = 0;
                    for (int tick = 0; tick < selected.Length; tick++)
                    {
                        int lat1 = Convert.ToInt32(selected[tick][1]);
                        int lat2 = Convert.ToInt32(selected[tick][2]);
                        int latency = lat2 - lat1;
                        totlat = totlat + latency;
                        count++;
                        if (latency < 0)
                        {
                            latency = 1000 + latency;
                        }
                        if (latency > mxlat)
                        {
                            mxlat = latency;
                        }
                        if (latency < mnlat)
                        {
                            mnlat = latency;
                        }
                        totPL = totPL + Convert.ToInt32(selected[tick][8]);

                    }
                    avelat = totlat / count;
                    int finalLat = Convert.ToInt32(selected[selected.Length - 1][2]) - Convert.ToInt32(selected[selected.Length - 1][1]);
                    if(finalLat< 0)
                    {
                        finalLat = 1000 + finalLat;
                    }
                    jitter = totPL / count;
                    int PL = Convert.ToInt32(selected[selected.Length - 1][8]);

                    dt.Rows.Add(x, unique, finalLat, mnlat, mxlat, avelat, PL, jitter);


                }
            }
            //adding data to the text box, use of an invoke if the application is able to run over multiple threads
            if (this.TRACETEXT.InvokeRequired)
            {
                TRACETEXT.Invoke(new Action(() => TRACETEXT.DataSource = dt));
                TRACETEXT.Invoke(new Action(() => TRACETEXT.Update()));
            }
            else
            {
                TRACETEXT.DataSource = dt;
                TRACETEXT.Update();
            }
        }

        public void DrawtoGraph(string date, string adress, string hour)
        {
            ///function used in both real time and past trace operations to draw the points onto the graph in the GUI
            SqlConnection Conn = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            DataTable data = new DataTable();
            SqlCommand graph = new SqlCommand();
            graph.Connection = Conn;
            string tickcode = CODE.Text.ToString();
            graph.CommandText = "select * from data where CONVERT(varchar, host) like '%" + adress + "%' and CONVERT(varchar, date) like '%" + date + "%' and CONVERT(varchar, time) like '%" + hour + "%' and Convert(varchar,code) like '%" + tickcode + "%' order by seq";
            graph.CommandType = CommandType.Text;
            graph.Connection = Conn;
            try
            {
                Conn.Open();
            }
            catch
            {
                MessageBox.Show("Database Error");
            }
            SqlDataAdapter fill = new SqlDataAdapter(graph);
            fill.Fill(data);
            Conn.Close();

            DataView view = new DataView(data);
            DataTable distinct = view.ToTable(true, "hop");


            DataRow[] selectunique;
            selectunique = distinct.Select();

            DataTable dt = new DataTable();
            dt.Columns.Add("HopNum", typeof(int));
            dt.Columns.Add("Adress", typeof(string));
            dt.Columns.Add("Final latency(ms)", typeof(int));
            dt.Columns.Add("Min latency(ms)", typeof(int));
            dt.Columns.Add("Max latency(ms)", typeof(int));
            dt.Columns.Add("average latency(ms)", typeof(int));
            dt.Columns.Add("Packet Loss", typeof(int));
            dt.Columns.Add("Jitter", typeof(int));

            //selecting the data from the data table, sorting it via common adresses and generating the data points.
            int x = 0;
            for (int i = 0; i < selectunique.Length; i++)
            {
                string unique = selectunique[i][0].ToString();
                if (unique != "X")
                {
                    x += 1;
                    DataRow[] selected;
                    selected = data.Select("hop = '" + unique + "'");

                    int mxlat = 0;
                    int mnlat = 2000;

                    int avelat = 0;
                    int count = 0;
                    int totlat = 0;

                    int jitter = 0;
                    int totPL = 0;
                    for (int tick = 0; tick < selected.Length; tick++)
                    {
                        int lat1 = Convert.ToInt32(selected[tick][1]);
                        int lat2 = Convert.ToInt32(selected[tick][2]);
                        int latency = lat2 - lat1;

                        count++;
                        if (latency < 0)
                        {
                            latency = 1000 - (latency * (-1));
                        }
                        if (latency > mxlat)
                        {
                            mxlat = latency;
                        }
                        if (latency < mnlat)
                        {
                            mnlat = latency;
                        }
                        totlat = totlat + latency;
                        totPL = totPL + Convert.ToInt32(selected[tick][8]);

                    }
                    avelat = totlat / count;
                    int finalLat = Convert.ToInt32(selected[selected.Length - 1][2]) - Convert.ToInt32(selected[selected.Length - 1][1]);
                    if (finalLat < 0)
                    {
                        finalLat = 1000 -(finalLat*(-1));
                    }
                    jitter = totPL / count;
                    int PL = Convert.ToInt32(selected[selected.Length - 1][8]);

                    dt.Rows.Add(x, unique, finalLat, mnlat, mxlat, avelat, PL, jitter);
            
                    if (this.LATENTCHART.InvokeRequired)
                    {
                        LATENTCHART.Invoke(new Action(() => LATENTCHART.Series["Latency(ms)"].Points.AddXY(unique, finalLat)));
                        LATENTCHART.Invoke(new Action(() => LATENTCHART.Series["Min Latency(ms)"].Points.AddXY(unique, finalLat)));
                        LATENTCHART.Invoke(new Action(() => LATENTCHART.Series["Max Latency(ms)"].Points.AddXY(unique, finalLat)));
                        LATENTCHART.Invoke(new Action(() => LATENTCHART.Series["Average Latency(ms)"].Points.AddXY(unique, finalLat)));
                        LATENTCHART.Invoke(new Action(() => LATENTCHART.Series["Packet loss"].Points.AddXY(unique, finalLat)));
                        LATENTCHART.Invoke(new Action(() => LATENTCHART.Series["Jitter"].Points.AddXY(unique, finalLat)));
                        LATENTCHART.Invoke(new Action(() => LATENTCHART.ChartAreas["ChartArea1"].AxisX.Interval = 1));
                        LATENTCHART.Invoke(new Action(() => LATENTCHART.Titles.Add(""+adress+"")));

                    }
                    else
                    {
                        LATENTCHART.Series["Final Latency(ms)"].Points.AddXY(unique, finalLat);
                        LATENTCHART.Series["Min Latency(ms)"].Points.AddXY(unique, mnlat);
                        LATENTCHART.Series["Max Latency(ms)"].Points.AddXY(unique, mxlat);
                        LATENTCHART.Series["Average Latency(ms)"].Points.AddXY(unique, avelat);
                        LATENTCHART.Series["Packet loss"].Points.AddXY(unique, PL);
                        LATENTCHART.Series["Jitter"].Points.AddXY(unique, jitter);
                        LATENTCHART.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                    }
                    
                }
                else
                {

                }
            }
            if (this.TRACETEXT.InvokeRequired)
            {
                TRACETEXT.Invoke(new Action(() => TRACETEXT.DataSource = dt));
                TRACETEXT.Invoke(new Action(() => TRACETEXT.Update()));
            }
            else
            {
                TRACETEXT.DataSource = dt;
                TRACETEXT.Update();
            }
        }

        private void UpdatePastData_Click(object sender, EventArgs e)
        {
            pastupdate();
        }

        private void PastQuery_Click(object sender, EventArgs e)
        {
            string host = PastAdress.Text.ToString();
            string date = PastDate.Text.ToString();
            string time = PastTime.Text.ToString();

            SqlConnection con = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            DataTable pastquery = new DataTable();
            pastquery.Columns.Add("Adress", typeof(string));
            pastquery.Columns.Add("Date", typeof(string));
            pastquery.Columns.Add("Time", typeof(string));
            //Select* from previous where convert(varchar, adress) like '%"+ host +"%' and convert(varchar, date) like '%"+date+"%' and convert(varchar, time) like '%"+time+"%'
            string pastcode = PastCode.Text.ToString();
            SqlCommand buildpast = new SqlCommand("Select* from previous where convert(varchar, adress) like '%" + host + "%' and convert(varchar, date) like '%" + date + "%' and convert(varchar, time) like '%" + time + "%' and convert(varchar,code) like '%"+pastcode+"%'");
            buildpast.Connection = con;
            SqlDataAdapter adapt = new SqlDataAdapter(buildpast);

            con.Open();
            adapt.Fill(pastquery);
            con.Close();
            PastData.DataSource = pastquery;
            PastData.Update();
        }
        private void ClearData()
        {
            LATENTCHART.Series["Final Latency(ms)"].Points.Clear();
            LATENTCHART.Series["Min Latency(ms)"].Points.Clear();
            LATENTCHART.Series["Max Latency(ms)"].Points.Clear();
            LATENTCHART.Series["Average Latency(ms)"].Points.Clear();
            LATENTCHART.Series["Jitter"].Points.Clear();
            LATENTCHART.Series["Packet loss"].Points.Clear();

            TRACETEXT.DataSource = null;
            TRACETEXT.Update();
        }

        private void Cleandata_Click(object sender, EventArgs e)
        {
            ClearData();
            GraphAddress.ReadOnly = false;
            GraphDate.ReadOnly = false;
            GraphHour.ReadOnly = false;
            CODE.ReadOnly = false;
        }
    }
}
