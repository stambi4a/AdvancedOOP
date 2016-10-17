namespace Problem_08.Pet_Clinics
{
    using System;
    using System.Collections.Generic;

    public class Launcher
    {
        private static void Main(string[] args)
        {
            var pets = new HashSet<Pet>();
            var clinics = new HashSet<Clinic>();
            var commandExecutor = new CommandExecutor();
            var commandCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < commandCount; i++)
            {
                try
                {
                    var input = Console.ReadLine().Split();
                    commandExecutor.Execute(pets, clinics, input);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid Operation!");
                }
               
            }

        }
    }
}
