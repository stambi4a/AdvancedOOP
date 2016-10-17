namespace RecyclingStation.Interfaces
{
    public interface IManagementRequirement
    {
        double MinimumEnergy { get; }

        double MinimumCapital { get; }

        string GarbageType { get; }
    }
}
