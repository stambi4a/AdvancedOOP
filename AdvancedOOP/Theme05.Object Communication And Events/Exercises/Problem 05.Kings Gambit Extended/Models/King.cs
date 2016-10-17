namespace Problem_05.Kings_Gambit_Extended.Models
{
    using System;

    using Problem_05.Kings_Gambit_Extended.Events;
    using Problem_05.Kings_Gambit_Extended.Interfaces;

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
