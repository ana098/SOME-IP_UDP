using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SOME_IP_Server_Client
{
    class SomeIPMessage : Message
    {
        uint Length=122;    //32
        ushort ServiceID, MethodID, ClientID, SessionID;  //16
        byte ProtocolVersion, InterfaceVersion, MessageType, ReturnCode;  //8

        enum MessageType : byte
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

        enum ReturnCode : byte
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
            E_WRONG_MESSAGE_TYPE = 0x0A
            //E_RESERVED_GENERIC = 0x0B,
            //E_RESERVED_MS_ERROR = 0x20
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
            }
        }

          public byte[] SomeIPHeader
        {
            get 
            {
               var header = BitConverter.GetBytes(MessageID).Concat(BitConverter.GetBytes(Length)).Concat(BitConverter.GetBytes(RequestID)).Concat(BitConverter.GetBytes(ProtocolVersion).Concat(BitConverter.GetBytes(InterfaceVersion)).Concat(BitConverter.GetBytes(MessageType)).Concat(BitConverter.GetBytes(ReturnCode)));
               return header.ToArray();
                
            }
            set
            {}
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
                var FullMessage = SomeIPHeader.Concat(Payload);
                return FullMessage.ToArray(); 
            }
            set { }
        }
    }
}
