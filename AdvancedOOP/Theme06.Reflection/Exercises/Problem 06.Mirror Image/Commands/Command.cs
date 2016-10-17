namespace Problem_06.Mirror_Image.Commands
{
    using Problem_06.Mirror_Image.Interfaces;
    public abstract class Command : ICommand
    {
        public abstract void Execute(string[] commandParams, IRepository repository);
    }
}
