namespace Problem_02.Kings_Gambit.Models
{
    using System;

    using Problem_02.Kings_Gambit.Interfaces;

    public abstract class Guard : Person, IKillable, IGuard
    {
        protected Guard(string name, IAttackable king)
            : base(name)
        {
            this.IsKiled = false;
            this.King = king;
            this.AssignWatch();
        }

        public IAttackable King { get; }
        private void AssignWatch()
        {
            this.King.KingAttack += this.ReactOnAttack;
        }

        public bool IsKiled { get; protected set; }

        public void GetKilled()
        {
            this.IsKiled = true;
            this.King.KingAttack -= this.ReactOnAttack;
        }

        public abstract void ReactOnAttack(object sender, EventArgs args);
    }
}
