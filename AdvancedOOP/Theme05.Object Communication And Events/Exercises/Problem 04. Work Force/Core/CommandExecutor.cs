namespace Problem_04.Work_Force.Core
{
    using System.Linq;

    using Problem_04.Work_Force.Core.Interface;
    using Problem_04.Work_Force.Data.Interfaces;
    using Problem_04.Work_Force.Factories;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(string[] input, IRepository repository)
        {
            var command = CommandFactory.CreateCommand(input[0]);
            command.Execute(input, repository);
        }
    }
}
