namespace Problem_04.Work_Force.Commands
{
    using Problem_04.Work_Force.Data.Interfaces;

    public class PassCommand : Command
    {
        public override void Execute(string[] commandParams, IRepository repository)
        {
            repository.Update();
        }
    }
}
