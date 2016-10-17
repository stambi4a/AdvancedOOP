namespace Problem_02.Kings_Gambit.Core.Interfaces
{
    using Problem_02.Kings_Gambit.Repository;

    public interface ICommandExecutor
    {
        void Execute(string [] input, IKingdomRepository repository);
    }
}
