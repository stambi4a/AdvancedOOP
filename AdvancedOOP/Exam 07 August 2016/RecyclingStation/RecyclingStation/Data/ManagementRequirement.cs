namespace RecyclingStation.Data
{
    using RecyclingStation.Attributes;
    using RecyclingStation.Interfaces;

    [Requirement]
    public class ManagementRequirement : IManagementRequirement
    {
        public ManagementRequirement(double energy, double capital, string garbageType)
        {
            this.MinimumEnergy = energy;
            this.MinimumCapital = capital;
            this.GarbageType = garbageType;
        }

        public double MinimumEnergy { get; }

        public double MinimumCapital { get; }

        public string GarbageType { get; }
    }
}
