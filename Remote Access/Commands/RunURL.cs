using System.Diagnostics;

namespace S2S.Commands
{
    public class RunURL : Command
    {
        public string CommandName => "run";

        public string CommandSubName => "url";

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
