namespace RecyclingStation.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using RecyclingStation.Attributes;
    using RecyclingStation.Interfaces;

    public class ManagementRequirementFactory
    {
        public static IManagementRequirement CreateRequirement(string[] requirementParams)
        {
            var energy = double.Parse(requirementParams[0]);
            var capital = double.Parse(requirementParams[1]);
            var garbageType = requirementParams[2];
            var requirementType =
               Assembly.GetExecutingAssembly()
                   .GetTypes()
                   .First(typ => typ.GetCustomAttributes().Any(x => x.GetType() == typeof(RequirementAttribute)));
            var requirement =
                (IManagementRequirement)
                Activator.CreateInstance(requirementType, new object[] { energy, capital, garbageType });

            return requirement;
        }
    }
}
