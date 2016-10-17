namespace Problem_06.Mirror_Image.Interfaces
{
    public interface ICommandExecutor
    {
        void Execute(string commandName, string[] commandParams);
    }
}
