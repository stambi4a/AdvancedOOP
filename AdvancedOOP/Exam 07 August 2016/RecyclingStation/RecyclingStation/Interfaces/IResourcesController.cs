namespace RecyclingStation.Interfaces
{
    using System.Dynamic;

    using RecyclingStation.WasteDisposal.Interfaces;

    public interface IResourcesController
    {
        IManagementRequirement ManagementRequirement { get; }
        void AddProccessingData(IProcessingData processingData);

        string PrintRecyclingStationStatus();

        IProcessingData ProcessWaste(IWaste waste, out string result);

        void ChangeManagementRequirement(IManagementRequirement managementRequirement);
    }
}
