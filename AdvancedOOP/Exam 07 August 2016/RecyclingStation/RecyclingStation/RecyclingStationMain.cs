namespace RecyclingStation
{
    using System;
    using System.Linq;
    using System.Reflection;

    using RecyclingStation.Core;
    using RecyclingStation.Data;
    using RecyclingStation.WasteDisposal.Attributes;

    public class RecyclingStationMain
    {
        private static void Main(string[] args)
        {
            var resourcesDatabase = new ResourcesDatabase();
            var engine = new Engine(resourcesDatabase);
            engine.Run();
        }
    }
}
