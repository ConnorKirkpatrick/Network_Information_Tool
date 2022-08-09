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
    }
}