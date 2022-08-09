using System;
using System.Net;
using NUnit.Framework;

namespace Network_Tool.NetworkingMethods
{
    public class NetworkHopTests
    {
        [Test]
        public void generateObject()
        {
            IPAddress addr = IPAddress.Parse("8.8.8.8");
            NetworkHop hop = new NetworkHop(addr, 1, 10, 0);
            Assert.IsInstanceOf<NetworkHop>(hop,"Object type not generated correctly");
        }
        [Test]
        public void getterTests()
        {
            IPAddress addr1 = IPAddress.Parse("1.1.1.1");
            NetworkHop hop1 = new NetworkHop(addr1, 2, 10, 0);
            IPAddress addr = IPAddress.Parse("8.8.8.8");
            NetworkHop hop = new NetworkHop(addr, 1, 10, 0, hop1);
            
            Assert.AreEqual(hop.Ipv4Address, addr, "Ip address was not the same");
            Assert.AreEqual(hop.SequenceNumber, 1, "SequenceNumber was not the same");
            Assert.AreEqual(hop.Latency, 10, "Latency was not the same");
            Assert.AreEqual(hop.PacketLoss, 0, "Packet loss was not the same");
            Assert.AreSame(hop.PreviousNode, hop1, "Previous node was not the same");
        }

        [Test]
        public void setterTests()
        {
            IPAddress addr1 = IPAddress.Parse("1.1.1.1");
            NetworkHop hop1 = new NetworkHop(addr1, 2, 10, 0);
            IPAddress addr = IPAddress.Parse("8.8.8.8");
            NetworkHop hop = new NetworkHop(addr, 1, 10, 0, hop1);

            hop1.NextNode = hop;
            Assert.AreSame(hop1.NextNode, hop, "Next node not set correctly");
        }
    }
}