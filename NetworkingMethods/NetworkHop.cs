using System.Net;

namespace Network_Tool.NetworkingMethods
{
    public class NetworkHop
    {
        private IPAddress ipv4Address;
        private int sequenceNumber;
        private int latency;
        private int averageLatency;
        private int minLatency;
        private int maxLatency;
        private int packetLoss;
        private int minLoss;
        private int maxLoss;
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

        public int AverageLatency
        {
            get => averageLatency;
            set => averageLatency = value;
        }

        public int MinLatency
        {
            get => minLatency;
            set => minLatency = value;
        }

        public int MaxLatency
        {
            get => maxLatency;
            set => maxLatency = value;
        }
        
        public int PacketLoss
        {
            get => packetLoss;
            set => packetLoss = value;
        }
        
        public int MinLoss
        {
            get => minLoss;
            set => minLoss = value;
        }

        public int MaxLoss
        {
            get => maxLoss;
            set => maxLoss = value;
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

        public NetworkHop(IPAddress ipv4Address, int sequenceNumber, int latency,int packetLoss)
        {
            this.ipv4Address = ipv4Address;
            this.sequenceNumber = sequenceNumber;
            this.latency = latency;
            this.packetLoss = packetLoss;

            this.averageLatency = latency;
            this.minLatency = latency;
            this.maxLatency = latency;
            this.minLoss = packetLoss;
            this.maxLoss = packetLoss;
        }
        public NetworkHop(IPAddress ipv4Address, int sequenceNumber, int latency, int packetLoss, NetworkHop previousNode)
        {
            this.ipv4Address = ipv4Address;
            this.sequenceNumber = sequenceNumber;
            this.latency = latency;
            this.packetLoss = packetLoss;
            this.previousNode = previousNode;
            
            this.averageLatency = latency;
            this.minLatency = latency;
            this.maxLatency = latency;
            this.minLoss = packetLoss;
            this.maxLoss = packetLoss;
        }
        ~NetworkHop() { }
    }
}