using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
	    public async Task<NetworkHop> TraceRoute(string target)
	    {
		    Stopwatch timer = new Stopwatch();
		    Stopwatch RTT = new Stopwatch();
		    timer.Start();
		    //The traceroute function, sending pings over a series of networks to create a traceroute and obtain critical diagnostic data about those networks
		    //and the stability of a connection made over them.
		    IPAddress ipAddress = Dns.GetHostAddresses(target)
				.First(address => address.AddressFamily == AddressFamily.InterNetwork);
			//the specifics of how the network ping will be use. each item needs to have been set correctly to ensure the data
            //fetched is accurate 
            //We use a 32 byte long message, with non-fragmenting paths chosen to ensure the same path is used for each ping
            //TTl is set to 1 to get 1 hop only, and max hops is set to 30 to limit the path length
            NetworkHop baseHop = new NetworkHop();
			NetworkHop pastHop = new NetworkHop();
			int maxHops = 30;
			for (int i = 0; i < maxHops + 1; i++)
			{
				//using a stopwatch to determine the time for the ping to be received
				RTT.Reset();
				RTT.Start();
				PingReply pingReply = pingSender.Send(ipAddress.ToString(),100,buffer, options);
				RTT.Stop();
				int packetLoss = await Task.Factory.StartNew(
	                () => PacketLoss(ipAddress.ToString(), buffer),
	                TaskCreationOptions.None);
				
                NetworkHop hop = new NetworkHop(pingReply.Address.MapToIPv4(), i+1, Convert.ToInt32(RTT.ElapsedMilliseconds), packetLoss);
                
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
	                timer.Stop();
	                Debug.WriteLine("Elapsed {0}ms for test",timer.ElapsedMilliseconds);
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
	    public int PacketLoss(string target, byte[] buffer)
	    {
		    //breakout method used to check the packet loss of each individual node on the route
		    //it works by taking the address of the hop found above and pinging it 5 more times. the number of failed pings are multiplied by 20 to generate packet loss as a percentage
		    Ping plSender = new Ping();
		    PingOptions options = new PingOptions();
		    options.DontFragment = true;
		    int failed = 0;
		    //send 5 pings to the given address
		    for (int packet = 0; packet< 5; packet++)
		    {
			    PingReply loss = plSender.Send(target, 100, buffer, options);
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
