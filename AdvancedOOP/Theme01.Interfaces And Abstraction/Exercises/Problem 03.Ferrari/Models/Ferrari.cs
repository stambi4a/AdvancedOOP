namespace Problem_03.Ferrari.Models
{
    public class Ferrari : Car
    {
        private const string FerrariModel = "488-Spider";

        public Ferrari(string name)
            : base(name, FerrariModel)
        {           
        }

        public override string PushTheGas()
        {
            return "Zadu6avam sA!";
        }

        public override string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.UseBrakes()}/{this.PushTheGas()}/{this.DriverName}";
        }
    }
}
