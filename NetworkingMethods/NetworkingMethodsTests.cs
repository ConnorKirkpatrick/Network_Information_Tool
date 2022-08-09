using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Network_Tool.NetworkingMethods
{
    public class NetworkingMethodsTests
    {
        [Test]
        public async Task TraceRouteTest()
        {
            NetworkMethods networkTools = new NetworkMethods();
            string target = "8.8.8.8";
            string[][] data = await networkTools.TraceRoute(target,"500");
            string[] addresses = data[0];
            string[] packetLoss = data[1];
            Assert.AreEqual(addresses[Convert.ToInt32(data[2][0])], target, "Ping never reached target");
        }
    }
}