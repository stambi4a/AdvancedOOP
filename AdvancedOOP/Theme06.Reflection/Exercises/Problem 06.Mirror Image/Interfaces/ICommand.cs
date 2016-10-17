namespace Problem_06.Mirror_Image.Interfaces
{
    public interface ICommand
    {
        void Execute(string[] commandParams, IRepository repository);
    }
}
