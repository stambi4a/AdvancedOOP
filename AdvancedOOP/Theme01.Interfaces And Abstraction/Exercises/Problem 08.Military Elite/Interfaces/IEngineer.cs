namespace Problem_08.Military_Elite.Interfaces
{
    using System.Collections.Generic;

    using Problem_08.Military_Elite.Models;

    public interface IEngineer
    {
        List<Repair> Repairs { get; }

        void AddRepair(Repair repair);
    }
}
