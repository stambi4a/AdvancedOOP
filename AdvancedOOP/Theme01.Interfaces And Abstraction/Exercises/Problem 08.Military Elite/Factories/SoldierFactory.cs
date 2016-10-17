namespace Problem_08.Military_Elite.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Problem_08.Military_Elite.Exceptions;
    using Problem_08.Military_Elite.Interfaces;
    using Problem_08.Military_Elite.Models;

    public class SoldierFactory
    {
        public static ISoldier CreateSoldier(string[] soldierParams, IReadOnlyDictionary<string, ISoldier> soldiers)
        {
            var soldierType = soldierParams[0];
            var id = soldierParams[1];
            var firstName = soldierParams[2];
            var lastName = soldierParams[3];
            switch (soldierType)
            {
                case "Private":
                    {
                        
                        var salary = double.Parse(soldierParams[4]);

                        return new Private(id, firstName, lastName, salary);
                    }

                case "Spy":
                    {
                        var codeNumber = int.Parse(soldierParams[4]);

                        return new Spy(id, firstName, lastName, codeNumber);
                    }

                case "Commando":
                    {
                        var salary = double.Parse(soldierParams[4]);
                        var corps = soldierParams[5];
                        var missionsParams = soldierParams.Skip(6).ToArray();

                        var commando = new Commando(id, firstName, lastName, salary, corps);
                        for (var i = 0; i < missionsParams.Count(); i = i + 2)
                        {
                            try
                            {
                                var mission = MissionFactory.CreateMission(missionsParams[i], missionsParams[i + 1]);
                                commando.AddMission(mission);
                            }
                            catch (InvalidMissionStateException)
                            {
                            }
                            
                        }

                        return commando;
                    }

                case "Engineer":
                    {
                        var salary = double.Parse(soldierParams[4]);
                        var corps = soldierParams[5];

                        var repairParams = soldierParams.Skip(6).ToArray();

                        var engineer = new Engineer(id, firstName, lastName, salary, corps);
                        for (var i = 0; i < repairParams.Count(); i = i + 2)
                        {
                            var repair = RepairFactory.CreateRepair(repairParams[i], repairParams[i +1 ]);
                            engineer.AddRepair(repair);
                        }

                        return engineer;
                    }

                case "LeutenantGeneral":
                    {
                        var salary = double.Parse(soldierParams[4]);

                        var soldierIds = soldierParams.Skip(5).ToArray();
                        var leutenantGeneral = new LeutenantGeneral(id, firstName, lastName, salary);
                        for (var i = 0; i < soldierIds.Count(); i++)
                        {
                            var soldierId = soldierIds[i];
                            leutenantGeneral.AddPrivate(soldiers[soldierId] as Private);
                        }

                        return leutenantGeneral;
                    }

                default:
                    {
                        throw new InvalidSoldierTypeException();
                    }
            }
        }
    }
}
