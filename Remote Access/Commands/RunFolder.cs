using System.Diagnostics;
using System.IO;

namespace S2S.Commands
{
    public class RunFolder : Command
    {
        public string CommandName => "run";

        public string CommandSubName => "folder";

        public void Execute(string command)
        {
            try
            {
                if (command == "documents")
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Arguments = command,
                        FileName = "explorer.exe"
                    };
                    Process.Start(startInfo);
                    return;
                }

                ProcessStartInfo explorer = new ProcessStartInfo
                {
                    Arguments = command,
                    FileName = "explorer.exe"
                };
                Process.Start(explorer);
                return;
            }
            catch { }
        }
    }
}
