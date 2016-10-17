namespace Problem_05.Kings_Gambit_Extended.Core
{
    using Problem_05.Kings_Gambit_Extended.Core.Interfaces;
    using Problem_05.Kings_Gambit_Extended.Repository.Interfaces;

    public class CommandExecutor : ICommandExecutor
    {
        public void Execute(string[] input, IKingdomRepository repository)
        {
            var commandName = input[0];
            if (commandName == "Kill")
            {
                var guardName = input[1];
                repository.TryRemoveGuard(guardName);
            }

            if (commandName == "Attack")
            {
                repository.King.GetAttacked();
            }
        }

    }
}
