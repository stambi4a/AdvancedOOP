namespace RecyclingStation.Interfaces
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public interface IResourcesController
    {
        void AddProccessingData(IProcessingData processingData);

        string PrintRecyclingStationStatus();

        IProcessingData ProcessWaste(IWaste waste);
    }
}
