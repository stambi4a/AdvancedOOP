namespace Problem_05.Kings_Gambit_Extended.Models
{
    using System;

    using Problem_05.Kings_Gambit_Extended.Interfaces;

    public class RoyalGuard : Guard
    {
        private const int RoyalGuardHealth = 3;
        public RoyalGuard(string name, IAttackable king)
            : base(name, king, RoyalGuardHealth)
        {
            
        }

        public override void ReactOnAttack(object sender, EventArgs args)
        {
            var result = $"Royal Guard {this.Name} is defending!";

            Console.WriteLine(result);
        }
    }
}
