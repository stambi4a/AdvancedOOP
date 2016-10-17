namespace RecyclingStation.Models.DIsposalStrategies
{
    using RecyclingStation.WasteDisposal.Interfaces;
    public abstract class GarbageDisposableStrategy : IGarbageDisposalStrategy
    {
        public abstract IProcessingData ProcessGarbage(IWaste garbage);
    }
}
