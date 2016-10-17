namespace RecyclingStation.Data
{
    using RecyclingStation.Interfaces;
    public class ResourcesDatabase : IResourcesDatabase
    {
        public ResourcesDatabase()
        {
            this.Energy = 0;
            this.Capital = 0;
        }

        public double Energy { get; set; }

        public double Capital { get; set; }
    }
}
