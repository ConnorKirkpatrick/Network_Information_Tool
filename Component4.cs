using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;

namespace Network_Tool
{
	public partial class Component4 : Component
	{
		public Component4()
		{
			InitializeComponent();
		}
		public Component4(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		public static int Traceroute(string Adress, string Interval)
		{
            ///The traceroute function, sending pings over a series of networks to create a traceroute and obtain critical diagnostic data about those networks
            ///and the stability of a connection made over them.
            int counter = 0;
			string test = null;
			IPAddress ipAddress = Dns.GetHostEntry(Adress).AddressList[0];
			StringBuilder traceResults = new StringBuilder();
			using (Ping pingSender = new Ping())
			{
				PingOptions pingOptions = new PingOptions();
				Stopwatch stopWatch = new Stopwatch();
				string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
				byte[] buffer = Encoding.ASCII.GetBytes(data);
				pingOptions.DontFragment = true;
				pingOptions.Ttl = 1;
				int maxHops = 30;
				traceResults.AppendLine();
				
				for (int i = 0; i < maxHops + 1; i++)
				{
                    //using a stopwatch to determine the time for the ping to be recived
					stopWatch.Reset();
					stopWatch.Start();
                    string send = DateTime.Now.Millisecond.ToString();
					PingReply pingReply = pingSender.Send(ipAddress.ToString(),Convert.ToInt32(Interval),new byte[32], pingOptions);
					stopWatch.Stop();
                    string recive = DateTime.Now.Millisecond.ToString();
					
					traceResults.AppendLine(string.Format("{0}\t{1} ms\t{2}", i, stopWatch.ElapsedMilliseconds, pingReply.Address));

                    int packetloss = 0;
                    int failed = 0;
                    Ping requestpackets = new Ping();
                    PingOptions options = new PingOptions();
                    options.DontFragment = true;
                    int timeout = Convert.ToInt32(Interval);
                    for (int packet = 0; packet< 10; packet++)
                    {
                        PingReply loss = pingSender.Send(Adress, timeout, buffer, options);
                        if (loss.Status != IPStatus.Success)
                        {
                            failed += 1;
                        }
                    }
                    packetloss = failed * 10;
                    SqlConnection con = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    try
                    {
                        con.Open();
                    }
                    catch
                    {
                        MessageBox.Show("Database error");
                    }
                    con.Close();
                    try
                    {
                        //adding data to the volatile table on the database
                        test = pingReply.Address.ToString();
                        SqlDataAdapter add = new SqlDataAdapter();
                        add.InsertCommand = new SqlCommand("insert into Hops(Hop, adress, Send, Receive, packetloss, seq) values (@hop, @add, @send, @receive, @packetloss, @seq)", con);
                        add.InsertCommand.Parameters.Add("@hop", SqlDbType.Int).Value = i;
                        add.InsertCommand.Parameters.Add("@add", SqlDbType.Text).Value = test;
                        add.InsertCommand.Parameters.Add("@send", SqlDbType.Text).Value = send;
                        add.InsertCommand.Parameters.Add("@receive", SqlDbType.Text).Value = recive;
                        add.InsertCommand.Parameters.Add("@packetloss", SqlDbType.Int).Value = packetloss;
                        add.InsertCommand.Parameters.Add("@seq", SqlDbType.Int).Value = i;
                        con.Open();
                        add.InsertCommand.ExecuteNonQuery();
                        con.Close();
                        counter += 1;
                    }
                    catch
                    {
                        SqlDataAdapter add = new SqlDataAdapter();
                        add.InsertCommand = new SqlCommand("insert into Hops(Hop, adress, Send, Receive, packetloss, seq) values (@hop, @add, @send, @receive, @packetloss, @seq)", con);
                        add.InsertCommand.Parameters.Add("@hop", SqlDbType.Int).Value = i;
                        add.InsertCommand.Parameters.Add("@add", SqlDbType.Text).Value = "X";
                        add.InsertCommand.Parameters.Add("@send", SqlDbType.Text).Value = send;
                        add.InsertCommand.Parameters.Add("@receive", SqlDbType.Text).Value = recive;
                        add.InsertCommand.Parameters.Add("@packetloss", SqlDbType.Int).Value = packetloss;
                        add.InsertCommand.Parameters.Add("@seq", SqlDbType.Int).Value = i;
                        con.Open();
                        add.InsertCommand.ExecuteNonQuery();
                        con.Close();
                        counter += 1;
                    }

					if (pingReply.Status == IPStatus.Success)
					{
						traceResults.AppendLine();
						traceResults.AppendLine("Trace complete.");
                        break;
                    }
					pingOptions.Ttl++;
				}
			}
            return counter;

		}
	}
}
