﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace S2S
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.Write("Port >> ");
            string port = Console.ReadLine();
            Console.Write("IP >> ");
            string ip = Console.ReadLine();

            Console.Clear();

            ServerInfo.SetConnectionInformation(IPAddress.Parse(ip), Convert.ToInt32(port));
            ConsoleLog.Log($"Attempting to launch TCP listener on {ServerInfo.IP.ToString()}:{ServerInfo.PORT}");

            TcpListener serverSocket = new TcpListener(ServerInfo.IP, ServerInfo.PORT);
            serverSocket.Start();
            ConsoleLog.Positive($"Successfully launched TCP listener on {ServerInfo.IP.ToString()}:{ServerInfo.PORT}");
            Console.WriteLine();

            byte[] bytes = new byte[10000];
            string data = null;

            while (true)
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();

                data = null;

                NetworkStream stream = clientSocket.GetStream();

                int i;

                while((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = Encoding.ASCII.GetString(bytes, 0, i);

                    ConsoleLog.Log($"Received Packet: {data}");
                    CommandParser.RunCommand(data);

                    byte[] msg = Encoding.ASCII.GetBytes(data);

                    stream.Write(msg, 0, msg.Length);
                }

                clientSocket.Close();
            }

            ConsoleLog.Negative("Shutting down server...");
            Thread.Sleep(2000);
            serverSocket.Stop();
            Thread.Sleep(5000);
            Environment.Exit(0);

        }
    }
}