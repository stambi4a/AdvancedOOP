namespace Problem_10.Inferno_Infinity.Data
{
    using System;

    using Problem_10.Inferno_Infinity.Factories;
    using Problem_10.Inferno_Infinity.Models;

    public class WeaponsController
    {
        private readonly WeaponsDatabase database;

        public WeaponsController(WeaponsDatabase database)
        {
            this.database = database;
        }

        public void CreateWeapon(string[] input)
        {
            var weapon = WeaponFactory.CreateWeapon(input);
            this.AddWeapon(weapon);
        }

        public void AddGem(string gemParams, int socketIndex, string weaponName)
        {
            var weapon = this.database.Weapons[weaponName];
            if (weapon.SocketCount <= socketIndex || socketIndex < 0)
            {
                return;
            }

            Gem gem = GemFactory.CreateGem(gemParams);
            weapon.Sockets[socketIndex] = gem;
        }

        public void RemoveGem(int socketIndex, string weaponName)
        {
            var weapon = this.database.Weapons[weaponName];
            if (weapon.SocketCount <= socketIndex || socketIndex < 0)
            {
                return;
            }

            weapon.Sockets[socketIndex] = null;
        }

        public void PrintWeapon(string weaponName)
        {
            var weapon = this.database.Weapons[weaponName];
            weapon.Print();
            this.database.Weapons.Remove(weaponName);
        }

        public void Print()
        {
            foreach (var weapon in this.database.Weapons.Values)
            {
                weapon.Print();
            }
        }

        private void AddWeapon(Weapon weapon)
        {
            if (!this.database.Weapons.ContainsKey(weapon.Name))
            {
                this.database.Weapons.Add(weapon.Name, weapon);
            }
        }
    }
}
