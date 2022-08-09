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
    public class NetworkMethods
    {
	    public async Task<string[][]> TraceRoute(string target, string interval)
	    {
		    //The traceroute function, sending pings over a series of networks to create a traceroute and obtain critical diagnostic data about those networks
		    //and the stability of a connection made over them.
		    int counter = 0;
			string ping = null;
			IPAddress ipAddress = Dns.GetHostAddresses(target)
				.First(address => address.AddressFamily == AddressFamily.InterNetwork);
			Ping pingSender = new Ping();
			//the specifics of how the network ping will be use. each item needs to have been set correctly to ensure the data
            //fetched is accurate 
            //We use a 32 byte long message, with non-fragmenting paths chosen to ensure the same path is used for each ping
            //TTl is set to 1 to get 1 hop only, and max hops is set to 30 to limit the path length
			PingOptions pingOptions = new PingOptions();
			Stopwatch stopWatch = new Stopwatch();
			string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
			byte[] buffer = Encoding.ASCII.GetBytes(data);
			pingOptions.DontFragment = true;
			pingOptions.Ttl = 1;
			int maxHops = 30;


			string[] addresses = new string[30];
			string[] packetLosses = new string[30];
			string[] length = new string[1];
			string[][] netData = new string[][] {addresses,packetLosses,length};
			
			for (int i = 0; i < maxHops + 1; i++)
			{
				//using a stopwatch to determine the time for the ping to be received
				stopWatch.Reset();
				stopWatch.Start();
                string send = DateTime.Now.Millisecond.ToString();
                PingReply pingReply = pingSender.Send(ipAddress.ToString(),Convert.ToInt32(interval),buffer, pingOptions);
				stopWatch.Stop();
                string receive = DateTime.Now.Millisecond.ToString();
                if (pingReply.Status.ToString() != "TimedOut")
                {
	                addresses[i] = pingReply.Address.MapToIPv4().ToString();
                }
                else
                {
	                addresses[i] = pingReply.Status.ToString();
                }
                
                int packetLoss = await Task.Factory.StartNew(
	                () => PacketLoss(ipAddress.ToString(), Convert.ToInt32(interval), buffer),
	                TaskCreationOptions.None);
                packetLosses[i] = packetLoss.ToString();
                
                if (pingReply.Status == IPStatus.Success)
                {
	                length[0] = i.ToString();
					return netData;
				}
				pingOptions.Ttl++;
			}
			Debug.WriteLine("TraceRoute failed");
			return null;
	    }

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
    }
}
