namespace Problem_03.BarrackWars___A__New_Factory
{
    using Problem_03.BarrackWars___A__New_Factory.Contracts;
    using Problem_03.BarrackWars___A__New_Factory.Core;
    using Problem_03.BarrackWars___A__New_Factory.Core.Factories;
    using Problem_03.BarrackWars___A__New_Factory.Data;

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
