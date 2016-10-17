namespace Problem_02.Kings_Gambit.Events
{
    using System;

    public class KingAttackEventArgs : EventArgs
    {
        public KingAttackEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
