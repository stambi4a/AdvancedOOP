namespace Problem_06.Mirror_Image.Data
{
    using Problem_06.Mirror_Image.Interfaces;

    public class WizardNode : IWizardNode
    {
        public WizardNode(int id)
        {
            this.Id = id;
            this.LeftChild = null;
            this.RightChild = null;
        }
        public int Id { get; }

        public bool HasChildren => this.LeftChild != null;

        public IWizardNode LeftChild { get; }

        public IWizardNode RightChild { get; }
    }
}
