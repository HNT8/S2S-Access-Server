using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace S2S
{
    public static class ServerInfo
    {
        public static IPAddress IP { get; private set; }
        public static int PORT { get; private set; }


        private static bool Initialized = false;
        public static void SetConnectionInformation(IPAddress IP, int PORT)
        {
            if (Initialized) return;
            ServerInfo.IP = IP;
            ServerInfo.PORT = PORT;
            Initialized = true;
        }
    }
}
