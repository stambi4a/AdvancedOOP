namespace RecyclingStation.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using RecyclingStation.Attributes;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class GarbageFactory
    {
        public static IWaste CreateWaste(object[] wasteParams, string garbageType)
        {
            var type =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .First(
                        typ => typ.GetCustomAttributes(true).Any(x => x.GetType().BaseType == typeof(DisposableAttribute) && x.GetType().Name.StartsWith(garbageType)));

            var waste = (IWaste)Activator.CreateInstance(type, wasteParams);

            return waste;
        }
    }
}
