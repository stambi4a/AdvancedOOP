namespace Problem_04.BarracksWars___The_Commands_Strike_Back.Core
{
    using System;

    using Problem_04.BarracksWars___The_Commands_Strike_Back.Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        private ICommandInterpreter commandInterpreter;
        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
            this.commandInterpreter = new CommandInterpreter(this.repository, this.unitFactory);
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    var command = this.commandInterpreter.InterpretCommand(data, commandName);
                    var result = command.Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
