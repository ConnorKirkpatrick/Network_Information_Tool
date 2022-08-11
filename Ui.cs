using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Net;
using System.Timers;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Network_Tool.NetworkingMethods;
using Network_Tool.SQLMethods;

namespace Network_Tool
{
    /// <summary>
    /// the namespace acts as an identifier for all components of this program to keep them isolated from other programs
    /// Seen above are all the class libraries imported for each sub class. these are inherited but I have overridden them in the other components to increase efficiency
    /// </summary>
	public partial class UiForm : Form
	{
        //the creation of the "partial class" create the file "Form1" as a form utilizing the windows forms library.
        //this allow the now independent file to be called upon and constructed as a form
        //The class is constructed as a child of the "Program"
        //the few global variables are created here in addition to the creation of global tools such as the stopwatches
        int Click = 0;
        private NetworkMethods NetworkMethods = new NetworkMethods();
        private SQLConnection SQLConn = new SQLConnection();
        static System.Timers.Timer Time;
        static System.Timers.Timer Holder;

        public UiForm()
        {
            //This is the code executed when the "main()" function calls for Form1
            //the initial code sets up all the objects and forces some to be disabled initially
            InitializeComponent();
            ChangeParametersButton.Enabled = false;
            StartTestButton.Enabled = false;
            HaltTestButton.Enabled = false;

            //Testing connection to the SQL database
            Task<bool> result = Task<bool>.Factory.StartNew(() => SQLConn.testConnection());
            if (!result.Result)
            {
                MessageBox.Show("Error reaching server");
            }
        }

        public void pastupdate()
        {
            //This section of data connects to the database with past data to display it to the user.
            SqlConnection con = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //creating the datatable and setting up the binding parameters.
            DataTable build = new DataTable();
            build.Columns.Add("Adress", typeof(string));
            build.Columns.Add("Date", typeof(string));
            build.Columns.Add("Time", typeof(string));
            SqlCommand buildpast = new SqlCommand("Select * from previous order by code");
            buildpast.Connection = con;
            SqlDataAdapter adapt = new SqlDataAdapter(buildpast);
            //connecting to the database and binding the data
            con.Open();
            adapt.Fill(build);
            con.Close();
            PastData.DataSource = build;
            PastData.Update();
        }


