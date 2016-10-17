namespace Problem_08.Military_Elite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Problem_08.Military_Elite.Enums;
    using Problem_08.Military_Elite.Interfaces;
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, double salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<Repair>();
        }

        public List<Repair> Repairs { get; }

        public void AddRepair(Repair repair)
        {
            this.Repairs.Add(repair);
        }

        public override string ToString()
        {
            var engineerBuilder = new StringBuilder();
            engineerBuilder.Append(base.ToString()).AppendLine();
            engineerBuilder.Append("Repairs:");
            foreach (var repair in this.Repairs)
            {
                engineerBuilder.AppendLine().Append(new string(' ', 2) + repair);
            }

            return engineerBuilder.ToString();
        }
    }
}
