namespace Problem_02.Kings_Gambit.Interfaces
{
    using System;

    using Problem_02.Kings_Gambit.Events;

    public interface IAttackable
    {
        event KingAttackEventHandler KingAttack;

        void ReactOnAttack(object sender, EventArgs args);

        void GetAttacked();
    }
}
