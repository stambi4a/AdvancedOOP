namespace Problem_01.MarketPlace.Interfaces
{
    using Problem_01.MarketPlace.Enums;

    public interface IController
    {
        int CurrentProductId { get; }

        string Add(int size, string name, ProductType type);

        string Add(MarketType type, int id);

        string Edit(int id, string newName, int newSize);

        string Get(int size, string name);

        string Get(int size, string name, ProductType type);

        string Get(int id);

        string Get(MarketType type);
    }
}
