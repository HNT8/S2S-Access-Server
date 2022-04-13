using S2S;
using System.Diagnostics;

public class RunURL : ICommand
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
