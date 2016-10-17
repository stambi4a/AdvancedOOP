namespace Problem_10.Inferno_Infinity.Models
{
    using Problem_10.Inferno_Infinity.Enums;

    public class Ruby : Gem
    {
        private const int RubyStrengthIncrease = 7;
        private const int RubyAgilityIncrease = 2;
        private const int RubyVitalityIncrease = 5;
        public Ruby(Clarity clarity)
            : base(RubyStrengthIncrease, RubyAgilityIncrease, RubyVitalityIncrease, clarity)
        {
        }
    }
}
