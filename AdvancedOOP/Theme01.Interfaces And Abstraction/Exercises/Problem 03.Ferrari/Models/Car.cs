namespace Problem_03.Ferrari.Models
{
    using Problem_03.Ferrari.Interfaces;

    public abstract class Car : ICar
    {
        protected Car(string name, string model)
        {
            this.DriverName = name;
            this.Model = model;
        }

        public string DriverName { get; protected set; }

        public string Model { get; protected set; }

        public abstract string PushTheGas();

        public abstract string UseBrakes();
    }
}
