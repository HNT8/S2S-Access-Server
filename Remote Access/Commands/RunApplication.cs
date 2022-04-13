using System;
using System.Diagnostics;

namespace S2S.Commands
{
    public class RunApplication : ICommand
    {
        public string CommandName => "run";

        public string CommandSubName => "application";

        public void Execute(string command)
        {
            try
            {
                Process.Start(command);
            }
            catch { }
        }
    }
}
