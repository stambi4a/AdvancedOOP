namespace Problem_04.Work_Force.Core.Interface
{
    using Problem_04.Work_Force.Data.Interfaces;

    public interface ICommandExecutor
    {
        void ExecuteCommand(string[] input, IRepository repository);
    }
}
