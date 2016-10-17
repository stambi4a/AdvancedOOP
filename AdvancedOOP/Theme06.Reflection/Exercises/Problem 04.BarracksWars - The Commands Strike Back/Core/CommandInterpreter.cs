namespace Problem_04.BarracksWars___The_Commands_Strike_Back.Core
{
    using Problem_04.BarracksWars___The_Commands_Strike_Back.Contracts;
    using Problem_04.BarracksWars___The_Commands_Strike_Back.Core.Factories;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IRepository repository;

        private readonly IUnitFactory unitFactory;
        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var command = CommandFactory.CreateCommand(this.repository, this.unitFactory, data, commandName);

            return command;
        }
    }
}
