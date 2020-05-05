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
        string IPadress = "127.0.0.1";
        int Port = 1200;

        public void Connect(byte[] SOMEIP_Message)
        {
            UdpClient Client = new UdpClient(Port);
            IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(IPadress), Port);
            Client.Connect(EndPoint);
            Client.Send(SOMEIP_Message, SOMEIP_Message.Length);
        }
    }
}
