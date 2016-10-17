namespace Problem_06.Mirror_Image.Interfaces
{
    using Problem_06.Mirror_Image.Events;

    public interface IWizard
    {
        string Name { get; }

        int Id { get; }

        event CastMagicEventHandler CastMagic;
        int MagicalPower { get; }

        void Cast(object sender, CastMagicEventArgs args);
    }
}
