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
<<<<<<< HEAD
        int port, endPointPort;
        public delegate void SomeIPClientEventHandler(byte[] e); //dodati bool jel šalje ili prima
        ConnectDataInput DataInput = new ConnectDataInput();

        public event SomeIPClientEventHandler ReceiveResultsEvent;

        UdpClient Client;
        IPEndPoint EndPoint;

        public SomeIPClient(int port, int end_point)
        {
            Port = port;
            EndPointPort = end_point;
            Client = new UdpClient(Port);
            EndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), EndPointPort);
        }

        public SomeIPClient()
        {
            Port = DataInput.Port;
            EndPointPort = DataInput.EndPointPort;
            Client = new UdpClient(Port);
            EndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), EndPointPort);
        }

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        public int EndPointPort
        {
            get { return endPointPort; }
            set { endPointPort = value; }
        }
        public async Task Receive()
        {
            while (true)
            {

                var ReceiveResults = await Client.ReceiveAsync();
                    if (ReceiveResults != null) // ak nismo primili da ne yamaramo klasu
                    {
                        OnDataReceived(ReceiveResults.Buffer);
                    }
            }
        }
=======
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
>>>>>>> c471b0d41f1dc4d4984b731ed29efef68aa06580

        public void Send(byte[] SOMEIP_Message)
        {
            UdpClient tempClient = new UdpClient();
            tempClient.Send(SOMEIP_Message, SOMEIP_Message.Length, EndPoint);
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

<<<<<<< HEAD
=======
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

>>>>>>> c471b0d41f1dc4d4984b731ed29efef68aa06580
    }
}