namespace Problem_05.Kings_Gambit_Extended.Models
{
    using System;

    using Problem_05.Kings_Gambit_Extended.Interfaces;

    public abstract class Guard : Person, IKillable, IGuard
    {
        protected Guard(string name, IAttackable king,int health)
            : base(name)
        {
            this.IsKiled = false;
            this.King = king;
            this.AssignWatch();
            this.Health = health;
        }

        public IAttackable King { get; }
        private void AssignWatch()
        {
            this.King.KingAttack += this.ReactOnAttack;
        }

        public int Health { get; set; }

        public bool IsKiled { get; protected set; }

        public bool GetAttacked()
        {
            this.Health--;
            if (this.Health > 0)
            {
                return false;
            }

            this.IsKiled = true;
            this.King.KingAttack -= this.ReactOnAttack;

            return true;
        }

        public abstract void ReactOnAttack(object sender, EventArgs args);
    }
}
