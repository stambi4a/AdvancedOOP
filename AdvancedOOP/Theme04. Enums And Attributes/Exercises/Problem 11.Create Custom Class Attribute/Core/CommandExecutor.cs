namespace Problem_11.Create_Custom_Class_Attribute.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Problem_11.Create_Custom_Class_Attribute.Data;

    public class CommandExecutor
    {
        public bool Execute(string[] commandParams, WeaponsController weaponsController)
        {
            var commandName = commandParams[0];
            switch (commandName)
            {
                case "Create":
                    {
                        weaponsController.CreateWeapon(commandParams.Skip(1).ToArray());
                        return false;
                    }

                case "Add":
                    {
                        var gemParams = commandParams[3];
                        var socketIndex = int.Parse(commandParams[2]);
                        var weaponName = commandParams[1];
                        weaponsController.AddGem(gemParams, socketIndex, weaponName);
                        return false;
                    }

                case "Remove":
                    {
                        var weaponName = commandParams[1];
                        var socketIndex = int.Parse(commandParams[2]);
                        weaponsController.RemoveGem(socketIndex, weaponName);
                        return false;
                    }

                case "Print":
                    {
                        var weaponName = commandParams[1];
                        weaponsController.PrintWeapon(weaponName);
                        return false;
                    }

                case "END":
                    {
                        return true;
                    }

                //case "Author":
                //    {
                //        Console.WriteLine($"Author: Pesho");
                //        return false;
                //    }

                //case "Revision":
                //    {
                //        Console.WriteLine($"Revision: 3");
                //        return false;
                //    }

                //case "Description":
                //    {
                //        Console.WriteLine($"Class description: Used for C# OOP Advanced Course - Enumerations and Attributes.");
                //        return false;
                //    }

                //case "Reviewers":
                //    {
                //        Console.WriteLine($"Reviewers: Pesho, Svetlio");
                //        return false;
                //    }

                //default:
                //    throw new ArgumentException("Invalid Command Name!");
                //    return true;
            }

            return this.GetAttributeProperties(commandName);
        }

        private bool GetAttributeProperties(string attrPropertie)
        {
            var attributes = Type.GetType("Problem_11.Create_Custom_Class_Attribute.Models.Weapon").GetCustomAttributes(typeof(TypeAttribute));
            switch (attrPropertie)
            {
                case "Author":
                    {
                        var attribute = attributes.FirstOrDefault() as TypeAttribute;
                        Console.WriteLine($"Author: {attribute.Author}");
                        return false;
                    }

                case "Revision":
                    {
                        var attribute = attributes.FirstOrDefault() as TypeAttribute;
                        Console.WriteLine($"Revision: {attribute.Revision}");
                        return false;
                    }

                case "Description":
                    {
                        var attribute = attributes.FirstOrDefault() as TypeAttribute;
                        Console.WriteLine($"Class description: {attribute.Description}");
                        return false;
                    }

                case "Reviewers":
                    {
                        var attribute = attributes.FirstOrDefault() as TypeAttribute;
                        Console.WriteLine(
                            $"Reviewers: {string.Join(", ", attribute.Reviewers)}");
                        return false;
                    }

                default:
                    //throw new ArgumentException("Invalid Command Name!");
                    return true;
            }
        }
    }
}
