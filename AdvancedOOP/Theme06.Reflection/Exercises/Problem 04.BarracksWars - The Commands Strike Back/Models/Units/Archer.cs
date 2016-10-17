namespace Problem_04.BarracksWars___The_Commands_Strike_Back.Models.Units
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
