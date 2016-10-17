namespace Problem_09.Collection_Hierarchy
{
    using System;

    using Problem_09.Collection_Hierarchy.Data;
    using Problem_09.Collection_Hierarchy.Interfaces;

    public class Program
    {
        private static void Main(string[] args)
        {
            IDatabase database = new Database();
            var elements = Console.ReadLine().Split();
            database.AddElements(elements);
            var countElementsToRemove = int.Parse(Console.ReadLine());
            database.RemoveElements(countElementsToRemove);
        }
    }
}
