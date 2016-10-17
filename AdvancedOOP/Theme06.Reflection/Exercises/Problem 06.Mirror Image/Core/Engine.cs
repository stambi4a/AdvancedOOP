namespace Problem_06.Mirror_Image.Core
{
    using System;

    using Problem_06.Mirror_Image.Interfaces;
    public class Engine : IEngine
    {
        public Engine(IRepository repository)
        {
            this.repository = repository;
            this.commandExecutor = new CommandExecutor(this.repository);
            this.commandInterpreter = new CommandInterpreter();
        }

        private readonly IRepository repository;

        private readonly ICommandExecutor commandExecutor;

        private readonly ICommandInterpreter commandInterpreter;
        public void Run()
        {
            string commandName = null;
            var input = Console.ReadLine();
            var commandParams = this.commandInterpreter.ParseInput(ref commandName, input);
            this.commandExecutor.Execute(commandName, commandParams);

            while (true)
            {
                input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                commandParams = this.commandInterpreter.ParseInput(ref commandName, input);
                this.commandExecutor.Execute(commandName, commandParams);
            }
        }
    }
}
