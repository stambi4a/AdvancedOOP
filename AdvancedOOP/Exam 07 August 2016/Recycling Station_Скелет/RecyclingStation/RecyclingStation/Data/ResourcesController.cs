namespace RecyclingStation.Data
{
    using RecyclingStation.Interfaces;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class ResourcesController : IResourcesController
    {
        private readonly IGarbageProcessor garbageProcessor;
        private readonly IResourcesDatabase database;

        public ResourcesController(IResourcesDatabase database, IGarbageProcessor garbageProcessor)
        {
            this.database = database;
            this.garbageProcessor = garbageProcessor;
        }

        public IProcessingData ProcessWaste(IWaste waste)
        {
            return this.garbageProcessor.ProcessWaste(waste);
        }

        public void AddProccessingData(IProcessingData processingData)
        {
            this.database.Capital += processingData.CapitalBalance;
            this.database.Energy += processingData.EnergyBalance;
        }

        public string PrintRecyclingStationStatus()
        {
            return $"Energy: {this.database.Energy:f2} Capital {this.database.Capital:f2}";
        }
    }
}
