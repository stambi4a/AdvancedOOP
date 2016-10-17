namespace Problem_08.Military_Elite.Models
{
    using Interfaces;

    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public double Salary { get; protected set; }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:f2}";
            //return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}";
        }
    }
}
