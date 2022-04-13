using System.Diagnostics;

namespace S2S.Commands
{
    public class RunSteam : ICommand
    {
        public string CommandName => "run";

        public string CommandSubName => "steam";

        public void Execute(string command)
        {
            try
            {
                Process.Start($"steam://rungameid/{command}");
            }
            catch { }
        }
    }
}
