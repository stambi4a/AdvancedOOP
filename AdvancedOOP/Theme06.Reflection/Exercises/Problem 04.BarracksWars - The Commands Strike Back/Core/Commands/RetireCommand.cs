namespace Problem_04.BarracksWars___The_Commands_Strike_Back.Core.Commands
{
    using System;
    using System.Collections.Generic;

    using Problem_04.BarracksWars___The_Commands_Strike_Back.Contracts;

    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            try
            {
                string unitType = this.Data[1];
                this.Repository.RemoveUnit(unitType);

                return $"{unitType} retired!";
            }
            catch (KeyNotFoundException knfe)
            {
                return knfe.Message;
            }
        }
    }
}
