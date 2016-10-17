namespace Problem_11.Create_Custom_Class_Attribute.Models
{
    using Problem_11.Create_Custom_Class_Attribute.Enums;

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
