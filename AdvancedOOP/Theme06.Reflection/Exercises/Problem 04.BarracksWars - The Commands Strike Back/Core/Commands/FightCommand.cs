namespace Problem_04.BarracksWars___The_Commands_Strike_Back.Core.Commands
{
    using System;

    using Problem_04.BarracksWars___The_Commands_Strike_Back.Contracts;

    public class FightCommand : Command
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
