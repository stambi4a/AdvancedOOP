namespace Problem_11.Create_Custom_Class_Attribute.Models
{
    using Problem_11.Create_Custom_Class_Attribute.Enums;

    public class Sword : Weapon
    {
        private const int SwordDefaultMinDamage = 4;
        private const int SwordDefaultMaxDamage = 6;
        private const int SwordDefaultSocketCount = 3;

        public Sword(string name, WeaponRarity rarity)
            : base(name, SwordDefaultMinDamage, SwordDefaultMaxDamage, SwordDefaultSocketCount, rarity)
        {
        }
    }
}
