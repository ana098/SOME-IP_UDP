using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOME_IP_Server_Client
{
    class SomeIPServiceDiscoveryMessage : SomeIPMessage
    {
        byte Flags;   //8
        uint Reserved_Header;  //32    treba 24, kako?
        uint LengthOfEntriesArray, LengthOfOptionsArray;
        byte[] Entries_Array = new byte[16];        //128 bit
        byte[] Options_Array = new byte[8];         //64 bit

        class ServiceDiscoveryEntry
        {
            uint MinorVersion, TTL;
            ushort InstanceID, ServiceID, EventgroupID, Length;
            byte Type, Index1opt, Index2opt, MayorVersion, NumberOfOpt1, NumberOfOpt2, Reserved_E, InitialDataRequestedFlag, Reserved2_E, Counter, ZeroTerminatedConfigurationString;    //4 bita, 1 bit?
            
        }
    }
}
