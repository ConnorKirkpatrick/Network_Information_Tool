using System.Threading.Tasks;
using System.Windows.Forms;

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
			//calling Form1 to execute on the main thread
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new UiForm());
			/*
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
			*/
		}
	}
}
