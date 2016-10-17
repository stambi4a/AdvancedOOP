namespace Problem_04.Work_Force.Commands
{
    using System;

    using Problem_04.Work_Force.Data.Interfaces;

    public class StatusCommand : Command
    {
        public override void Execute(string[] commandParams, IRepository repository)
        {
            repository.Print();
        }
    }
}
