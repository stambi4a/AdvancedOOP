namespace Problem_03.BarrackWars___A__New_Factory.Models.Units
{
    public class Gunner : Unit
    {
        private const int DefaultHealth = 20;
        private const int DefaultDamage = 10;

        public Gunner()
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}
