using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Network_Tool.NetworkingMethods
{
	/// <summary>
	/// Class <c>NetworkMethods</c> Provides access to multiple methods created for performing network Pings, Trace routes and packet loss calculations
	/// </summary>
    public class NetworkMethods
	{

		private Ping pingSender;
		private byte[] buffer;
		private PingOptions options;
		
		public NetworkMethods()
		{
			this.pingSender = new Ping();
			this.options = new PingOptions();
			string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
			this.buffer = Encoding.ASCII.GetBytes(data);
			options.DontFragment = true;
			options.Ttl = 1;
		}
	    
	    
	    /// <summary>
	    /// This method generates a traceroute to a given address along with data such as packet loss and ping time
	    /// </summary>
	    /// <param name="target">The target ipv4 as a string</param>
	    /// <param name="interval">The time interval in ms between each ping</param>
	    /// <returns>A Array of Arrays containing information such as packet loss, address, time to ping</returns>
	    public async Task<NetworkHop> TraceRoute(string target, string interval)
	    {
		    //The traceroute function, sending pings over a series of networks to create a traceroute and obtain critical diagnostic data about those networks
		    //and the stability of a connection made over them.
		    int counter = 0;
			string ping = null;
			IPAddress ipAddress = Dns.GetHostAddresses(target)
				.First(address => address.AddressFamily == AddressFamily.InterNetwork);
			//the specifics of how the network ping will be use. each item needs to have been set correctly to ensure the data
            //fetched is accurate 
            //We use a 32 byte long message, with non-fragmenting paths chosen to ensure the same path is used for each ping
            //TTl is set to 1 to get 1 hop only, and max hops is set to 30 to limit the path length
            Stopwatch stopWatch = new Stopwatch();
			

			NetworkHop baseHop = new NetworkHop();
			NetworkHop pastHop = new NetworkHop();
			int maxHops = 30;
			for (int i = 0; i < maxHops + 1; i++)
			{
				NetworkHop hop = new NetworkHop();
				hop.SequenceNumber = i;
				//using a stopwatch to determine the time for the ping to be received
				stopWatch.Reset();
				stopWatch.Start();
                int send = DateTime.Now.Millisecond;
                PingReply pingReply = pingSender.Send(ipAddress.ToString(),Convert.ToInt32(interval),buffer, options);
				stopWatch.Stop();
				int receive = DateTime.Now.Millisecond;
				hop.Latency = receive - send;
                if (pingReply.Status.ToString() != "TimedOut")
                {
	                hop.Ipv4Address = pingReply.Address.MapToIPv4();
                }
                else
                {
	                hop.Ipv4Address = IPAddress.Parse("0.0.0.0");
                }
                
                int packetLoss = await Task.Factory.StartNew(
	                () => PacketLoss(ipAddress.ToString(), Convert.ToInt32(interval), buffer),
	                TaskCreationOptions.None);
                hop.PacketLoss = packetLoss;

                if (i == 0)
                {
	                baseHop = hop;
	                pastHop = hop;
                }
                else
                {
	                hop.PreviousNode = pastHop;
	                pastHop.NextNode = hop;
	                pastHop = hop;
                }
                
                if (pingReply.Status == IPStatus.Success)
                {
	                return baseHop;
				}
				options.Ttl++;
			}
			Debug.WriteLine("TraceRoute failed");
			return null;
	    }
		/// <summary>
		/// Packet loss measurement system, utilises another thread to prevent blocking the traceroute process
		/// </summary>
		/// <param name="target">Targeted ipv4 address for packet loss testing</param>
		/// <param name="interval">Time interval in ms between each ping</param>
		/// <param name="buffer">Buffer of data to send as the ping</param>
		/// <returns>integer representing the percentage of messages dropped </returns>
	    private int PacketLoss(string target, int interval, byte[] buffer)
	    {
		    //breakout method used to check the packet loss of each individual node on the route
		    //it works by taking the address of the hop found above and pinging it 5 more times. the number of failed pings are multiplied by 20 to generate packet loss as a percentage
		    Ping plSender = new Ping();
		    PingOptions options = new PingOptions();
		    options.DontFragment = true;
		    int failed = 0;
		    int timeout = Convert.ToInt32(interval);
		    //send 5 pings to the given address
		    for (int packet = 0; packet< 5; packet++)
		    {
			    PingReply loss = plSender.Send(target, timeout, buffer, options);
			    if (loss.Status != IPStatus.Success)
			    {
				    failed += 1;
			    }
		    }
			//return the calculated packet loss
		    return failed * 20;
	    }

		public async Task<bool> Ping(string target)
		{
			options.Ttl = 30;
			PingReply pingReply = pingSender.Send(target,10,buffer, options);
			options.Ttl = 1;
			return (pingReply.Address.ToString() == target & pingReply.Status.ToString() == "Success");

		}
    }
}
