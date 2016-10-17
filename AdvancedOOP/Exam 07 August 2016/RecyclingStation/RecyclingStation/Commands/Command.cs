namespace RecyclingStation.Commands
{
    using RecyclingStation.Interfaces;
    public abstract class Command : ICommand
    {
        public abstract string Execute(IResourcesController resController, params string[] commandParams);
    }
}
