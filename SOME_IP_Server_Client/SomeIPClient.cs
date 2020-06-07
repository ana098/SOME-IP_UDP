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
        static int port = 1200;
        UdpClient Client = new UdpClient(port); 
        IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1200);
        byte[] ReceiveData;

        public void Connect()
        {
            Client.Connect(EndPoint);
        }
        private async Task Receive()
        {
            while (true)
            {
                var ReceiveResults = await Client.ReceiveAsync(); //raise event


                //event handler, delegate
                // if (ReceiveResults != null) { RaiseEventMsg(ReceiveResults.Buffer) }
                if (ReceiveResults != null)
                {
                    OnDataReceived(Encoding.ASCII.GetBytes(ReceiveResults.Buffer.ToString()));
                }
            }
        }

        public void Send(byte[] SOMEIP_Message)
        {
            Client.Send(SOMEIP_Message, SOMEIP_Message.Length);
        }

        public delegate void SomeIPClientEventHandler(object sender, byte[] e);
        public event SomeIPClientEventHandler ReceiveResultsEvent;

        private void OnDataReceived(byte[] args)
        {
            if (ReceiveResultsEvent != null)
            {
                ReceiveResultsEvent(this, args);
            }
        }
    }
}