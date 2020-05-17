using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SOME_IP_Server_Client
{
    public class SomeIPMessage : Message
    {
        uint Length;    //122;    //32
        ushort ServiceID, MethodID, ClientID, SessionID;  //16
        byte ProtocolVersion, InterfaceVersion, MessageType, ReturnCode;  //8

       public enum SOMEIP_MessageType : byte
        { 
            REQUEST = 0x00,
            REQUEST_NO_RETURN = 0x01,
            NOTIFICATION = 0x02,
            RESPONSE = 0x80,
            ERROR = 0x81,
            TP_REQUEST = 0x20,
            TP_REQUEST_NO_RETURN = 0x21,
            TP_NOTIFICATION = 0x22,
            TP_RESPONSE = 0x23,
            TP_ERROR = 0x24
        }

       public enum SOMEIP_ReturnCode : byte
        { 
            E_OK = 0x00,
            E_NOT_OK = 0x01,
            E_UNKNOWN_SERVICE = 0x02,
            E_UNKNOWN_METHOD = 0x03,
            E_NOT_READY = 0x04,
            E_NOT_REACHABLE = 0x05,
            E_TIMEOUT = 0x06,
            E_WRONG_PROTOCOL_VERSION = 0x07,
            E_WRONG_INTERFACE_VERSION = 0x08,
            E_MALFORMED_MESSAGE = 0x09,
            E_WRONG_MESSAGE_TYPE = 0x0A,
            E_RESERVED_GENERIC = 0x0B,
            E_RESERVED_MS_ERROR = 0x20
        }

        public uint MessageID
        {
            get 
            { 
                return MessageID = (uint)(MethodID) << 16 | ServiceID;
            }
            set 
            {
                ServiceID = (ushort)(((1 << 16) -1) & (value >> (32 - 0)));
                MethodID = (ushort)(((1 << 16) - 1) & (value >> (16 - 0)));
                // ServiceID = (ushort) (value & 0xFFFF)
                // MethodID = (ushort) (value >> 16)
                // ServiceID = (ushort)(value & 0xFFFF)
                // MethodID = (ushort) (value >> 16)

                /*
                0x3225FEDC
                
                & 0x0000FFFF
                0x0000FEDC > ushort 0xFEDC
                 
                0x3225FEDC  [>>4] ->  0x03225FED
                            [>>4] ->  0x003225FE

                [>> 16] -> 0x00003225

                0x3225
                0x00003225
                0x32250000 + ServiceID
                 */
            }
        }

          public byte[] SomeIPHeader
        {
            get 
            {
                //.Concat(new byte[] { ProtocolVersion })
               return BitConverter.GetBytes(MessageID)
                   .Concat(BitConverter.GetBytes(Length))
                   .Concat(BitConverter.GetBytes(RequestID))
                   .Concat(BitConverter.GetBytes(ProtocolVersion)
                   .Concat(BitConverter.GetBytes(InterfaceVersion))
                   .Concat(BitConverter.GetBytes(MessageType))
                   .Concat(BitConverter.GetBytes(ReturnCode))).ToArray();
                
            }
            private set
            {
                for (byte i = 0; i < 32; i++)
                {
                    MessageID = value[i]; 
                }
                for (byte i = 32; i < 64; i++)
                {
                    Length=value[i];
                }
                for(byte i = 64; i < 96; i++)
                {
                    RequestID = value[i];
                }
                for (byte i = 96; i < 104; i++)
                {
                    ProtocolVersion = value[i];
                }
                for (byte i = 104; i < 112; i++)
                {
                    InterfaceVersion = value[i];
                }
                for (byte i = 112; i < 120; i++)
                {
                    MessageType = value[i];
                }
                for (byte i = 120; i < 128; i++)
                {
                    ReturnCode = value[i];
                }
               // ReturnCode =value.Take(8);
                //var first=array.take(koliko uzima).ToArray();
                //var second=array.Skip(koliko preskace).ToArray();
            }
        }

        public uint RequestID
        {
            get 
            {
                return RequestID = (uint)(SessionID) << 16 | ClientID;
            }
            set 
            {
                ClientID = (ushort)(((1 << 16) - 1) & (value >> (32 - 0)));
                SessionID = (ushort)(((1 << 16) - 1) & (value >> (16 - 0)));
            }
        }

        public byte[] FullMessagePayload
        {
            get 
            {
                return SomeIPHeader.Concat(Payload).ToArray();
            }
            set 
            {
                DissectFullPayload(value);      //je li ovo ok?????
            }
        }

        public SomeIPMessage(uint Mess_ID, uint Req_ID,byte Mess_Type, byte Ret_Code)
        { 
            MessageID = Mess_ID;
            RequestID = Req_ID;
            MessageType = Mess_Type;
            ReturnCode = Ret_Code;
            ProtocolVersion = 1;    //ovo je drugi konstruktor?
            InterfaceVersion = 1;
        }

        public SomeIPMessage(byte[] Full_Message)
        {
            DissectFullPayload(Full_Message);
        }

        public void DissectFullPayload(byte[] Full_Message)
        {
            for (byte i = 0; i < 128; i++)
            {
                SomeIPHeader[i] = Full_Message[i];
            }
            for (byte i = 128; i < Full_Message.Length; i++)
            {
                Payload[i] = Full_Message[i];
            }
           
        }

    }
}
