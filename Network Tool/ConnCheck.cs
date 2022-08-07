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
        /// <summary>
        /// the namespace acts as an identifier for all components of this program to keep them isolated from other programs
        /// Seen above are all the class libraries imported for each sub class. these are inhereted but I have overridden them in the other components to increase efficiency
        /// </summary>
        public Component2()
		{
			InitializeComponent();
		}

		public Component2(IContainer container)
		{
            //this container function acts to encapsulate programs executed inside of it
            //The component is added to the encapsulation and initialzied again to reset it in the isolated environment
            container.Add(this);
			InitializeComponent();
		}

        public static bool TestDatabase(string Adress,string Date, int Hour)
        {
            //Function called to test whether the user parameters are inside the database
            bool value = false;
            //creating an SQL query to fetch the data from the database
            SqlConnection Conn = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //testing if the connection the the database is available
            try
            {
                Conn.Open();
            }
            catch
            {
                value = false;
            }
            SqlCommand Select = new SqlCommand("select distinct CONVERT(varchar,Host),CONVERT(varchar,date),CONVERT(varchar,time) from data");
            Select.Connection = Conn;
            Select.CommandType = CommandType.Text;
            DataTable unique = new DataTable();
            SqlDataAdapter fill = new SqlDataAdapter(Select);

            fill.Fill(unique);
            Conn.Close();
            //testing the data for the users parameters
            for(int I = 0; I<unique.Rows.Count; I++)
            {
                if(unique.Rows[I][0].ToString() == Adress)
                {
                    if (unique.Rows[I][1].ToString() == Date)
                    {
                        Console.WriteLine((unique.Rows[I][2]) + " ");
                        Console.WriteLine(Hour + " " + Hour.GetType());
                        if (Convert.ToInt32(unique.Rows[I][2]) == Convert.ToInt32(Hour))
                        {
                            value = true;
                        }
                    }
                }
            }
            return value;
        }

		public static int Testcon(string Address, string Interval)
		{
            //series of tests to determine if the user input is valid, each test returns a different numerical value.
            //the system sends a single ping to the address to check it is up. The outcome of this test is returned as either 0,1 or 2
			try
			{
                //creating the network ping to determine if the users specified address is available
				Ping ping = new Ping();
				string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
				byte[] buffer = Encoding.ASCII.GetBytes(data);
				PingOptions options = new PingOptions();
				options.DontFragment = true;
				PingReply reply = ping.Send(Address, Convert.ToInt32(Interval), buffer, options);

                //these return values can change the next process of the program depending on the value returned
                //each return relates to a specific error or lack there-of
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
