namespace Problem_06.Mirror_Image.Data
{
    using System.Collections.Generic;

    using Problem_06.Mirror_Image.Events;
    using Problem_06.Mirror_Image.Factories;
    using Problem_06.Mirror_Image.Interfaces;
    public class Repository : IRepository
    {
        private readonly Dictionary<int, IWizard> wizards;

        public Repository()
        {
            this.wizards = new Dictionary<int, IWizard>();
        }

        public IWizard GetWizard(int id)
        {
            return this.wizards[id];
        }

        public void AddWizard(string name, int magicalPower, int id = 0)
        {
            var wizard = WizardFactory.CreateWizard(name, magicalPower, id);
            this.wizards.Add(id, wizard);
        }

        public void AddWizardClones(int id)
        {
            var wizard = this.GetWizard(id);
            var name = wizard.Name;
            var magicalPower = wizard.MagicalPower / 2;
            var firstChild = WizardFactory.CreateWizard(name, magicalPower, this.wizards.Count);
            this.wizards.Add(this.wizards.Count, firstChild);
            var secondChild = WizardFactory.CreateWizard(name, magicalPower, this.wizards.Count);
            this.wizards.Add(this.wizards.Count, secondChild);
            wizard.CastMagic += firstChild.Cast;
            wizard.CastMagic += secondChild.Cast;
        }
    }
}
