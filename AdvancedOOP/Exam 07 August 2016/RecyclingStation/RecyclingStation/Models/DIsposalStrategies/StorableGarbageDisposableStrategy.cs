namespace RecyclingStation.Models.DIsposalStrategies
{
    using RecyclingStation.Factories;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class StorableGarbageDisposableStrategy : GarbageDisposableStrategy
    {
        private const double CapitalUsed = 0.65;
        private const double EnergyUsedMultiplier = 0.13;
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energy = garbage.VolumePerKg * garbage.Weight * -EnergyUsedMultiplier;
            var capital = garbage.VolumePerKg * garbage.Weight * -CapitalUsed;

            var processingData = ProcessingDataFactory.CreateProcessingData(energy, capital);

            return processingData;
        }
    }
}
