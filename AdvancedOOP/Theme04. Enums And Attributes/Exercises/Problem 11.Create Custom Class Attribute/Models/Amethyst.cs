namespace Problem_11.Create_Custom_Class_Attribute.Models
{
    using Problem_11.Create_Custom_Class_Attribute.Enums;

    public class Amethyst : Gem
    {
        private const int AmethystStrengthIncrease = 2;
        private const int AmethystAgilityIncrease = 8;
        private const int AmethystVitalityIncrease = 4;
        public Amethyst(Clarity clarity)
            : base(AmethystStrengthIncrease, AmethystAgilityIncrease, AmethystVitalityIncrease, clarity)
        {
        }
    }
}
