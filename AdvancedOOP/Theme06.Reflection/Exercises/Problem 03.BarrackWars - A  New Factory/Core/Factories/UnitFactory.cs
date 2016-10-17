namespace Problem_03.BarrackWars___A__New_Factory.Core.Factories
{
    using System;

    using Problem_03.BarrackWars___A__New_Factory.Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            IUnit unit = null;
            var type = Type.GetType("Problem_03.BarrackWars___A__New_Factory.Models.Units." + unitType);
            unit = (IUnit)Activator.CreateInstance(type);
            return unit;
        }
    }
}
