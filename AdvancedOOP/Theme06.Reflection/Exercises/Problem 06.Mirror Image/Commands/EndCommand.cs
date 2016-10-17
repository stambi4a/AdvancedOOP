namespace Problem_06.Mirror_Image.Commands
{
    using System;

    using Problem_06.Mirror_Image.Interfaces;

    public class EndCommand : Command
    {
        public override void Execute(string[] commandParams, IRepository repository)
        {
            Environment.Exit(0);
        }
    }
}
