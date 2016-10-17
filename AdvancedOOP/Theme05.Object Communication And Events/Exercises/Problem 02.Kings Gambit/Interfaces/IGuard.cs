namespace Problem_02.Kings_Gambit.Interfaces
{
    using System;

    public interface IGuard
    {
        IAttackable King { get; }
        void ReactOnAttack(object sender, EventArgs args);
    }
}
