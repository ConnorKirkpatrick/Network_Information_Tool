using System.Net;

namespace Network_Tool.NetworkingMethods
{
    public class NetworkHop
    {
        private IPAddress ipv4Address;
        private int sequenceNumber;
        private int latency;
        private int packetLoss;
        private NetworkHop previousNode = null;
        private NetworkHop nextNode = null;
        public IPAddress Ipv4Address
        {
            get => ipv4Address;
            set => ipv4Address = value;
        }

        public int SequenceNumber
        {
            get => sequenceNumber;
            set => sequenceNumber = value;
        }

        public int Latency
        {
            get => latency;
            set => latency = value;
        }

        public int PacketLoss
        {
            get => packetLoss;
            set => packetLoss = value;
        }
        
        public NetworkHop PreviousNode
        {
            get => previousNode;
            set => previousNode = value;
        }

        public NetworkHop NextNode
        {
            get => nextNode;
            set => nextNode = value;
        }

        public NetworkHop()
        { }

        public NetworkHop(IPAddress ipv4Address, int sequenceNumber, int latency, int packetLoss)
        {
            this.ipv4Address = ipv4Address;
            this.sequenceNumber = sequenceNumber;
            this.latency = latency;
            this.packetLoss = packetLoss;
        }
        public NetworkHop(IPAddress ipv4Address, int sequenceNumber, int latency, int packetLoss, NetworkHop previousNode)
        {
            this.ipv4Address = ipv4Address;
            this.sequenceNumber = sequenceNumber;
            this.latency = latency;
            this.packetLoss = packetLoss;
            this.previousNode = previousNode;
        }

        ~NetworkHop() { }
        
        
    }
}