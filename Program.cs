using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SQLite;
using Network_Tool.NetworkingMethods;


namespace Network_Tool
{
    /// <summary>
    /// Creating the program class
    /// </summary>
	class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		public static async Task Main(string[] args)
		{
			/*
			//calling Form1 to execute
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
			*/
			NetworkMethods netTools = new NetworkMethods();
			NetworkHop baseHop = await netTools.TraceRoute("8.8.8.8", "500");
			while (true)
			{
				Debug.WriteLine("Seq: {0} Host: {1} Latency: {2}ms PacketLoss: {3}%",baseHop.SequenceNumber,baseHop.Ipv4Address, baseHop.Latency, baseHop.PacketLoss);
				if (baseHop.NextNode == null)
				{
					break;
				}

				baseHop = baseHop.NextNode;
			}
		}
	}
}
