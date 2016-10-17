namespace Problem_04.Work_Force.Core
{
    using System;

    using Interface;

    using Problem_04.Work_Force.Data.Interfaces;

    public class Engine : IEngine
    {
        private readonly ICommandExecutor commandExecutor;

        private readonly IRepository repository;

        public Engine(IRepository repository)
        {
            this.commandExecutor = new CommandExecutor();
            this.repository = repository;
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var commandParams = input.Split();
                this.commandExecutor.ExecuteCommand(commandParams, this.repository);
            }
        }
    }
}
