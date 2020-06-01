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
<<<<<<< HEAD
        private async Task<byte[]> Receive()
        {
            while (true)
            {
                var ReceiveResults = await Client.ReceiveAsync();
                return Encoding.ASCII.GetBytes(ReceiveResults.Buffer.ToString()); //može li ovo ovako, nesto tu ne stima? ili može biti void?
                //var s = string.Format("[{0}] {1}", receivedResults.RemoteEndPoint, System.Text.Encoding.ASCII.GetString(receivedResults.Buffer));
=======

        //1.asinkrono pokretanje taskova, unutar taska:
        //2. Petlja koja se konstantno vrti
        private async Task<byte[]> Receive()
        {
            //3.udpReceiveResult --asinkrono primanje podataka od klijenta
            //receiveAsinc i await
            while (true)
            {
               // return await Client.BeginReceive(;
>>>>>>> d41da02e2d633541e51bd6440a1c3f3688d83793
            }
        }

        public void Send(byte[] SOMEIP_Message)
        {
            Client.Send(SOMEIP_Message, SOMEIP_Message.Length);
        }
    }
}
//sjetiti se pitati za 2 objekta