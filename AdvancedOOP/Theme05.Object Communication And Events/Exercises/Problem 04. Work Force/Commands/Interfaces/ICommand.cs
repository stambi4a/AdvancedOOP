namespace Problem_04.Work_Force.Commands.Interfaces
{
    using Problem_04.Work_Force.Data.Interfaces;

    public interface ICommand
    {
        void Execute(string[] commandParams, IRepository repository);
    }
}
