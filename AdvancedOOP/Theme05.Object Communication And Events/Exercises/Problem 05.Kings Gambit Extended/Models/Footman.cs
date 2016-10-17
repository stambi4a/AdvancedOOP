namespace Problem_05.Kings_Gambit_Extended.Models
{
    using System;

    using Problem_05.Kings_Gambit_Extended.Interfaces;

    public class Footman : Guard
    {
        private const int FootmanHealth = 2;
        public Footman(string name, IAttackable king)
            : base(name, king, FootmanHealth)
        {
        }

        public override void ReactOnAttack(object sender, EventArgs args)
        {
            var result = $"{this.GetType().Name} {this.Name} is panicking!";

            Console.WriteLine(result);
        }
    }
}
