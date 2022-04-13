using System;
using System.Diagnostics;
using System.IO;

namespace S2S.Commands
{
    public class RunFolder : ICommand
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
                        Arguments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        FileName = "explorer.exe"
                    };
                    Process.Start(startInfo);
                    return;
                }

                if (command == "pictures")
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Arguments = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                        FileName = "explorer.exe"
                    };
                    Process.Start(startInfo);
                    return;
                }

                if (command == "videos")
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Arguments = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
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
