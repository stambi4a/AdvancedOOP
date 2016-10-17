namespace Problem_08.Military_Elite.Factories
{
    using Problem_08.Military_Elite.Interfaces;
    using Problem_08.Military_Elite.Models;

    public class MissionFactory
    {
        public static Mission CreateMission(string missionName, string missionState)
        {
            
            var mission = new Mission(missionName, missionState);
            return mission;
        }
    }
}
