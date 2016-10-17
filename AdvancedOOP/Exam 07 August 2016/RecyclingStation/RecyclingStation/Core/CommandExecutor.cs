namespace RecyclingStation.Core
{
    using RecyclingStation.Factories;
    using RecyclingStation.Interfaces;

    public class CommandExecutor : ICommandExecutor
    {
        private readonly IResourcesController resController;
        public CommandExecutor(IResourcesController resController)
        {
            this.resController = resController;
        }
        public string Execute(string commandName, params string[] commandParams)
        {
            var command = CommandFactory.CreateCommand(commandName);

            return command.Execute(this.resController, commandParams);
        }
    }
}
