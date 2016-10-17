namespace Problem_03.Ferrari.Interfaces
{
    public interface ICar
    {
        string DriverName { get; }

        string Model { get; }

        string UseBrakes();

        string PushTheGas();
    }
}
