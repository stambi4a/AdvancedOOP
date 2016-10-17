namespace Problem_01.Database
{
    public interface IDatabase
    {
        void AddElement(int element);
        int[] Fetch();
        int RemoveElement();
    }
}