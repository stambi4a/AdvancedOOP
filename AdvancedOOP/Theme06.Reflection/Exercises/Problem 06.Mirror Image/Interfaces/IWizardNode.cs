namespace Problem_06.Mirror_Image.Interfaces
{
    public interface IWizardNode
    {
        int Id { get; }

        bool HasChildren { get; }
        IWizardNode LeftChild { get; }

        IWizardNode RightChild { get; }
    }
}
