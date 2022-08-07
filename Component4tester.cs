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

		public static void Traceroute(string Target, string Interval, int tick)
		{
            ///The traceroute function, sending pings over a series of networks to create a traceroute and obtain critical diagnostic data about those networks
            ///and the stability of a connection made over them.
            
            ///creating of the datatable that will be used to pass stored data between component layers
            DataTable Hops = new DataTable();
            Hops.Columns.Add("hop", typeof(int));
            Hops.Columns.Add("add", typeof(string));
            Hops.Columns.Add("send", typeof(int));
            Hops.Columns.Add("recieve", typeof(int));
            Hops.Columns.Add("packetloss", typeof(int));
            Hops.Columns.Add("seq", typeof(int));

            ///this part of the code is responsible for the pings over the network and building the traceroute
            int counter = 0;
			string ping = null;
			IPAddress ipAddress = Dns.GetHostEntry(Target).AddressList[0];
			StringBuilder traceResults = new StringBuilder();
			using (Ping pingSender = new Ping())
			{
                ///the specifics of how the network ping will be use. each item needs to have been set correcly to ensure the data
                ///fetched is accurate 
				PingOptions pingOptions = new PingOptions();
				Stopwatch stopWatch = new Stopwatch();
				string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
				byte[] buffer = Encoding.ASCII.GetBytes(data);
				pingOptions.DontFragment = true;
				pingOptions.Ttl = 1;
				int maxHops = 30;
                

                
                for (int i = 0; i < maxHops + 1; i++)
				{
                    
                    ///using a stopwatch to determine the time for the ping to be recived
					stopWatch.Reset();
					stopWatch.Start();
                    string send = DateTime.Now.Millisecond.ToString();
					PingReply pingReply = pingSender.Send(ipAddress.ToString(),Convert.ToInt32(Interval),new byte[32], pingOptions);
					stopWatch.Stop();
                    string recive = DateTime.Now.Millisecond.ToString();
					
                    ///the code responsible for generating the packetloss
                    ///it works by taking the adress of the hop found above and pinging it 5 more times. the number of failed pings are multiplied by 20 to generate packetloss as a percentage
                    int packetloss = 0;
                    int failed = 0;
                    Ping requestpackets = new Ping();
                    PingOptions options = new PingOptions();
                    options.DontFragment = true;
                    int timeout = Convert.ToInt32(Interval);
                    for (int packet = 0; packet< 5; packet++)
                    {
                        PingReply loss = pingSender.Send(Target, timeout, buffer, options);
                        if (loss.Status != IPStatus.Success)
                        {
                            failed += 1;
                        }
                    }
                    packetloss = failed * 20;

                    try
                    {
                        //adding data to the datatable mentioned above
                        ping = pingReply.Address.ToString();
                        int hop = i;
                        Hops.Rows.Add(hop, ping, send, recive, packetloss, i);
                        counter += 1;
                        Component3.runtime(Hops, counter, Target, tick);
                    }
                    catch
                    {
                        int hop = i;
                        Hops.Rows.Add(hop, ping, send, recive, packetloss, i);
                        counter += 1;
                        Component3.runtime(Hops, counter, Target, tick);
                    }

					if (pingReply.Status == IPStatus.Success)
					{
                        break;
                    }
					pingOptions.Ttl++;
				}
			}
            
		}
	}
}