		private async void TestConn_Click(object sender, EventArgs e)
		{
            //Check user parameters are correct, set parameters to read-only while checking
            Adress.ReadOnly = true;
            Interval.ReadOnly = true; 
            //check that the IP is valid
            try
            {
                IPAddress.Parse(Adress.Text);
            }
            catch
            {
                MessageBox.Show("Invalid IP address");
                Adress.ReadOnly = false;
                Interval.ReadOnly = false; 
                return;
            }
            //check that the interval is both a valid integer and >= to 50
            try
            {
                if (Convert.ToInt32(Interval.Text) < 50)
                {
                    MessageBox.Show("Minimum interval is 50ms");
                    Adress.ReadOnly = false;
                    Interval.ReadOnly = false; 
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Invalid Interval entered");
                Adress.ReadOnly = false;
                Interval.ReadOnly = false; 
                return;
            }
            TestConnectionButton.Enabled = false;
            ChangeParametersButton.Enabled = true;
            StartTestButton.Enabled = true;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            /*
            ThreadPool.QueueUserWorkItem((a) => {
                if (NetworkMethods.Ping(Adress.Text).Result)
                {
                    ConnStat.Invoke(new Action(() => ConnStat.Text = "Connected to" + Adress.Text));
                    ConnStat.Text = "Connected to" + Adress.Text;
                }
                else
                {
                    
                    ConnStat.Text = "Failed to connect to" + Adress.Text;
                    Start.Enabled = false;
                    Interval.ReadOnly = false;
                    Adress.ReadOnly = false;
                    Change.Enabled = true;
                    TestConn.Enabled = true;
                    
                }});
                */
            bool netStatus = await NetworkMethods.Ping(Adress.Text);
            if (netStatus)
            {
                ConnStat.Text = "Connected to" + Adress.Text;
            }
            else
            {
                ConnStat.Text = "Failed to connect to" + Adress.Text;
                StartTestButton.Enabled = false;
                Interval.ReadOnly = false;
                Adress.ReadOnly = false;
                ChangeParametersButton.Enabled = true;
                TestConnectionButton.Enabled = true;
            }
            stopWatch.Stop();
            Debug.WriteLine("Conn test completed in: "+stopWatch.ElapsedMilliseconds);
        }

		private void label2_Click(object sender, EventArgs e)
		{}

		private void button1_Click(object sender, EventArgs e)
		{
            //function for selection of the halt button.
            Time.Stop();
            HaltTestButton.Enabled = false;
            TestStat.Text = "Not Running";
            //creating a timer to pause all user inputs for 5 seconds to let the system finish uploading data to the database
            Holder = new System.Timers.Timer(Convert.ToDouble(5000));
            Holder.Elapsed += new ElapsedEventHandler(Time_Passed);
            Holder.Enabled = true;
            SqlConnection con = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //refreshing the "tick" datavalue in the server to keep it persistant;
            SqlCommand deltick = new SqlCommand("delete from tick");
            SqlDataAdapter newtick = new SqlDataAdapter();
            newtick.InsertCommand = new SqlCommand("Insert into tick(tick) values (@tick)",con);
            //newtick.InsertCommand.Parameters.Add("@tick", SqlDbType.Int).Value = tick;
            deltick.Connection = con;
            //executing the sql command
            con.Open();
            deltick.ExecuteNonQuery();
            newtick.InsertCommand.ExecuteNonQuery();
            Holder.Start();
        }

        private void Time_Passed(object sender, ElapsedEventArgs e)
        {
            //using a timer to run selected functions in timed intervals
            if (Click < 1)
            {
                //the invoke is required due to the fact that the execution may have to pass over different executing threads. 
                //normally this would be denied to avoid errors but the invoke command is used to flag the execution as an interrupt to the thread
                StartTestButton.Invoke(new Action(() => StartTestButton.Enabled = true));
                ChangeParametersButton.Invoke(new Action(() => ChangeParametersButton.Enabled = true));
                SyncToGraphButton.Invoke(new Action(() => SyncToGraphButton.Enabled = true));
                Click += 1;
            }
            else
            {
                KILL();
            }
            
        }
        public void KILL()
        {
            //function to halt the timer "holder"
            Holder.Stop();
            Click = 0;
        }
        private void Start_Click(object sender, EventArgs e)
		{
            //initiating the test: ensuring the graph is clear, other controls are disabled to the user and adding the required data to the database
            ClearData();
            //the tool fetches the validated user inputs and passes them to the past data table in form of an SQL query
            string date = DateTime.Now.Date.ToString();
            string time = DateTime.Now.Hour.ToString();
            SqlConnection Conn = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter addPast = new SqlDataAdapter();
            addPast.InsertCommand = new SqlCommand("insert into previous(Adress, date, time,code) values (@host, @date, @time, @code)",Conn);
            addPast.InsertCommand.Parameters.Add("@host", SqlDbType.Text).Value = Adress.Text.ToString();
            addPast.InsertCommand.Parameters.Add("@date", SqlDbType.Text).Value = date;
            addPast.InsertCommand.Parameters.Add("@time", SqlDbType.Text).Value = time;
            //addPast.InsertCommand.Parameters.Add("@code", SqlDbType.Int).Value = tick;
            Conn.Open();
            addPast.InsertCommand.ExecuteNonQuery();
            Conn.Close();

            //function for clicking the start button for the tests and the events that follow
            SyncToGraphButton.Enabled = false;
            TestStat.Text = "Running";
			StartTestButton.Enabled = false;
			ChangeParametersButton.Enabled = false;
			HaltTestButton.Enabled = true;
            Time = new System.Timers.Timer(Convert.ToDouble(Interval.Text));
			Time.Elapsed += new ElapsedEventHandler(Time_Elapsed);
			Time.Enabled = true;
			Time.Start();
			
		}
        public void clear()
        {
            //clearing the graph, invokes used due to multiple threads in execution
            //option is given due to some machines restricting the executable to one thread on the processor
            if (this.NetworkInfoChart.InvokeRequired)
            {
                NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Series["Final Latency(ms)"].Points.Clear()));
                NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Series["Min Latency(ms)"].Points.Clear()));
                NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Series["Max Latency(ms)"].Points.Clear()));
                NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Series["Average Latency(ms)"].Points.Clear()));
                NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Series["Jitter"].Points.Clear()));
                NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Series["Packet loss"].Points.Clear()));
            }
            else
            {
                NetworkInfoChart.Series["Final Latency(ms)"].Points.Clear();
                NetworkInfoChart.Series["Min Latency(ms)"].Points.Clear();
                NetworkInfoChart.Series["Max Latency(ms)"].Points.Clear();
                NetworkInfoChart.Series["Average Latency(ms)"].Points.Clear();
                NetworkInfoChart.Series["Jitter"].Points.Clear();
                NetworkInfoChart.Series["Packet loss"].Points.Clear();
            }
            
        }
		private void Time_Elapsed(object sender, ElapsedEventArgs e)
		{
            //Primary timer for providing interleaved function execution
            //function for actually running the network trace tool in component 3/4
            string target = Adress.Text;
            string INT = Interval.Text;
            while (HaltTestButton.Enabled == true)
			{
                //running the trace tool in component 3, clearing the graph and redrawing the points.
				//Component3.Times(target, INT, tick);
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
            //the area that governs the controls to bind data to the graph;
            //directly below is the area for testing whether the user inputs is a valid input
            bool Valid = false;
            string host = GraphAddress.Text;
            string date = GraphDate.Text;
            string time = GraphHour.Text;
            string past = CODE.Text;

            //each set of following indented code tests a separate user input for valid entries
            //each set of code incorporates a regular expression check and potentially inequalities to validate the user inputs 
            if (host != "")
            {
                try
                {
                    //use of regular expression to classify user input
                    Regex ip = new Regex(@"\b{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
                    MatchCollection mcI = ip.Matches(host);
                    var test = mcI[0];

                }
                catch
                {
                    MessageBox.Show("The data entered for the Adress is not in IPV4 Form");
                    host = "";
                }
            }
            if (date != "")
            {
                try
                {
                    Regex Rdate = new Regex(@"\b\d{2}\/\d{2}\/\d{4}(\S\0{2}\:\0{2}\:\0{2})?$");
                    MatchCollection mcD = Rdate.Matches(date);
                    var test = mcD[0];
                }
                catch
                {
                    MessageBox.Show("The data entered for the Date is not in DD/MM/YYYY Form");
                    date = "";
                }
            }
            if (time != "")
            {
                try
                {
                    if (Convert.ToInt32(time) >= 0)
                    {
                        if (Convert.ToInt32(time) < 25)
                        {
                            try
                            {
                                Regex RTime = new Regex(@"\b\d\d?$");
                                MatchCollection mcT = RTime.Matches(time);
                                var test = mcT[0];
                            }
                            catch
                            {
                                MessageBox.Show("The data entered for the Time is not in 2-digit Form");
                                time = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("The data entered for the Time is not in 2-digit Form");
                            time = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("The data entered for the Time is not in 2-digit Form");
                        time = "";
                    }

                }
                catch
                {
                    MessageBox.Show("The data entered for the Time is not in 2-digit Form");
                    time = "";
                }


            }
            if (past != "")
            {
                try
                {
                    if (Convert.ToInt32(past) >= 0)
                    {
                        try
                        {
                            Regex Rdate = new Regex(@"\b\d+$");
                            MatchCollection mcP = Rdate.Matches(past);
                            var test = mcP[0];
                        }
                        catch
                        {
                            MessageBox.Show("The data entered for the code is not a valid posetive integer");
                            past = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("The data entered for the code is not a valid posetive integer");
                        past = "";
                    }
                }
                catch
                {
                    MessageBox.Show("The data entered for the code is not a valid posetive integer");
                    past = "";
                }

            }
            //testing is users have entered the correct volumes of data for the tool to accurately fetch data from the database
            //this is due to the sheer quantity of data in the database. without the correct series of data, a whole variety of values may be selected by mistake
            if (CODE.Text == "")
            {
                if (CODE.Text == "" && GraphAddress.Text == "" && GraphDate.Text == "" && GraphHour.Text == "")
                {
                    MessageBox.Show("Please fill in required the fields");
                }
                if (GraphHour.Text != "" && GraphDate.Text != "" && GraphAddress.Text == "") 
                {
                    MessageBox.Show("Please specify the target adress");
                }

                if (CODE.Text != "")
                {
                    Valid = true;

                }
                if (GraphAddress.Text == "")
                {
                    MessageBox.Show("Please enter an adress");

                }
                if (GraphDate.Text == "")
                {
                    MessageBox.Show("Please enter a date");

                }
                if (GraphHour.Text == "")
                {
                    MessageBox.Show("Please enter an hour");
                }
                else
                {
                    Valid = true;
                }
                if (Valid)
                {
                    //pushes data to Component 2 to test the data requested is actually in the database
                    //returns a boolean value
                    string ajustDate = GraphDate.Text;
                    if (ajustDate.Substring(GraphDate.Text.Length - 8) != "00:00:00")
                    {
                        GraphDate.Text = GraphDate.Text +" 00:00:00";
                    }
                    //pushes data to component 2 to ensure the requested data is actually obtainable from the database
                    bool datatest = Component2.TestDatabase(GraphAddress.Text, ajustDate, Convert.ToInt32(GraphHour.Text));
                    if (datatest == true)
                    {
                        //executes function call to the subroutine to actaul manage the graphing
                        syncauthenticate();
                    }
                    else
                    {
                        //displays error box
                        Console.WriteLine("Substring: "+GraphDate.Text.Substring(GraphDate.Text.Length - 8));
                        MessageBox.Show("Incorrect Data//Data not in table");
                    }
                    
                }
            }
            else
            { 
                //runs only if the user has only entered a code to avoid errors caused by null inputs above
                //if (Convert.ToInt32(CODE.Text) <= tick)
                {
                    //executes function call to the subroutine to actual manage the graphing
                    syncauthenticate();
                }
                //else
                {
                    MessageBox.Show("Incorrect Data");
                }
            }

        }
        
        public void syncauthenticate()
        {
            //sets graphing controls to read only so the program can execute without needing interrupt handles should the user change the data part way through
            GraphAddress.ReadOnly = true;
            GraphDate.ReadOnly = true;
            GraphHour.ReadOnly = true;
            CODE.ReadOnly = true;
            //short SQL query that executes to eliminate any blank rows in the database
            //is situated here as this is one of the last calls of the main executable
            SqlConnection connection = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand trim = new SqlCommand("Delete from data where convert(varchar,hop) = ''");
            trim.Connection = connection;
            connection.Open();
            trim.ExecuteNonQuery();
            connection.Close();
            //function used to sync past data to graph
            clear();
            string date = GraphDate.Text.ToString();
            string adress = GraphAddress.Text.ToString();
            string hour = GraphHour.Text.ToString();
            string ajustDate = GraphDate.Text;
            //checking whether the users input has a trailing "00:00:00" and adds it if not
            try
            {
                if (ajustDate.Substring(GraphDate.Text.Length - 8) != "00:00:00")
                {
                    GraphDate.Text = GraphDate.Text + " 00:00:00";
                }
            }
            catch{ }

            TestConnectionButton.Enabled = false;
            drawTrace(date, adress, hour);
        }
        private void Change_Click(object sender, EventArgs e)
        {
            //enabling and disabling specific buttons when the user opts to change the target address or interval.
            Adress.ReadOnly = false;
            Interval.ReadOnly = false;
            StartTestButton.Enabled = false;
            HaltTestButton.Enabled = false;
            TestConnectionButton.Enabled = true;
            ChangeParametersButton.Enabled = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {}
        private void textBox1_TextChanged(object sender, EventArgs e)
        {}
        private void TraceText_Click(object sender, EventArgs e)
        {}
        private void label7_Click_1(object sender, EventArgs e)
        {}
        private void TraceText_TextChanged(object sender, EventArgs e)
        {}
        

        public void drawTrace(string date, string adress, string hour)
        {
            //custom written aggregation algorithm
            //function used for real time tracing of a ping and displaying the points in a text box on the GUI
            //establishing the connection the the database
			SqlConnection Conn = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            DataTable data = new DataTable();
            SqlCommand graph = new SqlCommand();
            graph.Connection = Conn;
            string tickcode = CODE.Text.ToString();
            graph.CommandText = "select * from data where CONVERT(varchar, host) like '%" + adress + "%' and CONVERT(varchar, date) like '%" + date + "%' and CONVERT(varchar, time) like '%" + hour + "%' and Convert(varchar,code) like '%" + tickcode + "%' order by seq";
            graph.CommandType = CommandType.Text;
            try
            {
                Conn.Open();
            }
            catch
            {
                MessageBox.Show("Database Error");
            }
            //collecting the required data from the database
            SqlDataAdapter fill = new SqlDataAdapter(graph);
            fill.Fill(data);
            Conn.Close();

            DataView view = new DataView(data);
            DataTable distinct = view.ToTable(true, "hop");

            //creating the datatables to store the bulk data, data rows to store specific data 
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

            //The section bellow is the custom written SQL aggregation/sorting algorithm for my code
            //the algorithm works by isolating the individual nodes on the traceroute before independently testing each one
            //this system ensures data is not lost,ignored or incorrectly grouped before the main aggregation takes place.
            
            //the aggregation takes each of these groups individually and compares them to find maximum, minimum and average values
            //this allows the data to be reduced to a acceptable quality and quantity when displayed to the user


            //this first section is the sorting to determine unique points
            int x = 0;
            for (int i = 0; i < selectunique.Length; i++)
            {
                string unique = selectunique[i][0].ToString();
                
                if (unique != "X")
                {
                    //from here the data is aggragated
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
                        totlat = totlat + latency;
                    }
                    avelat = totlat / count;
                    int finalLat = Convert.ToInt32(selected[selected.Length - 1][2]) - Convert.ToInt32(selected[selected.Length - 1][1]);
                    if (finalLat < 0)
                    {
                        finalLat = 1000 + finalLat;
                    }
                    jitter = totPL / count;
                    int PL = Convert.ToInt32(selected[selected.Length - 1][8]);
                    //once the aggregation is done, there should be one data set produced with all of the required attributes
                    //this is then added to the data table

                    dt.Rows.Add(x, unique, finalLat, mnlat, mxlat, avelat, PL, jitter);
                }
            }
            //transferring the aggregated data into a dataset for versatility
            DataSet Dset = new DataSet();
            Dset.Clear();
            Dset.Tables.Add(dt);
            //binding the new dataset as the data source for the graph
            try
            {
                TRACETEXT.DataSource = dt;
            }
            catch
            {
                TRACETEXT.Invoke(new Action(() => TRACETEXT.DataSource = dt));
            }

            //This singular line sets all the data from the dataset dt to be the source of data for the chart
            NetworkInfoChart.DataSource = dt;

            //each pair or lines here refers to one lines to be plotted on the chart
            //the top lines are all similar due to all lines sharing one set of x axis values

            NetworkInfoChart.Series["Final Latency(ms)"].XValueMember = "Adress";
            NetworkInfoChart.Series["Final Latency(ms)"].YValueMembers = "Final latency(ms)";

            NetworkInfoChart.Series["Min Latency(ms)"].XValueMember = "Adress";
            NetworkInfoChart.Series["Min Latency(ms)"].YValueMembers = "Min latency(ms)";

            NetworkInfoChart.Series["Max Latency(ms)"].XValueMember = "Adress";
            NetworkInfoChart.Series["Max Latency(ms)"].YValueMembers = "Max latency(ms)";

            NetworkInfoChart.Series["Average Latency(ms)"].XValueMember = "Adress";
            NetworkInfoChart.Series["Average Latency(ms)"].YValueMembers = "average latency(ms)";

            NetworkInfoChart.Series["Packet loss"].XValueMember = "Adress";
            NetworkInfoChart.Series["Packet loss"].YValueMembers = "Packet Loss";

            NetworkInfoChart.Series["Jitter"].XValueMember = "Adress";
            NetworkInfoChart.Series["Jitter"].YValueMembers = "Jitter";
            try
            {
                NetworkInfoChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            }
            catch
            {
                NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.ChartAreas["ChartArea1"].AxisX.Interval = 1));
            }
            try
            {
                NetworkInfoChart.Update();
            }
            catch
            {
                NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Update()));
            }
        }
        
        private void UpdatePastData_Click(object sender, EventArgs e)
        {
            //the command behind the GUI control/button to refresh the small grid containing information on past tests
            pastupdate();
        }

        private void PastQuery_Click(object sender, EventArgs e)
        {
            //the control behind the query for the past test grid
            //the control takes the users input to query the database to return the data matching its parameters
            //use of regular expression to classify user input
            string host = PastAdress.Text.ToString();
            string date = PastDate.Text.ToString();
            string time = PastTime.Text.ToString();
            string past = PastCode.Text.ToString();
            
            //each set of indented code acts as the validation for one of the users inputs
            //use of regular expressions and potentially inequalities to validate the inputs
            if (host != "")
            {
                try
                {
                    //use of regular expression to classify user input
                    Regex ip = new Regex(@"\b{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
                    MatchCollection mcI = ip.Matches(host);
                    var test = mcI[0];

                }
                catch
                {
                    MessageBox.Show("The data entered for the Adress is not in IPV4 Form");
                    host = "";
                }
            }
            if(date != "")
            {
                try
                {
                    Regex Rdate = new Regex(@"\b\d{2}\/\d{2}\/\d{4}(\S\0{2}\:\0{2}\:\0{2})?$");
                    MatchCollection mcD = Rdate.Matches(date);
                    var test = mcD[0];
                }
                catch
                {
                    MessageBox.Show("The data entered for the Date is not in DD/MM/YYYY Form");
                    date = "";
                }
            }
            if(time != "")
            {
                try
                {
                    if (Convert.ToInt32(time) >= 0)
                    {
                        if (Convert.ToInt32(time) < 25)
                        {
                            try
                            {
                                Regex RTime = new Regex(@"\b\d\d?$");
                                MatchCollection mcT = RTime.Matches(time);
                                var test = mcT[0];
                            }
                            catch
                            {
                                MessageBox.Show("The data entered for the Time is not in 2-digit Form");
                                time = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("The data entered for the Time is invalid");
                            time = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("The data entered for the Time is not in 2-digit Form");
                        time = "";
                    }
                
                }
                catch
                {
                    MessageBox.Show("The data entered for the Time is not in 2-digit Form");
                    time = "";
                }


            }
            if (past != "")
            {
                try
                {
                    if (Convert.ToInt32(past) >= 0)
                    {
                        try
                        {
                            Regex Rdate = new Regex(@"\b\d+$");
                            MatchCollection mcP = Rdate.Matches(past);
                            var test = mcP[0];
                        }
                        catch
                        {
                            MessageBox.Show("The data entered for the code is not a valid posetive integer");
                            past = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("The data entered for the code is not a valid posetive integer");
                        past = "";
                    }
                }
                catch
                {
                    MessageBox.Show("The data entered for the code is not a valid posetive integer");
                    past = "";
                }
               
            }
            
            //creating datatable to store data coming from the database
            //if an incomplete series of data is input, too much data may be mistakenly selected and displayed
            DataTable pastquery = new DataTable();
            pastquery.Columns.Add("Adress", typeof(string));
            pastquery.Columns.Add("Date", typeof(string));
            pastquery.Columns.Add("Time", typeof(string));
            //creating the SQL query to fetch the data from the database
            SqlConnection con = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand buildpast = new SqlCommand("Select* from previous where convert(varchar, adress) like '%" + host + "%' and convert(varchar, date) like '%" + date + "%' and convert(varchar, time) like '%" + time + "%' and convert(varchar,code) like '%"+past+"%' order by code ");
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
            //clearing the data from both the graph and the data grid
            NetworkInfoChart.Series["Final Latency(ms)"].Points.Clear();
            NetworkInfoChart.Series["Min Latency(ms)"].Points.Clear();
            NetworkInfoChart.Series["Max Latency(ms)"].Points.Clear();
            NetworkInfoChart.Series["Average Latency(ms)"].Points.Clear();
            NetworkInfoChart.Series["Jitter"].Points.Clear();
            NetworkInfoChart.Series["Packet loss"].Points.Clear();
            TRACETEXT.DataSource = null;
            TRACETEXT.Update();
        }

        private void Cleandata_Click(object sender, EventArgs e)
        {
            //the command behind the control to clear the data for the GUI
            //Additionally re-enables other controls to allow the user access again
            ClearData();
            GraphAddress.ReadOnly = false;
            GraphDate.ReadOnly = false;
            GraphHour.ReadOnly = false;
            CODE.ReadOnly = false;
            TestConnectionButton.Enabled = true;
        }


        /// All following commands are the controls on the right hand side of the graph used to control the graph display
        /// each chunk of code represents one of the check boxes
       
        private void CheckPloss_CheckedChanged(object sender, EventArgs e)
        {
            if(NetworkInfoChart.Series["Packet loss"].Enabled == true)
            {
                NetworkInfoChart.Series["Packet loss"].Enabled = false;
            }
            else
            {
                NetworkInfoChart.Series["Packet loss"].Enabled = true;
            }
        }

        private void HideFinalLat_CheckedChanged(object sender, EventArgs e)
        {
            if (NetworkInfoChart.Series["Final Latency(ms)"].Enabled == true)
            {
                NetworkInfoChart.Series["Final Latency(ms)"].Enabled = false;
            }
            else
            {
                NetworkInfoChart.Series["Final Latency(ms)"].Enabled = true;
            }
        }

        private void HideMinimum_CheckedChanged(object sender, EventArgs e)
        {
            if (NetworkInfoChart.Series["Min Latency(ms)"].Enabled == true)
            {
                NetworkInfoChart.Series["Min Latency(ms)"].Enabled = false;
            }
            else
            {
                NetworkInfoChart.Series["Min Latency(ms)"].Enabled = true;
            }
        }

        private void HideMaximum_CheckedChanged(object sender, EventArgs e)
        {
            if (NetworkInfoChart.Series["Max Latency(ms)"].Enabled == true)
            {
                NetworkInfoChart.Series["Max Latency(ms)"].Enabled = false;
            }
            else
            {
                NetworkInfoChart.Series["Max Latency(ms)"].Enabled = true;
            }
        }

        private void HideAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (NetworkInfoChart.Series["Average Latency(ms)"].Enabled == true)
            {
                NetworkInfoChart.Series["Average Latency(ms)"].Enabled = false;
            }
            else
            {
                NetworkInfoChart.Series["Average Latency(ms)"].Enabled = true;
            }
        }

        private void HideJitter_CheckedChanged(object sender, EventArgs e)
        {
            if (NetworkInfoChart.Series["Jitter"].Enabled == true)
            {
                NetworkInfoChart.Series["Jitter"].Enabled = false;
            }
            else
            {
                NetworkInfoChart.Series["Jitter"].Enabled = true;
            }
        }
    }
}
