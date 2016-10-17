namespace RecyclingStation.Interfaces
{
    public interface ICommandExecutor
    {
        string Execute(string commandName, string[] commandParams);
    }
}
