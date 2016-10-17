namespace Problem_04.BarracksWars___The_Commands_Strike_Back.Models.Units
{
    public class Horseman : Unit
    {
        private const int DefaultHealth = 50;
        private const int DefaultDamage = 10;

        public Horseman() 
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}
