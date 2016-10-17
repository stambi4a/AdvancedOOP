namespace Problem_05.Kings_Gambit_Extended.Interfaces
{
    using System;

    using Problem_05.Kings_Gambit_Extended.Events;

    public interface IAttackable
    {
        event KingAttackEventHandler KingAttack;

        void ReactOnAttack(object sender, EventArgs args);

        void GetAttacked();
    }
}
