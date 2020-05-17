using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SOME_IP_Server_Client
{
    class SomeIPClient
    {
        int Port = 1200;
        UdpClient Client; 
        string IPadress = "127.0.0.1";

        public byte[] Connect()
        {
            Client = new UdpClient(Port);
            IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(IPadress), Port);
            Client.Connect(EndPoint);
            byte[] bytes = Client.Receive(ref EndPoint);
            return bytes;
        }
        //koristiti socket??
        public void Send(byte[] SOMEIP_Message)
        {
            Client.Send(SOMEIP_Message, SOMEIP_Message.Length);
        }
    }
}
