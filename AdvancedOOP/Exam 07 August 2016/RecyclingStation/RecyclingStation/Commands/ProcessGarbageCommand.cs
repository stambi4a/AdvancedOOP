namespace RecyclingStation.Commands
{
    using RecyclingStation.Attributes;
    using RecyclingStation.Factories;
    using RecyclingStation.Interfaces;

    [Command("ProcessGarbage")]
    public class ProcessGarbageCommand : Command
    {
        public override string Execute(IResourcesController resController, string[] commandParams)
        {
            var name = commandParams[0];
            var weight = double.Parse(commandParams[1]);
            var volumePerKg = double.Parse(commandParams[2]);
            var garbageType = commandParams[3];
            var waste = GarbageFactory.CreateWaste(new object[] { name, weight, volumePerKg }, garbageType);
            string result = null;
            var processingData = resController.ProcessWaste(waste, out result);
            if (result != null)
            {
                return result;
            }

            resController.AddProccessingData(processingData);

            return $"{weight:f2} kg of {name} successfully processed!";
        }
    }
}
