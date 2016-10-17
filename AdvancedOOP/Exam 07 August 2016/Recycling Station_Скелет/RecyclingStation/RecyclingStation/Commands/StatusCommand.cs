namespace RecyclingStation.Commands
{
    using RecyclingStation.Attributes;
    using RecyclingStation.Interfaces;

    [Command("Status")]
    public class StatusCommand : Command
    {
        public override string Execute(IResourcesController resController, params string[] commandParams)
        {
            var result  = resController.PrintRecyclingStationStatus();

            return result;
        }
    }
}
