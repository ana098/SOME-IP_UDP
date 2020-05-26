using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;


namespace SOME_IP_Server_Client
{
    class SomeIPClient
    {
        int port = 1200;
        UdpClient Client = new UdpClient(1200); 
        string IPadress = "127.0.0.1";
        IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1200);

        public void Connect()
        {
            Client.Connect(EndPoint);
        }

        //1.asinkrono pokretanje taskova, unutar taska:
        //2. Petlja koja se konstantno vrti
        private async Task<byte[]> Receive()
        {
            //3.udpReceiveResult --asinkrono primanje podataka od klijenta
            //receiveAsinc i await
            while (true)
            {
               // return await Client.BeginReceive(;
            }
        }

        public void Send(byte[] SOMEIP_Message)
        {
            Client.Send(SOMEIP_Message, SOMEIP_Message.Length);
        }
    }
}
