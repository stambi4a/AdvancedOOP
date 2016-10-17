namespace Problem_11.Create_Custom_Class_Attribute.Models
{
    using Problem_11.Create_Custom_Class_Attribute.Enums;

    public class Knife : Weapon
    {
        private const int KnifeDefaultMinDamage = 3;
        private const int KnifeDefaultMaxDamage = 4;
        private const int KnifeDefaultSocketCount = 2;

        public Knife(string name, WeaponRarity rarity)
            : base(name, KnifeDefaultMinDamage, KnifeDefaultMaxDamage, KnifeDefaultSocketCount, rarity)
        {
        }
    }
}
