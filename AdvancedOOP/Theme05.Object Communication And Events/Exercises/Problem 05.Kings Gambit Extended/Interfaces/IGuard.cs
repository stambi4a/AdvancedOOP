namespace Problem_05.Kings_Gambit_Extended.Interfaces
{
    using System;

    public interface IGuard
    {
        IAttackable King { get; }
        void ReactOnAttack(object sender, EventArgs args);
    }
}
