using System;
using System.Net;
using System.Net.Sockets;


namespace BlockChain.Models.Networking
{
    class P2PClient
    {

        TcpClient client;

        public P2PClient(int port)
        {
            client = new TcpClient();
            client.Connect(IPAddress.Loopback, port);
        }

        public void Connect(String server, String message)
        {
 
        }

        public void Send()
        {

        }

        public void Receive()
        {

        }
    }
}
