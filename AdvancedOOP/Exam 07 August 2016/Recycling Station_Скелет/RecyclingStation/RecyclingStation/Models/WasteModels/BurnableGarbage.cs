namespace RecyclingStation.Models.WasteModels
{
    using RecyclingStation.WasteDisposal.Attributes;

    [BurnableGarbageDisposable]
    public class BurnableGarbage : Garbage
    {
        public BurnableGarbage(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight)
        {
        }
    }
}
