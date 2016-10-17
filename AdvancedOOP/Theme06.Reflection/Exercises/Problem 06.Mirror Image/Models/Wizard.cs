namespace Problem_06.Mirror_Image.Models
{
    using System;

    using Problem_06.Mirror_Image.Events;
    using Problem_06.Mirror_Image.Interfaces;
    public class Wizard : IWizard
    {
        public event CastMagicEventHandler CastMagic;
        public Wizard(string name, int magicalPower, int id)
        {
            this.Name = name;
            this.Id = id;
            this.MagicalPower = magicalPower;
        }

        public string Name { get; }

        public int Id { get; }

        public int MagicalPower { get; }

        public void Cast(object sender, CastMagicEventArgs args)
        {
            Console.WriteLine($"{this.Name} {this.Id} casts " + string.Format(args.Expression, this.MagicalPower));
            this.OnCastMagic(args);
        }

        public void OnCastMagic(CastMagicEventArgs args)
        {
            if (this.CastMagic == null)
            {
                args.CastedWizardsIds.Add(this.Id);
            }

            else
            {
                this.CastMagic(this, args);
            }
        }
    }
}
