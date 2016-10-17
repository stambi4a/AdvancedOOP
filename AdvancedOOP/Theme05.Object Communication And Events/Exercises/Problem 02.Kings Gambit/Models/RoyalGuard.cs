namespace Problem_02.Kings_Gambit.Models
{
    using System;

    using Interfaces;

    public class RoyalGuard : Guard
    {
        public RoyalGuard(string name, IAttackable king)
            : base(name, king)
        {
            
        }

        public override void ReactOnAttack(object sender, EventArgs args)
        {
            var result = $"Royal Guard {this.Name} is defending!";

            Console.WriteLine(result);
        }
    }
}
