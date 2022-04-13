using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace S2S
{
    internal class TCP
    {
        public static void TCPServer()
        {
            Console.Clear();

            ConsoleLog.Log($"Attempting to launch TCP listener on {ServerInfo.IP.ToString()}:{ServerInfo.PORT}");

            CommandParser.RegisterCommands();

            TcpListener serverSocket = new TcpListener(ServerInfo.IP, ServerInfo.PORT);
            serverSocket.Start();
            ConsoleLog.Positive($"Successfully launched TCP listener on {ServerInfo.IP.ToString()}:{ServerInfo.PORT}");
            Console.WriteLine();

            byte[] bytes = new byte[1024];
            string data = null;

            bool quit = false;
            while (!quit)
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();

                data = null;

                NetworkStream stream = clientSocket.GetStream();

                int i;

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = Encoding.ASCII.GetString(bytes, 0, i);

                    ConsoleLog.CommandSearchLog($"Received Packet: ", data);

                    CommandParser.RunCommand(data);

                    byte[] msg = Encoding.ASCII.GetBytes(data);

                    stream.Write(msg, 0, msg.Length);
                }

                clientSocket.Close();
            }
        }
    }
}
