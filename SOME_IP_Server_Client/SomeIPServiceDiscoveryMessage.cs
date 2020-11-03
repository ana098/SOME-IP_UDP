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

        public enum SOMEIP_ServiceID : uint
        {
            PICTURE = 0xAAAA,   //43 981
            TEXT = 0xBBBB,
            SOUND = 0xCCCC
        }

        public class ServiceDiscoveryEntry
        {
            byte[] temp = new byte[4];
            uint MinorVersion, TTL;
            ushort InstanceID, ServiceID, EventgroupID, Length;
            byte Type, Index1opt, Index2opt, MajorVersion, NumberOfOpt1, NumberOfOpt2, Reserved_E,
                InitialDataRequestedFlag, Reserved2_E, Counter, ZeroTerminatedConfigurationString;
            public byte[] Entries_Array
            {
                get
                {
                    byte[] TY = new byte[] { Type };
                    byte[] I1 = new byte[] { Index1opt };
                    byte[] I2 = new byte[] { Index2opt };
                    byte[] N1 = new byte[] { NumberOfOpt1 };
                    byte[] N2 = new byte[] { NumberOfOpt2 };
                    byte[] MV = new byte[] { MajorVersion };

                    return BitConverter.GetBytes(Type)
                        .Concat(I1)
                        .Concat(I2)
                        .Concat(N1)
                        .Concat(N2)
                        .Concat(BitConverter.GetBytes(ServiceID))
                        .Concat(BitConverter.GetBytes(InstanceID))
                        .Concat(MV)
                        .Concat(BitConverter.GetBytes(TTL))
                        .Concat(BitConverter.GetBytes(MinorVersion)).ToArray();
                }
                private set
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

        public SomeIPServiceDiscoveryMessage(byte[] fullMessagePayload) : base(fullMessagePayload)
        {
            DissectFullPayload(fullMessagePayload);

            Array.Copy(Payload, 0, temp, 0, 1);
            Flags = temp[0];

            Array.Copy(Payload, 1, temp, 0, 3);
            Reserved_Header = temp.Take(3).ToArray();

            Array.Copy(Payload, 4, temp, 0, 4);
            LengthOfEntriesArray = BitConverter.ToUInt32(temp, 0);

            Array.Copy(Payload, 8, Entries_Array, 0, 4);

            Array.Copy(Payload, 12, temp, 0, 4);
            LengthOfOptionsArray = BitConverter.ToUInt32(temp, 0);

            Array.Copy(Payload, 16, Options_Array, 0, 4);
        }

            public SomeIPServiceDiscoveryMessage(uint Mess_ID, uint Req_ID, byte Mess_Type, byte Ret_Code, byte Flag, byte[] ReservedHeader,
            byte[] EntriesArray, byte[] OptionsArray)
            : base(Mess_ID, Req_ID, Mess_Type, Ret_Code)
        {
            Flags = Flag;
            Reserved_Header = ReservedHeader;
            Entries_Array = EntriesArray;  
            Options_Array = OptionsArray;
            LengthOfEntriesArray = Convert.ToUInt32(EntriesArray.Length);
            LengthOfOptionsArray = Convert.ToUInt32(OptionsArray.Length);
            ////////////////////////////////////////////////////////
        }

        public uint GetLengthEntry
        {
            get
            {
                return LengthOfEntriesArray;
            }

            private set
            {
                LengthOfEntriesArray = value;
            }
        }

    }
}
