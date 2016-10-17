namespace Problem_04.Work_Force.Models
{
    using Problem_04.Work_Force.Models.Interfaces;
    public abstract class Employee : IEmployee
    {
        protected Employee(string name, int workhours)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workhours;
        }

        public string Name { get; }

        public int WorkHoursPerWeek { get; }
    }
}
