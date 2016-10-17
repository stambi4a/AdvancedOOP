namespace Problem_10.Inferno_Infinity.Models
{
    using Problem_10.Inferno_Infinity.Enums;

    public abstract class Gem
    {
        protected Gem(int strengthPlus, int agilityPlus, int vitalityPlus, Clarity clarity)
        {
            this.Clarity = clarity;
            this.CalculateStrengthIncrease(strengthPlus);
            this.CalculateAgilityIncrease(agilityPlus);
            this.CalculateVitalityIncrease(vitalityPlus);
        }

        public int StrengthIncrease { get; protected set; }

        public int AgilityIncrease { get; protected set; }

        public int VitalityIncrease { get; protected set; }

        private void CalculateStrengthIncrease(int strengthIncrease)
        {
            this.StrengthIncrease = strengthIncrease + (int)this.Clarity;
        }

        private void CalculateAgilityIncrease(int agilityIncrease)
        {
            this.AgilityIncrease = agilityIncrease + (int)this.Clarity;
        }

        private void CalculateVitalityIncrease(int vitalityIncrease)
        {
            this.VitalityIncrease = vitalityIncrease + (int)this.Clarity;
        }

        public Clarity Clarity { get; protected set; }
    }
}
