namespace RecyclingStation.Models.DIsposalStrategies
{
    using RecyclingStation.Factories;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class BurnableGarbageDisposableStrategy : GarbageDisposableStrategy
    {
        private const double EnergyProducedMultiplier = 1;

        private const double EnergyUsedMultiplier = 0.2;

        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energy = garbage.VolumePerKg * garbage.Weight * (EnergyProducedMultiplier - EnergyUsedMultiplier);

            var processingData = ProcessingDataFactory.CreateProcessingData(energy, 0);

            return processingData;
        }
    }
}
