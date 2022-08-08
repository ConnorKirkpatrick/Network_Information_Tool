using System.Data.SQLite;
using NUnit.Framework;

namespace Network_Tool
{
    public class SqlTests
    {
        [Test]
        public void connectionTest()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=D:\\Network_Information_Tool\\testData.sql;FailIfMissing=True;");
            conn.Open();
            Assert.AreEqual(conn.State.ToString(), "Open","Open connection not established");
            conn.Close();
        }
    }
}