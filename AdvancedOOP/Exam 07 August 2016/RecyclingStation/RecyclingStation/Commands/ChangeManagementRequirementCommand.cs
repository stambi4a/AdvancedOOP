namespace RecyclingStation.Commands
{
    using RecyclingStation.Attributes;
    using RecyclingStation.Factories;
    using RecyclingStation.Interfaces;

    [Command("ChangeManagementRequirement")]
    public class ChangeManagementRequirementCommand : Command
    {
        public override string Execute(IResourcesController resController, params string[] commandParams)
        {
            var requirement = ManagementRequirementFactory.CreateRequirement(commandParams);
            resController.ChangeManagementRequirement(requirement);
            return "Management requirement changed!";
        }
    }
}
