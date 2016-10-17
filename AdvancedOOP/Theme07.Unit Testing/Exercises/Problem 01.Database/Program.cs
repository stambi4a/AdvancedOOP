namespace Problem_01.Database
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var database = new Database();
            var arr = database.Fetch();
            var type = arr.GetType().Name;
            Console.WriteLine(type);
        }
    }
}
