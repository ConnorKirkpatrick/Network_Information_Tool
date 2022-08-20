using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Net;
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
        private NetworkMethods NetworkMethods = new NetworkMethods();
        private SQLConnection SQLConn = new SQLConnection();
        static System.Timers.Timer Time;
        static System.Timers.Timer Holder;

        private bool testActive = false;
        private bool testFinished = true;
        private NetworkHop baseHop;
        private String code;
        public UiForm()
        {
            //This is the code executed when the "main()" function calls for Form1
            //the initial code sets up all the objects and forces some to be disabled initially
            InitializeComponent();
            ChangeParametersButton.Enabled = false;
            StartTestButton.Enabled = false;
            HaltButton.Enabled = false;

            //Testing connection to the SQL database
            Task<bool> result = Task<bool>.Factory.StartNew(() => SQLConn.testConnection());
            if (!result.Result)
            {
                MessageBox.Show("Error reaching server");
            }
            
            //setup the chart
            NetworkInfoChart.Series["Latency(ms)"].XValueMember = "Address";
            NetworkInfoChart.Series["Latency(ms)"].YValueMembers = "Latency(ms)";
            
            NetworkInfoChart.Series["Average Latency(ms)"].XValueMember = "Address";
            NetworkInfoChart.Series["Average Latency(ms)"].YValueMembers = "Average Latency(ms)";

            NetworkInfoChart.Series["Min Latency(ms)"].XValueMember = "Address";
            NetworkInfoChart.Series["Min Latency(ms)"].YValueMembers = "Min latency(ms)";

            NetworkInfoChart.Series["Max Latency(ms)"].XValueMember = "Address";
            NetworkInfoChart.Series["Max Latency(ms)"].YValueMembers = "Max latency(ms)";

            NetworkInfoChart.Series["Packet loss"].XValueMember = "Address";
            NetworkInfoChart.Series["Packet loss"].YValueMembers = "Packet Loss";

            NetworkInfoChart.Series["Jitter"].XValueMember = "Address";
            NetworkInfoChart.Series["Jitter"].YValueMembers = "Jitter";
            NetworkInfoChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            NetworkInfoChart.Update();
            
            //setup the past data view
            PastDataUpdate();

            /*
            Address.Text = "8.8.8.8";
            Interval.Text = "500";
            TestConn_Click(null, null);
            Start_Click(null,null);
            */

        }

        public async void PastDataUpdate()
        {
            //grab the data from the sql and generate an concise version of the data to display
            //code, target address, number of hops, average ping&PL of the target
            
            //select unique list of id's
            //query id, rip address from code, grab max for other parameters
            DataTable pastResults = new DataTable();
            pastResults.Columns.Add("ID", typeof(string));
            pastResults.Columns.Add("Address", typeof(string));
            pastResults.Columns.Add("Path Length", typeof(int));
            pastResults.Columns.Add("Average Latency", typeof(int));
            pastResults.Columns.Add("Average Packet Loss", typeof(int));
            SQLiteCommand selectIDs = SQLConn.getCmd();
            selectIDs.CommandText = "SELECT DISTINCT id FROM testData";
            DataTable idResults = await SQLConn.getData(selectIDs);
            Debug.WriteLine("Results: ");
            foreach (DataRow row in idResults.Rows)
            {
                Debug.WriteLine(row[idResults.Columns[0]]);
                SQLiteCommand selectAverages = SQLConn.getCmd();
                selectAverages.CommandText =
                    "SELECT Host, Seq, AverageLatency, AverageLoss FROM testData ORDER BY Seq DESC LIMIT 1";
                DataTable averageResults = await SQLConn.getData(selectAverages);
                DataRow r = pastResults.NewRow();
                r["ID"] = row[idResults.Columns[0]];
                r["Address"] = averageResults.Rows[0]["Host"];
                r["Path Length"] = averageResults.Rows[0]["Seq"];
                r["Average Latency"] = Convert.ToInt32(averageResults.Rows[0]["AverageLatency"]);
                r["Average Packet Loss"] = Convert.ToInt32(averageResults.Rows[0]["AverageLoss"]);
                pastResults.Rows.Add(r);
            }

            PastData.DataSource = pastResults;
            PastData.Update();

        }


		private async void TestConn_Click(object sender, EventArgs e)
		{
            //Check user parameters are correct, set parameters to read-only while checking
            Address.ReadOnly = true;
            Interval.ReadOnly = true; 
            //check that the IP is valid
            try
            {
                IPAddress.Parse(Address.Text);
            }
            catch
            {
                MessageBox.Show("Invalid IP address");
                Address.ReadOnly = false;
                Interval.ReadOnly = false; 
                return;
            }
            //check that the interval is both a valid integer and >= to 500ms
            try
            {
                if (Convert.ToInt32(Interval.Text) < 500)
                {
                    MessageBox.Show("Minimum interval is 500ms");
                    Address.ReadOnly = false;
                    Interval.ReadOnly = false; 
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Invalid Interval entered");
                Address.ReadOnly = false;
                Interval.ReadOnly = false; 
                return;
            }
            TestConnectionButton.Enabled = false;
            ChangeParametersButton.Enabled = true;
            StartTestButton.Enabled = true;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            bool netStatus = await NetworkMethods.Ping(Address.Text);
            if (netStatus)
            {
                ConnStat.Text = "Connected to " + Address.Text;
            }
            else
            {
                ConnStat.Text = "Failed to connect to " + Address.Text;
                StartTestButton.Enabled = false;
                Interval.ReadOnly = false;
                Address.ReadOnly = false;
                ChangeParametersButton.Enabled = true;
                TestConnectionButton.Enabled = true;
            }
            stopWatch.Stop();
            Debug.WriteLine("Conn test completed in: {0}ms",stopWatch.ElapsedMilliseconds);
        }

		private void label2_Click(object sender, EventArgs e)
		{}
        /// <summary>
        /// Function callwed when a user clicks the start test button. Used to initiate the testing cycle by:
        /// Locking out user controls that could interfere with the test such as the Address and Interval text boxes
        /// Enables the buttons used to halt the test
        /// Performs a trace route to the target address to get each node
        /// performs pings against each node at the selected interval and updates the result to the chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void  Start_Click(object sender, EventArgs e)
		{
            //ensure the chart area is clear of old data
            Clear();
            
            //generate the test code

            code = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + " " + Address.Text;

            //Update all Ui elements to reflect that the test is currently active and disable conflicting controls
            SyncToGraphButton.Enabled = false;
            TestStat.Text = "Running";
			StartTestButton.Enabled = false;
			ChangeParametersButton.Enabled = false;
			HaltButton.Enabled = true;
            
            testActive = true;
            testFinished = false;
            
            Debug.WriteLine("Starting net test");
            //run this as a thread pool
            //we maintain a object that stores min/max for each hop and aggregates the data before it goes onto the graph
            baseHop = await NetworkMethods.TraceRoute(Address.Text);
            NetworkHop nextHop = baseHop;
            while (true)
            {
                Debug.WriteLine("Seq: {0} Host: {1} Latency: {2}ms PacketLoss: {3}%",nextHop.SequenceNumber,nextHop.Ipv4Address, nextHop.Latency, nextHop.PacketLoss);
                NetworkInfoChart.Series["Latency(ms)"].Points.AddXY(nextHop.Ipv4Address.ToString(), nextHop.Latency);
                NetworkInfoChart.Series["Average Latency(ms)"].Points.AddXY(nextHop.Ipv4Address.ToString(), nextHop.AverageLatency);
                NetworkInfoChart.Series["Min Latency(ms)"].Points.AddXY(nextHop.Ipv4Address.ToString(), nextHop.MinLatency);
                NetworkInfoChart.Series["Max Latency(ms)"].Points.AddXY(nextHop.Ipv4Address.ToString(), nextHop.MaxLatency);
                NetworkInfoChart.Series["Packet loss"].Points.AddXY(nextHop.Ipv4Address.ToString(), nextHop.PacketLoss);
                NetworkInfoChart.Series["Jitter"].Points.AddXY(nextHop.Ipv4Address.ToString(), nextHop.MaxLoss - nextHop.MinLoss);
                NetworkInfoChart.Refresh();
                if (nextHop.NextNode == null)
                {
                    break;
                }
                nextHop = nextHop.NextNode;
            }
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            
            
            Debug.WriteLine("Current Starting IP: {0}",nextHop.Ipv4Address);
            await Task.Run(() => 
            {
                runTest(Interval.Text);
            });
        }
        /// <summary>
        /// The test function that performs the repeated loop to update the information on each hop after a given interval
        /// it is setup to be called asynchronously so that the loop will not halt the main ui thread
        /// it calls each ping update on a new thread to increase performance
        /// </summary>
        /// <param name="interval">The interval at which to ping each hop for new data</param>
        private void runTest(String interval)
        {
            NetworkHop nextHop = baseHop;
            while (testActive)
            {
                while (true)
                {
                    ThreadPool.QueueUserWorkItem(UpdateHop, nextHop);
                    if (nextHop.SequenceNumber == 1)
                    {
                        baseHop = nextHop;
                    }
                    else if(nextHop.NextNode == null)
                    {
                        break;
                    }
                    nextHop = nextHop.NextNode;
                }
                NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Update()));
                nextHop = baseHop;
                Thread.Sleep(Convert.ToInt32(interval));
            }
            Debug.WriteLine("TESTING ENDED");
            testFinished = true;

        }
        /// <summary>
        /// This method does the actual work on updating the node information via ICMP pings and updates the chart
        /// </summary>
        /// <param name="hop">The hop object to update</param>
        public async void UpdateHop(Object hop)
        {
            NetworkHop nextHop = (NetworkHop)hop;
            //check that the test has not been halted before running expensive ping request
            if (!testActive)
            {
                return;
            }
            nextHop = await NetworkMethods.UpdatePing(nextHop);
            //check that the test hasn't been halted during the wait for the ping 
            if (!testActive)
            {
                return;
            }
            Debug.WriteLine("Seq: {0} Host: {1} Latency: {2}ms PacketLoss: {3}%",nextHop.SequenceNumber,nextHop.Ipv4Address, nextHop.Latency, nextHop.PacketLoss);
            NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Series["Latency(ms)"].Points[nextHop.SequenceNumber-1].SetValueY(nextHop.Latency)));
            NetworkInfoChart.Invoke(new Action(() =>
                NetworkInfoChart.Series["Average Latency(ms)"].Points[nextHop.SequenceNumber-1].SetValueY(nextHop.AverageLatency)));
            NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Series["Min Latency(ms)"].Points[nextHop.SequenceNumber-1].SetValueY(nextHop.MinLatency)));
            NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Series["Max Latency(ms)"].Points[nextHop.SequenceNumber-1].SetValueY(nextHop.MaxLatency)));
            NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Series["Packet loss"].Points[nextHop.SequenceNumber-1].SetValueY(nextHop.PacketLoss)));
            //jitter is calculated as the delta between the maximum and minimum packet loss observed
            NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Series["Jitter"].Points[nextHop.SequenceNumber-1].SetValueY(nextHop.MaxLoss - nextHop.MinLoss)));
            NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.Refresh()));
            NetworkInfoChart.Invoke(new Action(() => NetworkInfoChart.ChartAreas[0].RecalculateAxesScale()));
            
            if (nextHop.SequenceNumber == 1)
            {
                //overwrite the baseHop
                baseHop = nextHop;
            }
            else
            {
                NetworkHop replaceHop = baseHop;
                for (int i = 0; i < nextHop.SequenceNumber; i++)
                {
                    replaceHop = replaceHop.NextNode;
                }
                replaceHop = nextHop;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            testActive = false;
            TestStat.Text = "Uploading to Database...";
            await Task.Run(() => 
            {
                //need to await "TESTINGENDED" to set some flag to be true
                //once true, allow the generation of IP and time to be made
                //then upload results to database
                //generate date-Time-IP address as a unique ID for the test
                while(!testFinished){}

                NetworkHop hop = baseHop;
                while (true)
                {
                    //add the data to the sql
                    //for past data, we probably only care about average, max and min values. everything else is just nice to have in the moment
                    SQLiteCommand setDataCmd = SQLConn.getCmd();
                    setDataCmd.CommandText =
                        "INSERT INTO testData(ID, Seq, Host, AverageLatency, MaxLatency, MinLatency, AverageLoss, MaxLoss, MinLoss) VALUES (@code,@seq,@hop,@aveLat,@maxLat,@minLat,@aveLoss,@maxLoss,@minLoss)";
                    setDataCmd.Parameters.Add(new SQLiteParameter("@code", code) );
                    setDataCmd.Parameters.Add(new SQLiteParameter("@seq", hop.SequenceNumber));
                    setDataCmd.Parameters.Add(new SQLiteParameter("@hop" ,hop.Ipv4Address.ToString()));
                    setDataCmd.Parameters.Add(new SQLiteParameter("@aveLat", hop.AverageLatency));
                    setDataCmd.Parameters.Add(new SQLiteParameter("@maxLat",hop.MaxLatency));
                    setDataCmd.Parameters.Add(new SQLiteParameter("@minLat",hop.MinLatency));
                    setDataCmd.Parameters.Add(new SQLiteParameter("@aveLoss", hop.PacketLoss));
                    setDataCmd.Parameters.Add(new SQLiteParameter("@maxLoss",hop.MaxLoss));
                    setDataCmd.Parameters.Add(new SQLiteParameter("@minLoss",hop.MinLoss));
                    SQLConn.setData(setDataCmd);
                    if(hop.NextNode == null){
                        break;
                    }
                    hop = hop.NextNode;
                    
                }
                //re-enable the system controls
                HaltButton.Invoke(new Action(() => HaltButton.Enabled = false));
                StartTestButton.Invoke(new Action(() => StartTestButton.Enabled = true));
                ChangeParametersButton.Invoke(new Action(() => ChangeParametersButton.Enabled = true));
                TestStat.Invoke(new Action(() => TestStat.Text = "Not Running"));
                PastDataUpdate();
            });
            
            


        }
        /// <summary>
        /// Small function used to clear existing point data from the NetworkInfoChart object
        /// </summary>
        public void Clear()
        {
            //clearing the graph, invokes used due to multiple threads in execution
            NetworkInfoChart.Series["Latency(ms)"].Points.Clear();
            NetworkInfoChart.Series["Average Latency(ms)"].Points.Clear();
            NetworkInfoChart.Series["Min Latency(ms)"].Points.Clear();
            NetworkInfoChart.Series["Max Latency(ms)"].Points.Clear();
            NetworkInfoChart.Series["Packet loss"].Points.Clear();
            NetworkInfoChart.Series["Jitter"].Points.Clear();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void Sync_Click(object sender, EventArgs e)
        {
            //Grab data for a given test and add it to the graph
           
        }
        
        private void Change_Click(object sender, EventArgs e)
        {
            //enabling and disabling specific buttons when the user opts to change the target address or interval.
            Address.ReadOnly = false;
            Interval.ReadOnly = false;
            StartTestButton.Enabled = false;
            HaltButton.Enabled = false;
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

        private void UpdatePastData_Click(object sender, EventArgs e)
        {
            //the command behind the GUI control/button to refresh the small grid containing information on past tests
            PastDataUpdate();
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
            Clear();
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
