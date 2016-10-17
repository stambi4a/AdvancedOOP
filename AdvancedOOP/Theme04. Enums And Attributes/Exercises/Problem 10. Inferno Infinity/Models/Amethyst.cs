namespace Problem_10.Inferno_Infinity.Models
{
    using Problem_10.Inferno_Infinity.Enums;

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
