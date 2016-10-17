namespace Problem_10.Inferno_Infinity.Core
{
    using System;
    using System.Linq;

    using Problem_10.Inferno_Infinity.Data;

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
                        weaponsController.Print();
                        return true;
                    }

                default:
                    throw new ArgumentException("Invalid Command Name!");
            }
        }
    }
}
