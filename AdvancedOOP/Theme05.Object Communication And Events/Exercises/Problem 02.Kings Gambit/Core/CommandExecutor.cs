namespace Problem_02.Kings_Gambit.Core
{
    using System;

    using Problem_02.Kings_Gambit.Core.Interfaces;
    using Problem_02.Kings_Gambit.Repository;

    public class CommandExecutor : ICommandExecutor
    {
        public void Execute(string[] input, IKingdomRepository repository)
        {
            var commandName = input[0];
            if (commandName == "Kill")
            {
                var guardName = input[1];
                repository.RemoveGuard(guardName);
            }

            if (commandName == "Attack")
            {
                repository.King.GetAttacked();
            }
        }

    }
}
