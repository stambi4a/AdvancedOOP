namespace Problem_05.Kings_Gambit_Extended.Factories
{
    using System;

    using Problem_05.Kings_Gambit_Extended.Interfaces;
    using Problem_05.Kings_Gambit_Extended.Models;

    public class GuardFactory
    {
        public static Guard CreateGuard(string type, string name, IAttackable king)
        {
            var guardType = Type.GetType("Problem_05.Kings_Gambit_Extended.Models." + type);
            var guard = (Guard)Activator.CreateInstance(guardType, new object[] {name, king});

            return guard;
        }
    }
}
