namespace RecyclingStation.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using RecyclingStation.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class ProcessingDataFactory
    {
        public static IProcessingData CreateProcessingData(double energy, double capital)
        {
            var type =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .First(
                        typ => typ.GetCustomAttributes(true).Any(x => x.GetType() == typeof(ProcessingDataAttribute)));

            var processingData = (IProcessingData)Activator.CreateInstance(type, new object[] { energy, capital });

            return processingData;
        }
    }
}
