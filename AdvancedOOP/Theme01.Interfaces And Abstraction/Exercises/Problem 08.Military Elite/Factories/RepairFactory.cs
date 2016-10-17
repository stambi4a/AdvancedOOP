namespace Problem_08.Military_Elite.Factories
{
    using Problem_08.Military_Elite.Interfaces;
    using Problem_08.Military_Elite.Models;

    public class RepairFactory
    {
        public static Repair CreateRepair(string repairItem, string repairHours)
        {
            var hoursWorked = int.Parse(repairHours);
            return new Repair(repairItem, hoursWorked);
        }
    }
}
