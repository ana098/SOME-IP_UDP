using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOME_IP_Server_Client
{
    static class  Log
    {
        static StringBuilder logTxt = new StringBuilder();

        public static void MessageSent(string text)
        {
             logTxt.AppendLine(text);
        }

        public static void MessageReceived()
        { 
        
        }

        public static string Log_Txt()
        {
            return logTxt.ToString();
        }
    }
}
