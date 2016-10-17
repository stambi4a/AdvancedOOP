namespace RecyclingStation.Models.WasteModels
{
    using RecyclingStation.WasteDisposal.Attributes;

    [RecyclableGarbageDisposable]
    public class RecyclableGarbage : Garbage
    {
        public RecyclableGarbage(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight)
        {
        }
    }
}
