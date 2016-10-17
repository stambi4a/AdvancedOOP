namespace Problem_06.Mirror_Image.Commands
{
    using Problem_06.Mirror_Image.Events;
    using Problem_06.Mirror_Image.Interfaces;

    public class FireballCommand : Command
    {
        public override void Execute(string[] commandParams, IRepository repository)
        {
            var id = int.Parse(commandParams[0]);
            var wizard = repository.GetWizard(id);
            wizard.Cast(wizard, new CastMagicEventArgs("Fireball for {0} damage"));
        }
    }
}
