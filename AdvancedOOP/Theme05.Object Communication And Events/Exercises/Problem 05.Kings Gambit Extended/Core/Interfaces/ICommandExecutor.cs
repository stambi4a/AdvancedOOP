namespace Problem_05.Kings_Gambit_Extended.Core.Interfaces
{
    using Problem_05.Kings_Gambit_Extended.Repository.Interfaces;

    public interface ICommandExecutor
    {
        void Execute(string [] input, IKingdomRepository repository);
    }
}
