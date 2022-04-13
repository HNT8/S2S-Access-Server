using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace S2S
{
    internal class Start
    {
        public static string ip;
        public static string port;

        static void Main(string[] args)
        {
            Console.Title = "S2S Remote Access Server";
            port = null;

            if (args.Length == 0)
            {
                Console.Write("Port >> ");
                port = Console.ReadLine();
                start:
                Console.Write("TCP or UDP >> ");
                if (Console.ReadLine().ToUpper() == "TCP")
                {
                    ServerInfo.SetConnectionInformation(IPAddress.Any, Convert.ToInt32(Start.port));
                    TCP.TCPServer();
                } else if (Console.ReadLine().ToUpper() == "UDP")
                {
                    ServerInfo.SetConnectionInformation(IPAddress.Any, Convert.ToInt32(Start.port));
                    UDP.UDPServer();
                } else
                {
                    Console.Clear();
                    goto start;
                }
            } else if (args.Length > 1)
            {
                ip = args[0];
                port = args[1];
                if (args[2] == "UDP")
                {
                    ServerInfo.SetConnectionInformation(IPAddress.Any, Convert.ToInt32(Start.port));
                    UDP.UDPServer();
                } else if (args[2] == "TCP")
                {
                    ServerInfo.SetConnectionInformation(IPAddress.Any, Convert.ToInt32(Start.port));
                    TCP.TCPServer();
                }
                return;
            }            

            

        }

        private readonly string credits = "S2S REMOTE ACCESS SERVER MADE BY HUNTER POLLOCK github.com/hlpdev";
    }
}
