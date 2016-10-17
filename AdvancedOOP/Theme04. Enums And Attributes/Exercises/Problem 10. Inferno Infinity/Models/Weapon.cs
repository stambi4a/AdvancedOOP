namespace Problem_10.Inferno_Infinity.Models
{
    using System;
    using System.Linq;
    using System.Text;

    using Problem_10.Inferno_Infinity.Enums;

    public abstract class Weapon
    {
        protected Weapon(
            string name,
            int minDamage,
            int maxDamage,
            int socketsCount,
            WeaponRarity rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.SocketCount = socketsCount;
            this.Sockets = new Gem[this.SocketCount];
        }

        public string Name { get; protected set; }

        public int MinDamage { get; protected set; }

        public int MaxDamage { get; protected set; }

        public int TotalMinDamage { get; private set; }

        public int TotalMaxDamage { get; private set; }

        public int SocketCount { get; protected set; }

        public Gem[] Sockets { get; protected set; }

        public int Agility { get; protected set; }

        public int Vitality { get; protected set; }

        public int Strength { get; protected set; }

        public WeaponRarity Rarity { get; protected set; }

        private void CalculateMinDamage()
        {
            this.TotalMinDamage = this.MinDamage * (int)this.Rarity + this.Strength * 2 + this.Agility;
        }

        private void CalculateMaxDamage()
        {
            this.TotalMaxDamage = this.MaxDamage * (int)this.Rarity + this.Strength * 3 + this.Agility * 4;
        }

        private void CalculateStrength()
        {
            this.Strength = this.Sockets.Where(gem => gem != null).Sum(gem => gem.StrengthIncrease);
        }

        private void CalculateAgility()
        {
            this.Agility = this.Sockets.Where(gem => gem != null).Sum(gem => gem.AgilityIncrease);
        }

        private void CalculateVitality()
        {
            this.Vitality = this.Sockets.Where(gem => gem != null).Sum(gem => gem.VitalityIncrease);

        }

        public void Print()
        {
            this.CalculateStrength();
            this.CalculateAgility();
            this.CalculateVitality();
            this.CalculateMinDamage();
            this.CalculateMaxDamage();
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            //Axe of Misfortune: 24-46 Damage, +8 Strength, +3 Agility, +6 Vitality
            var weaponBuilder = new StringBuilder();
            weaponBuilder.Append(
                $"{this.Name}: {this.TotalMinDamage}-{this.TotalMaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality");

            return weaponBuilder.ToString();
        }
    }
}