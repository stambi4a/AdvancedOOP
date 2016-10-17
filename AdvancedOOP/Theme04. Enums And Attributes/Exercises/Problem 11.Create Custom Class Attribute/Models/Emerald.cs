namespace Problem_11.Create_Custom_Class_Attribute.Models
{
    using Problem_11.Create_Custom_Class_Attribute.Enums;

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
