namespace Problem_04.BarracksWars___The_Commands_Strike_Back
{
    using Problem_04.BarracksWars___The_Commands_Strike_Back.Contracts;
    using Problem_04.BarracksWars___The_Commands_Strike_Back.Core;
    using Problem_04.BarracksWars___The_Commands_Strike_Back.Core.Factories;
    using Problem_04.BarracksWars___The_Commands_Strike_Back.Data;

    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}
