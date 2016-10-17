namespace Problem_06.Mirror_Image.Commands
{
    using System;

    using Problem_06.Mirror_Image.Events;
    using Problem_06.Mirror_Image.Interfaces;

    public class ReflectionCommand : Command
    {
        public override void Execute(string[] commandParams, IRepository repository)
        {
            var id = int.Parse(commandParams[0]);
            var wizard = repository.GetWizard(id);

            var args = new CastMagicEventArgs($"Reflection");
            wizard.Cast(wizard, args);
            foreach (var wizardId in args.CastedWizardsIds)
            {
                repository.AddWizardClones(wizardId);
            }
        }
    }
}
