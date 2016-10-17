namespace Problem_02.Kings_Gambit.Factories
{
    using System;

    using Problem_02.Kings_Gambit.Interfaces;
    using Problem_02.Kings_Gambit.Models;

    public class GuardFactory
    {
        public static Guard CreateGuard(string type, string name, IAttackable king)
        {
            var guardType = Type.GetType("Problem_02.Kings_Gambit.Models." + type);
            var guard = (Guard)Activator.CreateInstance(guardType, new object[] {name, king});

            return guard;
        }
    }
}
