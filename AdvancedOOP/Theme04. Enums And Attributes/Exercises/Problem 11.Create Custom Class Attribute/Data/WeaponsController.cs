namespace Problem_11.Create_Custom_Class_Attribute.Data
{
    using Problem_11.Create_Custom_Class_Attribute.Factories;
    using Problem_11.Create_Custom_Class_Attribute.Models;

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
            if (!this.database.Weapons.ContainsKey(weaponName))
            {
                return;
            }

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
            if (!this.database.Weapons.ContainsKey(weaponName))
            {
                return;
            }

            var weapon = this.database.Weapons[weaponName];
            if (weapon.SocketCount <= socketIndex || socketIndex < 0)
            {
                return;
            }

            weapon.Sockets[socketIndex] = null;
        }

        public void PrintWeapon(string weaponName)
        {
            if (!this.database.Weapons.ContainsKey(weaponName))
            {
                return;
            }

            var weapon = this.database.Weapons[weaponName];
            weapon.Print();
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
            this.database.Weapons.Add(weapon.Name, weapon);
        }
    }
}
