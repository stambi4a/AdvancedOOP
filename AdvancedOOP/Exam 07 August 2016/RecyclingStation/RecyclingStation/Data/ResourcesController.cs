namespace RecyclingStation.Data
{
    using RecyclingStation.Interfaces;
    using RecyclingStation.Models;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class ResourcesController : IResourcesController
    {
        private readonly IGarbageProcessor garbageProcessor;
        private readonly IResourcesDatabase database;

        public ResourcesController(IResourcesDatabase database, IGarbageProcessor garbageProcessor)
        {
            this.database = database;
            this.garbageProcessor = garbageProcessor;
            this.ManagementRequirement = null;
        }

        public IManagementRequirement ManagementRequirement { get; private set; }
 
        public void ChangeManagementRequirement(IManagementRequirement managementRequirement)
        {
            this.ManagementRequirement = managementRequirement;
        }

        public IProcessingData ProcessWaste(IWaste waste, out string result)
        {
            if (!this.CheckWasteIsAccordingRequirements(waste))
            {
                result = "Processing Denied!";
                return null;
            }

            result = null;
            return this.garbageProcessor.ProcessWaste(waste);
        }

        public void AddProccessingData(IProcessingData processingData)
        {
            this.database.Capital += processingData.CapitalBalance;
            this.database.Energy += processingData.EnergyBalance;
        }

        public string PrintRecyclingStationStatus()
        {
            return $"Energy: {this.database.Energy:f2} Capital: {this.database.Capital:f2}";
        }

        private bool CheckWasteIsAccordingRequirements(IWaste waste)
        {
            var isValid = (this.ManagementRequirement == null 
                           || !waste.GetType().Name.StartsWith(this.ManagementRequirement.GarbageType)
                           || (waste.GetType().Name.StartsWith(this.ManagementRequirement.GarbageType)
                               && this.database.Energy >= this.ManagementRequirement.MinimumEnergy
                               && this.database.Capital >= this.ManagementRequirement.MinimumCapital));

            return isValid;
        }
    }
}
