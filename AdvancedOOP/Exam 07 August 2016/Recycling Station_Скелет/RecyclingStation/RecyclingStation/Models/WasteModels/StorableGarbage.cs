namespace RecyclingStation.Models.WasteModels
{
    using RecyclingStation.WasteDisposal.Attributes;

    [StorableGarbageDisposable]
    public class StorableGarbage : Garbage
    {
        public StorableGarbage(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight)
        {
        }
    }
}
