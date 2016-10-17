namespace Problem_06.Mirror_Image.Interfaces
{
    public interface IRepository
    {
        IWizard GetWizard(int id);
        void AddWizard(string name, int magicalPower, int id = 0);

        void AddWizardClones(int id);
    }
}
