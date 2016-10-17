namespace Problem_05.Kings_Gambit_Extended.Events
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
