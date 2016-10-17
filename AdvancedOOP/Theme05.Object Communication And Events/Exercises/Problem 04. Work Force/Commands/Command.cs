namespace Problem_04.Work_Force.Commands
{
    using Problem_04.Work_Force.Commands.Interfaces;
    using Problem_04.Work_Force.Data.Interfaces;

    public abstract class Command : ICommand
    {
        public abstract void Execute(string[] commandParams, IRepository repository);
    }
}
