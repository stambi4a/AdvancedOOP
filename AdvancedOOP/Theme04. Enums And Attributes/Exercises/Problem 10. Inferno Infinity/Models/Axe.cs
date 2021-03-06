﻿namespace Problem_10.Inferno_Infinity.Models
{
    using Enums;

    public class Axe : Weapon
    {
        private const int AxeDefaultMinDamage = 5;
        private const int AxeDefaultMaxDamage = 10;
        private const int AxeDefaultSocketCount = 4;

        public Axe(string name, WeaponRarity rarity)
            : base(name, AxeDefaultMinDamage, AxeDefaultMaxDamage, AxeDefaultSocketCount, rarity)
        {
        }
    }
}
