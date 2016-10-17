namespace Problem_08.Military_Elite
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;

    using Factories;
    using Interfaces;

    using Problem_08.Military_Elite.Exceptions;

    public class Program
    {
        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var soldiersWithIds = new Dictionary<string, ISoldier>();
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    if (input == "End")
                    {
                        break;
                    }

                    var soldierParams = input.Split();
                    var soldier = SoldierFactory.CreateSoldier(soldierParams, soldiersWithIds);
                    Console.WriteLine(soldier);
                    soldiersWithIds.Add(soldier.Id, soldier);
                }
                catch (InvalidCorpsTypeException)
                {
                }
                
            }
        }

        private static void PrintSoldiers(IEnumerable<ISoldier> soldiers)
        {
            Console.WriteLine(string.Join(Environment.NewLine, soldiers));
        }
    }
}
