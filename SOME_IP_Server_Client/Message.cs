using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOME_IP_Server_Client
{

    public abstract class Message
    {
        public byte[] Payload;
        //List<Signal> Signals = new List<Signal>();
   
        public class Signal
        {
            uint StartByte, Length;
        }
    }
}
