using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Network_Tool.NetworkingMethods
{
    public class NetworkingMethodsTests
    {
        NetworkMethods networkTools = new NetworkMethods();
        [Test]
        public async Task TraceRouteTest()
        {
            
            string target = "8.8.8.8";
            NetworkHop baseHop = await networkTools.TraceRoute(target,"500");
            while(true)
            {
                if (baseHop.NextNode == null)
                {
                    break;
                }

                baseHop = baseHop.NextNode;
            }
            Assert.AreEqual(baseHop.Ipv4Address.ToString(), target, "Ping never reached target");
        }

        [Test]
        public async Task PingTest()
        {
            Assert.IsTrue(await networkTools.Ping("8.8.8.8"), "Failed to ping external address");
        }
    }
}