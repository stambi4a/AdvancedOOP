namespace RecyclingStation.Interfaces
{
    public interface ICommand
    {
        string Execute(IResourcesController resController, params string[] commandParams);
    }
}
