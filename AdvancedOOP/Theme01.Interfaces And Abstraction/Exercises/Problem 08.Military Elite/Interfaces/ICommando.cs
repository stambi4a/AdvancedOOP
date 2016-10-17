namespace Problem_08.Military_Elite.Interfaces
{
    using System.Collections.Generic;

    using Problem_08.Military_Elite.Enums;
    using Problem_08.Military_Elite.Models;

    public interface ICommando
    {
        List<Mission> Missions { get; }

        void AddMission(Mission mission);

        void CompleteMission(Mission mission);
    }
}
