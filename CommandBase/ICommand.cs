namespace S2S
{
    public interface ICommand
    {
        string CommandName { get; }
        string CommandSubName { get; }
        void Execute(string command);
    }
}
