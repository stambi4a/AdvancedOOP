namespace Problem_02.Kings_Gambit.Core
{
    using System;

    using Problem_02.Kings_Gambit.Core.Interfaces;
    using Problem_02.Kings_Gambit.Factories;
    using Problem_02.Kings_Gambit.Models;
    using Problem_02.Kings_Gambit.Repository;

    public class Engine : IEngine
    {
        private readonly IKingdomRepository repository;

        private readonly ICommandExecutor executor;
        public Engine(IKingdomRepository repo)
        {
            this.repository = repo;
            this.executor = new CommandExecutor();
        }

        public void Run()
        {
            var kingName = Console.ReadLine();
            var king = new King(kingName);
            this.repository.AssignKing(king);

            var royalGuardNames= Console.ReadLine().Split();
            foreach (var name in royalGuardNames)
            {
                var guard = GuardFactory.CreateGuard("RoyalGuard", name, king);
                this.repository.AddGuard(guard);
            }

            var footmenNames = Console.ReadLine().Split();
            foreach (var name in footmenNames)
            {
                var guard = GuardFactory.CreateGuard("Footman", name, king);
                this.repository.AddGuard(guard);
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var commandParams = input.Split();
                this.executor.Execute(commandParams, this.repository);
            }
        }
    }
}
