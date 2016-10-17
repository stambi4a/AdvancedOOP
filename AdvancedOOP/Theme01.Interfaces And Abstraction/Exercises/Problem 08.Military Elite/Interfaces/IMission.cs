namespace Problem_08.Military_Elite.Interfaces
{
    using Problem_08.Military_Elite.Enums;

    public interface IMission
    {
        string CodeName { get; }

        string State { get; set; }

        void CompleteMission();

    }
}
