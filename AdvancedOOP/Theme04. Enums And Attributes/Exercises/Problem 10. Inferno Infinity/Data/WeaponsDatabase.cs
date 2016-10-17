namespace Problem_10.Inferno_Infinity.Data
{
    using System.Collections.Generic;

    using Problem_10.Inferno_Infinity.Models;

    public class WeaponsDatabase
    {
        public WeaponsDatabase()
        {
            this.Weapons = new Dictionary<string, Weapon>();
        }

        public IDictionary<string, Weapon> Weapons;
    }
}
