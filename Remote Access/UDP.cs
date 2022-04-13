using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace S2S
{
    internal class UDP
    {
        public static void UDPServer()
        {
            Console.Clear();

            ConsoleLog.Log($"Attempting to launch UDP listener on {ServerInfo.IP}:{ServerInfo.PORT}");

            CommandParser.RegisterCommands();

            UdpClient listener = new UdpClient(ServerInfo.PORT);
            IPEndPoint endpoint = new IPEndPoint(ServerInfo.IP, ServerInfo.PORT);

            ConsoleLog.Positive($"Successfully launched UDP listener on {ServerInfo.IP}:{ServerInfo.PORT}");
            Console.WriteLine();

            bool quit = false;
            while (!quit)
            {
                byte[] bytes = listener.Receive(ref endpoint);
                string command = Encoding.ASCII.GetString(bytes);

                ConsoleLog.CommandSearchLog($"Received Packet: ", command);

                CommandParser.RunCommand(command);
            }

            listener.Close();
        }
    }
}
