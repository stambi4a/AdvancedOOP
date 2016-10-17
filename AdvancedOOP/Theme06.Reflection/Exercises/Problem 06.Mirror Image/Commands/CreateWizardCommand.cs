namespace Problem_06.Mirror_Image.Commands
{
    using Problem_06.Mirror_Image.Interfaces;

    public class CreateWizardCommand : Command
    {
        public override void Execute(string[] commandParams, IRepository repository)
        {
            var name = commandParams[0];
            var magicalPower = int.Parse(commandParams[1]);
            repository.AddWizard(name, magicalPower);
        }
    }
}
