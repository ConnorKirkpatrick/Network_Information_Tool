using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Network_Tool.SQLMethods
{
    public class SQLConnection
    {
        private SQLiteConnection conn = new SQLiteConnection("Data Source=D:\\Network_Information_Tool\\testData.sql;FailIfMissing=True;");
        
        public bool testConnection()
        {
            SQLiteCommand getData = new SQLiteCommand("select * from testData");
            getData.Connection = conn;
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapt = new SQLiteDataAdapter(getData);
            conn.Open();
            adapt.Fill(dt);
            conn.Close();
            return dt.Columns[2].ToString() == "Host";
        }

        public async Task<DataTable> getData(SQLiteCommand cmd)
        {
            cmd.Connection = conn;
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapt = new SQLiteDataAdapter(cmd);
            conn.Open();
            adapt.Fill(dt);
            conn.Close();
            return dt;
        }

        public void setData(SQLiteCommand cmd)
        {
            //when using this command, use a prepared statement created using SqliteCommandBuilder
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public SQLiteCommand getCmd()
        {
            return conn.CreateCommand();
        }
    }
}