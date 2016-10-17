namespace Problem_06.Mirror_Image.Core
{
    using Problem_06.Mirror_Image.Factories;
    using Problem_06.Mirror_Image.Interfaces;
    public class CommandExecutor : ICommandExecutor
    {
        private IRepository repository;

        public CommandExecutor(IRepository repo)
        {
            this.repository = repo;
        }

        public void Execute(string commandName, string[] commandParams)
        {
            var command = CommandFactory.CreateCommand(commandName);
            command.Execute(commandParams, this.repository);
        }
    }
}
