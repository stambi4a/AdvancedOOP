namespace Problem_11.Create_Custom_Class_Attribute.Core
{
    using System;

    using Problem_11.Create_Custom_Class_Attribute.Data;

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
