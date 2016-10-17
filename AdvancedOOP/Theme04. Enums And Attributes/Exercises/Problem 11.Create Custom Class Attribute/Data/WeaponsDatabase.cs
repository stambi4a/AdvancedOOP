namespace Problem_11.Create_Custom_Class_Attribute.Data
{
    using System.Collections.Generic;

    using Problem_11.Create_Custom_Class_Attribute.Models;

    public class WeaponsDatabase
    {
        public WeaponsDatabase()
        {
            this.Weapons = new Dictionary<string, Weapon>();
        }
        public IDictionary<string, Weapon> Weapons;
    }
}
