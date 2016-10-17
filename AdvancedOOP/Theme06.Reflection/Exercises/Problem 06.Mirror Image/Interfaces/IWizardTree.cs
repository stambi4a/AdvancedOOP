namespace Problem_06.Mirror_Image.Interfaces
{
    public interface IWizardTree
    {
        IWizardNode Root { get; }

        int Count { get; }

        void AddNode();

        void Traverse(int id);
    }
}
