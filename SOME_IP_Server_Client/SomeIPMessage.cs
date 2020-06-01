using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SOME_IP_Server_Client
{
    public class SomeIPMessage : Message
    {
        byte[] tempSetter;
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
                ServiceID = (ushort)value;  
                MethodID = (ushort)(value >> 16);          
                
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
            //private    //komentirano radi testiranja
              set 
            {
                //koji endian?
                //Buffer.BlockCopy(value, 0, BitConverter.GetBytes(MessageID), 0, 4);

                if (tempSetter != null && tempSetter.Length == 16)
                {

                    byte[] temp = new byte[4];

                    Array.Copy(tempSetter, 0, temp, 0, 4);      //uzima iste vrijednosti???????
                    MessageID = BitConverter.ToUInt32(temp, 0);

                    Array.Copy(tempSetter, 3, temp, 0, 4);
                    Length = BitConverter.ToUInt32(temp, 0);

                    Array.Copy(tempSetter, 7, temp, 0, 4);
                    RequestID = BitConverter.ToUInt32(temp, 0);

                    Array.Copy(tempSetter, 11, temp, 0, 1);
                    ProtocolVersion = temp[0];

                    Array.Copy(tempSetter, 12, temp, 0, 1);
                    InterfaceVersion = temp[0];

                    Array.Copy(tempSetter, 13, temp, 0, 1);
                    MessageType = temp[0];

                    Array.Copy(tempSetter, 14, temp, 0, 1);
                    ReturnCode = temp[0];
                }
                else
                { //što? try catch bolje?
                }
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
                ClientID = (ushort)value;
                SessionID = (ushort)(value >> 16);
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
                DissectFullPayload(value);
            }
        }

        public SomeIPMessage(uint Mess_ID, uint Req_ID,byte Mess_Type, byte Ret_Code)
        { 
            //nema length??
            MessageID = Mess_ID;
            RequestID = Req_ID;
            MessageType = Mess_Type;
            ReturnCode = Ret_Code;
            ProtocolVersion = 1; 
            InterfaceVersion = 1;
        }

        public SomeIPMessage(byte[] Full_MessagePayload)
        {
            DissectFullPayload(Full_MessagePayload);
        }

        public void DissectFullPayload(byte[] Full_MessagePayload)
        {
            tempSetter = new byte[16];
            Array.Copy(Full_MessagePayload, tempSetter, 16);
            SomeIPHeader = new byte[16];
            Payload = new byte[Full_MessagePayload.Length - 16];
            Array.Copy(Full_MessagePayload, 16, Payload, 0, Payload.Length);
        }
        //da izbjegnem error, obrisati poslije
       public SomeIPMessage()
        { }

    }
}
