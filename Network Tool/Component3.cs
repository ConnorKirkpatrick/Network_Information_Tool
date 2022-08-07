using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Network_Tool
{
    public partial class Component3 : Component
	{
        
		public Component3()
		{
			InitializeComponent();
		}

		public Component3(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
        public static void Times(string Adress, string Interval, int tick)
        {
            
            ///function to take the data from the volatile database and combine it with metadata ready to be added to the main database "DATA"
            Component4.Traceroute(Adress, Interval, tick);
        }
        public static void runtime(DataTable Hops, int count, string target, int tick)
        {
            ///data coming from the datatable "dat" is sorted into accending order 
            DataView sorted = new DataView(Hops);
            sorted.Sort = "hop ASC";
            SqlConnection connection = new SqlConnection("Data Source=databaseconn.database.windows.net;Initial Catalog=database conn;Integrated Security=False;User ID=ADMIN!;Password=ABCDEFG1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //iterating through the table to select the rows of data and add them, along with extra data, to the main database
            for (int Hopnum = 0; Hopnum < count; Hopnum++)
            {
                DataRow[] test;
                string query = "hop = "+(Hopnum).ToString();
                test = sorted.Table.Select(query);
                foreach(DataRow row in test)
                {
                    if(row[0].ToString() != "")
                    {
                        string hop = row[0].ToString();
                        string Adress = row[1].ToString();
                        int sent = Convert.ToInt32(row[2]);
                        int received = Convert.ToInt32(row[3]);
                        int ping = received - sent;
                        int PL = 0;
                        string date = DateTime.Now.Date.ToString();
                        string time = DateTime.Now.Hour.ToString();
                        int packetloss = Convert.ToInt32(row[4]);
                        if (hop == "X")
                        {
                            PL = 100;
                        }
                        ///the code responsible for passing the data to the database, all of the data is enterd as a parameter of the base command
                        SqlDataAdapter DataTable = new SqlDataAdapter();
                        DataTable.InsertCommand = new SqlCommand("insert into Data(Host, send, receive, hop, loss, date, time, seq, packetloss, Code) values (@host, @send, @receive, @hop, @loss, @date, @time, @seq, @packetloss, @code)", connection);
                        DataTable.InsertCommand.Parameters.Add("@host", SqlDbType.Text).Value = target;
                        DataTable.InsertCommand.Parameters.Add("@seq", SqlDbType.Int).Value = Hopnum;
                        DataTable.InsertCommand.Parameters.Add("@send", SqlDbType.Text).Value = sent;
                        DataTable.InsertCommand.Parameters.Add("@receive", SqlDbType.Text).Value = received;
                        DataTable.InsertCommand.Parameters.Add("@hop", SqlDbType.Text).Value = Adress;
                        DataTable.InsertCommand.Parameters.Add("@loss", SqlDbType.Text).Value = PL;
                        DataTable.InsertCommand.Parameters.Add("@date", SqlDbType.Text).Value = date;
                        DataTable.InsertCommand.Parameters.Add("@time", SqlDbType.Text).Value = time;
                        DataTable.InsertCommand.Parameters.Add("@packetloss", SqlDbType.Int).Value = packetloss;
                        DataTable.InsertCommand.Parameters.Add("@code", SqlDbType.Int).Value = tick;
                        try
                        {
                            DataTable.InsertCommand.ExecuteNonQuery();
                        }
                        catch
                        {
                            connection.Open();
                            DataTable.InsertCommand.ExecuteNonQuery();
                        }
                        
                        connection.Close();
                       
                    }
                    
                }
            }
            
        }
	}
}
