using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2S
{
    public static class ConsoleLog
    {
        public static void Log(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("=");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            Console.ResetColor();
            Console.WriteLine(text);
        }

        public static void Positive(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("+");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            Console.ResetColor();
            Console.WriteLine(text);
        }

        public static void Negative(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            Console.ResetColor();
            Console.WriteLine(text);
        }

        public static void CommandSearchLog(string text, string command)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("=");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            Console.ResetColor();
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($" {command}");
            Console.ResetColor();
        }

        public static void CommandSearchPositive(string text, string command)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("+");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            Console.ResetColor();
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($" {command}");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void CommandSearchNegative(string text, string command)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            Console.ResetColor();
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($" {command}");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
