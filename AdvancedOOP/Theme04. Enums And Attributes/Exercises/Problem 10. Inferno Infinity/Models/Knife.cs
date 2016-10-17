namespace Problem_10.Inferno_Infinity.Models
{
    using Problem_10.Inferno_Infinity.Enums;

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
