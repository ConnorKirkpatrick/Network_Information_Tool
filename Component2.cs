using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net.NetworkInformation;
using System.Data.SqlClient;

namespace Network_Tool
{
	public partial class Component2 : Component
	{
		public Component2()
		{
			InitializeComponent();
		}

		public Component2(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		public static int Testcon(string Adress, string Interval)
		{
            ///series of tests to determine if the user input is valid, each test returns a different numerical value.
            ///the system sends a single ping to the adress to check it is up. The outscome of this test is returned as either 0,1 or 2
			try
			{
				Ping ping = new Ping();
				string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
				byte[] buffer = Encoding.ASCII.GetBytes(data);
				PingOptions options = new PingOptions();
				options.DontFragment = true;
				PingReply reply = ping.Send(Adress, Convert.ToInt32(Interval), buffer, options);

				if (reply.Status == IPStatus.Success)
				{
					return 0;
				}
				else
				{
					return 1;
				}
			}
			catch
			{
				return 2;
			}
		}
	}
}
