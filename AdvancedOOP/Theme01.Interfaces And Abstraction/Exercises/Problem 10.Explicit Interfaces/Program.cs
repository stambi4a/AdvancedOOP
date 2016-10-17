namespace Problem_10.Explicit_Interfaces
{
    using System;
    using System.Collections.Generic;

    using Problem_10.Explicit_Interfaces.Interfaces;
    using Problem_10.Explicit_Interfaces.Models;

    public class Program
    {
        private static void Main(string[] args)
        {
            var names = new List<string>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var inputParams = input.Split();

                var name = inputParams[0];
                var country = inputParams[1];
                var age = int.Parse(inputParams[2]);

                var person = new Citizen(name, country, age);
                names.Add(((IPerson)person).GetName());
                names.Add(((IResident)person).GetName());
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
