using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace S2S
{
    public static class CommandParser
    {

        public static void RunCommand(string command)
        {
            string[] args = command.Split(' ');

            if (args[0] == "run")
            {
                if (args[1] == "application")
                {
                    try
                    {
                        Process.Start(args[2]);
                    } catch
                    {

                    }
                }
            }

        }

    }
}
