namespace Problem_02.Kings_Gambit.Models
{
    using System;

    using Interfaces;

    using Events;

    public class King : Person, IAttackable
    {

        public event KingAttackEventHandler KingAttack;

        public King(string name)
            : base(name)
        {
            this.KingAttack += this.ReactOnAttack;
        }

        public void GetAttacked()
        {
            this.OnAttack(EventArgs.Empty);
        }

        private void OnAttack(EventArgs e)
        {
            this.KingAttack?.Invoke(this, e);
        }

        public void ReactOnAttack(object sender, EventArgs args)
        {
            var result = $"King {this.Name} is under attack!";

            Console.WriteLine(result);
        }
    }
}
