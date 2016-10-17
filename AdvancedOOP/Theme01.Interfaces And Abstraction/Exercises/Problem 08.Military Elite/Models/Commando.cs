namespace Problem_08.Military_Elite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Problem_08.Military_Elite.Enums;
    using Problem_08.Military_Elite.Interfaces;
    public class Commando: SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, double salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; }

        public void AddMission(Mission mission)
        {
            this.Missions.Add(mission);
        }

        public void CompleteMission(Mission mission)
        {
            
        }

        public override string ToString()
        {
            var commandoBuilder = new StringBuilder();
            commandoBuilder.Append(base.ToString()).AppendLine();
            commandoBuilder.Append("Missions:");
            foreach (var mission in this.Missions)
            {
                commandoBuilder.AppendLine().Append(new string(' ', 2) + mission);
            }

            return commandoBuilder.ToString();
        }
    }
}
