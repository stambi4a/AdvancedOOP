namespace Problem_10.Inferno_Infinity.Factories
{
    using System;

    using Problem_10.Inferno_Infinity.Enums;
    using Problem_10.Inferno_Infinity.Models;

    public class WeaponFactory
    {
        public static Weapon CreateWeapon(string[] input)
        {
            var weaponParams = input[0].Split();
            var rarity = (WeaponRarity)Enum.Parse(typeof(WeaponRarity), weaponParams[0]);
            var type = weaponParams[1];
            var name = input[1];
            switch (type)
            {
                case "Axe":
                    {
                        return new Axe(name, rarity);
                    }

                case "Knife":
                    {
                        return new Knife(name, rarity);
                    }

                case "Sword":
                    {
                        return new Sword(name, rarity);
                    }

                default:
                    throw new ArgumentException("Non - existant weapon!");
            }
        }
    }
}
