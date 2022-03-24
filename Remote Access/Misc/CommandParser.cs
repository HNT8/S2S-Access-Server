using System;
using System.Collections.Generic;
using S2S.Commands;

namespace S2S
{
    internal class CommandParser
    {
        private static List<Command> Commands = new List<Command>();

        public static void RegisterCommands()
        {
            Commands.Add(new RunApplication());
            Commands.Add(new RunURL());
            Commands.Add(new RunFolder());
        }

        public static void RunCommand(string command)
        {
            RunCommand(command.Split(' '));
        }

        private static void RunCommand(string[] args)
        {
            string CommandName = args[0];
            string CommandSubName = args[1];

            List<string> Arguments = new List<string>(args);
            Arguments.RemoveRange(0, 2);

            ConsoleLog.CommandSearchLog("Searching for command with Name: ", $"{CommandName}:{CommandSubName}");

            foreach(Command cmd in Commands)
            {
                if (cmd.CommandName == CommandName && cmd.CommandSubName == CommandSubName)
                {
                    cmd.Execute(string.Join(" ", Arguments.ToArray()));
                    ConsoleLog.CommandSearchPositive($"Successfully ran command: ", $"{CommandName}:{CommandSubName}");
                    return;
                }
            }

            ConsoleLog.CommandSearchNegative($"Could not locate specified command:", $"{CommandName}:{CommandSubName}");
            return;
        }
    }
}
