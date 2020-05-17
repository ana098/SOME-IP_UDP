using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOME_IP_Server_Client
{
    public class SomeIPServiceDiscoveryMessage : SomeIPMessage
    {
        byte Flags;   //8
        byte[] Reserved_Header = new byte[3];  //32    treba 24, kako?
        uint LengthOfEntriesArray, LengthOfOptionsArray;
        byte[] Entries_Array = new byte[16];        //128 bit
        byte[] Options_Array = new byte[8];         //64 bit

        public class ServiceDiscoveryEntry
        {
            uint MinorVersion, TTL;
            ushort InstanceID, ServiceID, EventgroupID, Length;
            byte Type, Index1opt, Index2opt, MajorVersion, NumberOfOpt1, NumberOfOpt2, Reserved_E, InitialDataRequestedFlag, Reserved2_E, Counter, ZeroTerminatedConfigurationString;    //4 bita, 1 bit?

            public byte[] Entries_Array //može li ovako?
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
               private set
                { //hrpa for petlji??}
                }
            }

        }

        public SomeIPServiceDiscoveryMessage(byte[] fullMessagePayload): base(fullMessagePayload) 
        {
            //nova DissectFullPayload metoda zbog različite veličine headera??
        }

        public SomeIPServiceDiscoveryMessage(byte Flag, byte[] ReservedHeader, byte[] EntriesArray, byte[] OptionsArray) //mora biti jedan prazan konstruktor? kakve veze ima SomeIpMessage s ovim?
        {
            Flags = Flag;
            Reserved_Header = ReservedHeader;
            Entries_Array = EntriesArray;
            Options_Array = OptionsArray;
            //sta sa length?
        }
    }
}
