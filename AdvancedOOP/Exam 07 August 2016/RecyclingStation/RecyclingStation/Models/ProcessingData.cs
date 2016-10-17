namespace RecyclingStation.Models
{
    using RecyclingStation.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    [ProcessingData]
    public class ProcessingData : IProcessingData
    {
        public ProcessingData(double energyBalance, double capitalBalance)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = capitalBalance;
        }

        public double EnergyBalance { get; }

        public double CapitalBalance { get; }
    }
}
