namespace Problem_10.Inferno_Infinity.Core
{
    using System;

    using Problem_10.Inferno_Infinity.Data;

    public class Engine
    {
        private readonly WeaponsController weaponsController;

        private readonly CommandExecutor commandExecutor;

        public Engine()
        {
            this.weaponsController = new WeaponsController(new WeaponsDatabase());
            this.commandExecutor = new CommandExecutor();
        }
        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split(';');
                var result = this.commandExecutor.Execute(input, this.weaponsController);
                if (result)
                {
                    break;
                }
            }
        }
    }
}
