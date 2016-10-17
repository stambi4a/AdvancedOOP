namespace Problem_04.Work_Force
{
    using Problem_04.Work_Force.Core;
    using Problem_04.Work_Force.Data;

    public class Launcher
    {
        private static void Main(string[] args)
        {
            var repository = new Repository();
            var engine = new Engine(repository);
            engine.Run();
        }
    }
}
