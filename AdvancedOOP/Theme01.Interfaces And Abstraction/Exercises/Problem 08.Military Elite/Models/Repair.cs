namespace Problem_08.Military_Elite.Models
{
    using Problem_08.Military_Elite.Interfaces;
    public class Repair : IRepair
    {
        public Repair(string part, int hours)
        {
            this.PartName = part;
            this.HoursWorked = hours;
        }
        public string PartName { get; }

        public int HoursWorked { get; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
