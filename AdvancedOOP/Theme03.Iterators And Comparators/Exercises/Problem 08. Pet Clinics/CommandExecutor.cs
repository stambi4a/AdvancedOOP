namespace Problem_08.Pet_Clinics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandExecutor
    {
        public void Execute(HashSet<Pet> pets, HashSet<Clinic> clinics, string[] input)
        {
            var commandName = input[0];
            switch (commandName)
            {
                case "Create":
                    {
                        var objectToCreateType = input[1];
                        if (objectToCreateType == "Pet")
                        {
                            var name = input[2];
                            var age = int.Parse(input[3]);
                            var type = input[4];
                            var pet = new Pet(name, age, type);
                            pets.Add(pet);
                            return;
                        }
                        else
                        {
                            var name = input[2];
                            var capacity = int.Parse(input[3]);
                            var clinic = new Clinic(name, capacity);
                            clinics.Add(clinic);
                        }
                    }

                    break;
                case "Add":
                    {
                        var pet = pets.FirstOrDefault(animal=>animal.Name == input[1]);
                        var clinic = clinics.FirstOrDefault(clinik=>clinik.Name == input[2]);
                        var result = clinic.AddPet(pet);
                        Console.WriteLine(result);
                    }

                    break;
                case "Release":
                    {
                        var clinic = clinics.FirstOrDefault(clinik => clinik.Name == input[1]);
                        var result = clinic.Release();
                        Console.WriteLine(result);
                    }

                    break;
                case "HasEmptyRooms":
                    {
                        var clinic = clinics.FirstOrDefault(clinik => clinik.Name == input[1]);
                        var result = clinic.HasEmptyRooms();
                        Console.WriteLine(result);
                    }

                    break;
                case "Print":
                    {
                        var clinic = clinics.FirstOrDefault(clinik => clinik.Name == input[1]);
                        if (input.Length == 2)
                        {
                            clinic.Print();
                            return;
                        }

                        var roomIndex = int.Parse(input[2]);
                        clinic.Print(roomIndex);
                    }

                    break;

            }
        }
    }
}
