namespace RecyclingStation.Models.WasteModels
{
    using RecyclingStation.WasteDisposal.Interfaces;
    public class Garbage : IWaste
    {
        public Garbage(string name, double weight, double volumePerKg)
        {
            this.Name = name;
            this.VolumePerKg = volumePerKg;
            this.Weight = weight;
        }

        public string Name { get; }

        public double VolumePerKg { get; }

        public double Weight { get; }
    }
}
