using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace S2S
{
    public static class CommandParser
    {

        private static List<ICommand> Commands = new List<ICommand>();

        public static void RegisterCommands()
        {
            if (Directory.Exists("Plugins"))
            {
                string[] files = Directory.GetFiles("Plugins");
                foreach (string file in files)
                {
                    if (file.EndsWith(".dll"))
                    {
                        Assembly.LoadFile(Path.GetFullPath(file));
                    }
                }
            }

            Type interfaceType = typeof(ICommand);
            Type[] types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass).ToArray();
            foreach (Type type in types)
            {
                Commands.Add((ICommand)Activator.CreateInstance(type));
            }
        }

        public static void RunCommand(string command)
        {
            RunCommand(command.Split(' '));
        }

        private static void RunCommand(string[] args)
        {
            string CommandName = "null";
            string CommandSubName = "null";
            try
            {
                CommandName = args[0];
                CommandSubName = args[1];

                List<string> Arguments = new List<string>(args);
                Arguments.RemoveRange(0, 2);

                ConsoleLog.CommandSearchLog("Searching for command with Name: ", $"{CommandName}:{CommandSubName}");

                foreach (ICommand cmd in Commands)
                {
                    if (cmd.CommandName == CommandName && cmd.CommandSubName == CommandSubName)
                    {
                        cmd.Execute(string.Join(" ", Arguments.ToArray()));
                        ConsoleLog.CommandSearchPositive($"Successfully ran command: ", $"{CommandName}:{CommandSubName}");
                        return;
                    }
                }
            }
            catch { }

            ConsoleLog.CommandSearchNegative($"Could not locate specified command:", $"{CommandName}:{CommandSubName}");
            return;
        }
    }
}
