namespace Problem_02.Kings_Gambit.Models
{
    using System;

    using Problem_02.Kings_Gambit.Events;
    using Problem_02.Kings_Gambit.Interfaces;

    public class Footman : Guard
    {
        public Footman(string name, IAttackable king)
            : base(name, king)
        {
        }

        public override void ReactOnAttack(object sender, EventArgs args)
        {
            var result = $"{this.GetType().Name} {this.Name} is panicking!";

            Console.WriteLine(result);
        }
    }
}
