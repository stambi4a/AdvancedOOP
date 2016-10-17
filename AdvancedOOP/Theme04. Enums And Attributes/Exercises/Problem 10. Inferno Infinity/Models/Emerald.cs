namespace Problem_10.Inferno_Infinity.Models
{
    using Problem_10.Inferno_Infinity.Enums;

    public class Emerald : Gem
    {
        private const int EmeraldStrengthIncrease = 1;
        private const int EmeraldAgilityIncrease = 4;
        private const int EmeraldVitalityIncrease = 9;
        public Emerald(Clarity clarity)
            : base(EmeraldStrengthIncrease, EmeraldAgilityIncrease, EmeraldVitalityIncrease, clarity)
        {
        }
    }
}
