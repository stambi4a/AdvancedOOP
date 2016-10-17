namespace Problem_04.Work_Force.Models.Interfaces
{
    using System.Security.Cryptography.X509Certificates;

    public interface IEmployee
    {
        string Name { get; }

        int WorkHoursPerWeek { get; }
    }
}
