namespace Problem_06.Mirror_Image.Factories
{
    using System;

    using Problem_06.Mirror_Image.Interfaces;
    using Problem_06.Mirror_Image.Models;

    public class WizardFactory
    {
        public static IWizard CreateWizard(string name, int magicalPower, int id)
        {
            var type = typeof(Wizard);
            var wizard = (IWizard)Activator.CreateInstance(type, new object[] { name, magicalPower, id });

            return wizard;
        }
    }
}
