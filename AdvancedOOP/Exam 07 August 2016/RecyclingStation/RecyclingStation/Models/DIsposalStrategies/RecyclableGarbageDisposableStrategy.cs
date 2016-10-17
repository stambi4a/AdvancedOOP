namespace RecyclingStation.Models.DIsposalStrategies
{
    using RecyclingStation.Factories;
    using RecyclingStation.WasteDisposal.Interfaces;


    public class RecyclableGarbageDisposableStrategy : GarbageDisposableStrategy
    {
        private const double CapitalEarned = 400;
        private const double EnergyUsedMultiplier = 0.5;

        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energy = garbage.VolumePerKg * garbage.Weight * -EnergyUsedMultiplier;
            var capital = garbage.Weight * CapitalEarned;

            var processingData = ProcessingDataFactory.CreateProcessingData(energy, capital);
            return processingData;
        }
    }
}
