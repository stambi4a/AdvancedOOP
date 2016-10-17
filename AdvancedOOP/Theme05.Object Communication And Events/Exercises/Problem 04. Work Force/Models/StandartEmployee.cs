namespace Problem_04.Work_Force.Models
{
    public class StandartEmployee : Employee
    {
        private const int StandrardEmployeeWorkHoursPerWeek = 40;
        public StandartEmployee(string name)
            : base(name, StandrardEmployeeWorkHoursPerWeek)
        {
        }
    }
}
