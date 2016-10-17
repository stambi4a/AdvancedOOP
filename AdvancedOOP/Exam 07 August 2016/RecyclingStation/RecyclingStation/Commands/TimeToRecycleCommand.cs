namespace RecyclingStation.Commands
{
    using System;

    using RecyclingStation.Attributes;
    using RecyclingStation.Interfaces;

    [Command("TimeToRecycle")]
    public class TimeToRecycleCommand : Command
    {
        public override string Execute(IResourcesController resController, params string[] commandParams)
        {
            Environment.Exit(0);

            return null;
        }
    }
}
