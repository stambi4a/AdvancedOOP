namespace Problem_05.Kings_Gambit_Extended.Interfaces
{
    public interface IKillable
    {
        int Health { get; set; }
        bool IsKiled { get; }

        bool GetAttacked();
    }
}
