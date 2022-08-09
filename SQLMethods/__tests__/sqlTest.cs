using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using Network_Tool.SQLMethods;
using NUnit.Framework;

namespace Network_Tool
{
    public class SqlTests
    {
        [Test]
        public void ConnectionTest()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=D:\\Network_Information_Tool\\testData.sql;FailIfMissing=True;");
            conn.Open();
            Assert.AreEqual(conn.State.ToString(), "Open","Open connection not established");
            conn.Close();
        }

        [Test]
        public void AccessTest()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=D:\\Network_Information_Tool\\testData.sql;FailIfMissing=True;");
            SQLiteCommand getData = new SQLiteCommand("select * from testData");
            getData.Connection = conn;
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapt = new SQLiteDataAdapter(getData);
            conn.Open();
            adapt.Fill(dt);
            conn.Close();
            Assert.AreEqual(dt.Columns[0].ToString(), "host", "Unable to access table from database");
        }

        [Test]
        public void ClassTest()
        {
            SQLConnection connection = new SQLConnection();
            Assert.IsInstanceOf<SQLConnection>(connection,"Object type not generated correctly");
            Assert.IsTrue(connection.testConnection(), "Test condition failed to access to database");
        }
    }
}