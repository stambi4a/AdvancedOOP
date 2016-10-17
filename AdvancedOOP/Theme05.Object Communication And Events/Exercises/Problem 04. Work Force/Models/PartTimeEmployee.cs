namespace Problem_04.Work_Force.Models
{
    public class PartTimeEmployee : Employee
    {
        private const int PartTimeEmployeeWorkHoursPerWeek = 20;
        public PartTimeEmployee(string name)
            : base(name, PartTimeEmployeeWorkHoursPerWeek)
        {
        }
    }
}
