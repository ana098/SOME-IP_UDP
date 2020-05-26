using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOME_IP_Server_Client
{
    public class SomeIPServiceDiscoveryMessage : SomeIPMessage
    {
        byte Flags;   //8
        byte[] Reserved_Header = new byte[3];  //32   
        uint LengthOfEntriesArray, LengthOfOptionsArray;
        byte[] Entries_Array = new byte[16];        //128 bit
        byte[] Options_Array = new byte[8];         //64 bit
        byte[] temp = new byte[4];

        public class ServiceDiscoveryEntry
        {
            byte[] temp = new byte[4];
            uint MinorVersion, TTL;
            ushort InstanceID, ServiceID, EventgroupID, Length;
            byte Type, Index1opt, Index2opt, MajorVersion, NumberOfOpt1, NumberOfOpt2, Reserved_E, InitialDataRequestedFlag, Reserved2_E, Counter, ZeroTerminatedConfigurationString;
            // nema potrebe za svim inicijaliziranim varijablama?
            public byte[] Entries_Array
            {
                get
                {
                    return BitConverter.GetBytes(Type)
                        .Concat(BitConverter.GetBytes(Index1opt))
                        .Concat(BitConverter.GetBytes(Index2opt))
                        .Concat(BitConverter.GetBytes(NumberOfOpt1)
                        .Concat(BitConverter.GetBytes(NumberOfOpt2))
                        .Concat(BitConverter.GetBytes(ServiceID))
                        .Concat(BitConverter.GetBytes(InstanceID))
                        .Concat(BitConverter.GetBytes(MajorVersion))
                        .Concat(BitConverter.GetBytes(TTL))
                        .Concat(BitConverter.GetBytes(MinorVersion))).ToArray();
                }
              // private   //komentirano radi testiranja
                set
                {

                    Array.Copy(value, 0, temp, 0, 1);
                    Type = temp[0];

                    Array.Copy(value, 1, temp, 0, 1);
                    Index1opt = temp[0];

                    Array.Copy(value, 2, temp, 0, 1);
                    Index2opt = temp[0];

                    Array.Copy(value, 3, temp, 0, 1);
                    ushort temp_u = Convert.ToUInt16(temp[0]);
                    NumberOfOpt1 = Convert.ToByte(temp_u & 0x0F);

                    NumberOfOpt2 = Convert.ToByte(temp_u >> 4);

                    Array.Copy(value, 4, temp, 0, 2);
                    ServiceID = BitConverter.ToUInt16(temp, 0);

                    Array.Copy(value, 6, temp, 0, 2);
                    InstanceID = BitConverter.ToUInt16(temp, 0);

                    Array.Copy(value, 8, temp, 0, 1);
                    MajorVersion = temp[0];

                    Array.Copy(value, 9, temp, 0, 3);
                    TTL = BitConverter.ToUInt32(temp, 0);

                    Array.Copy(value, 12, temp, 0, 4);
                    MinorVersion = BitConverter.ToUInt32(temp, 0);
                }
            }

        }

       public SomeIPServiceDiscoveryMessage(byte[] fullMessagePayload): base(fullMessagePayload) 
        {
            DissectFullPayload(fullMessagePayload);

           Array.Copy(Payload, 0, temp, 0, 1);
           Flags = temp[0];

           Array.Copy(Payload, 1, temp, 0, 3);
           Reserved_Header = temp.Take(3).ToArray();    //uzimam 3 bytea iz polja od 4 pa je zadnje 0 defaultno, zato cijeli temp ne spremam nego opet uzimam 3

           Array.Copy(Payload, 4, temp, 0, 4);
           LengthOfEntriesArray = BitConverter.ToUInt32(temp,0);

           Array.Copy(Payload, 8, Entries_Array, 0, 4);

           Array.Copy(Payload, 12, temp, 0, 4);
           LengthOfOptionsArray = BitConverter.ToUInt32(temp, 0);

           Array.Copy(Payload, 16, Options_Array, 0, 4);
        }

        public SomeIPServiceDiscoveryMessage(byte Flag, byte[] ReservedHeader, byte[] EntriesArray, byte[] OptionsArray, uint Mess_ID, uint Req_ID, byte Mess_Type, byte Ret_Code)
            : base(Mess_ID, Req_ID,Mess_Type,Ret_Code) 
        {
            Flags = Flag;
            Reserved_Header = ReservedHeader;
            Entries_Array = EntriesArray;
            Options_Array = OptionsArray;
            //nema length? --računamo ga length = Entries_Array.Length; Provjeriti je li duljina br elemenata ili u byteovima
        }

    }
}
