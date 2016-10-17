namespace Problem_03.BarrackWars___A__New_Factory.Models.Units
{
    public class Archer : Unit
    {
        private const int DefaultHealth = 25;
        private const int DefaultDamage = 7;

        public Archer() 
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}
