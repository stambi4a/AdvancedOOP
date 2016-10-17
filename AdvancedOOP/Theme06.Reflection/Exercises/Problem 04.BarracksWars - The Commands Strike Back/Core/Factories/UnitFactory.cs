namespace Problem_04.BarracksWars___The_Commands_Strike_Back.Core.Factories
{
    using System;

    using Problem_04.BarracksWars___The_Commands_Strike_Back.Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            IUnit unit = null;
            var type = Type.GetType("Problem_04.BarracksWars___The_Commands_Strike_Back.Models.Units." + unitType);
            unit = (IUnit)Activator.CreateInstance(type);
            return unit;
        }
    }
}
