namespace Problem_02.Kings_Gambit
{
    using Problem_02.Kings_Gambit.Core;
    using Problem_02.Kings_Gambit.Core.Interfaces;
    using Problem_02.Kings_Gambit.Repository;

    public class Launcher
    {
        private static void Main(string[] args)
        {
            IKingdomRepository repository = new KingdomRepository();
            IEngine engine = new Engine(repository);
            engine.Run();
        }
    }
}
