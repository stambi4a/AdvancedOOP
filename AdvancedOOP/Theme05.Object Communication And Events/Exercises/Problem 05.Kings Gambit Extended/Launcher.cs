namespace Problem_05.Kings_Gambit_Extended
{
    using Problem_05.Kings_Gambit_Extended.Core;
    using Problem_05.Kings_Gambit_Extended.Core.Interfaces;
    using Problem_05.Kings_Gambit_Extended.Repository;
    using Problem_05.Kings_Gambit_Extended.Repository.Interfaces;

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
