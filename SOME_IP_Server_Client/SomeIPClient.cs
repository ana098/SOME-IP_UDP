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
        public delegate void SomeIPClientEventHandler(byte[] e); //dodati bool jel šalje ili prima

        public event SomeIPClientEventHandler ReceiveResultsEvent;

        UdpClient Client = new UdpClient(); 
        IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1200);
        

        public void Connect()
        {
            Client.Connect(EndPoint);
        }
        public async Task Receive()
        {
          UdpClient Server = new UdpClient(8080);
          IPEndPoint EndPoint_Server = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

            while (true)
            {
                //await Task.Run(() =>
                //{
                    var ReceiveResults = await Server.ReceiveAsync();

                    if (ReceiveResults != null) // ak nismo primili da ne yamaramo klasu
                    {
                        OnDataReceived(ReceiveResults.Buffer);
                    }
               // });
            }
        }

        public void Send(byte[] SOMEIP_Message)
        {
            Client.Send(SOMEIP_Message, SOMEIP_Message.Length);
        }

        private void OnDataReceived(byte[] args)
        {
            if (ReceiveResultsEvent != null) // ako na formi nemao ono +0 onda da se ne rusi
            {
                ReceiveResultsEvent(args);
            }
        }

        public void CloseConnection()
        {
            Client.Close();
        }

    }
}