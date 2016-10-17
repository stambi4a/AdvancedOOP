namespace Problem_04.BarracksWars___The_Commands_Strike_Back.Models.Units
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
