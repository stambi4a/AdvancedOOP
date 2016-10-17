namespace Problem_02.Extended_Database
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            var database= new Database();
            var type = database.Fetch().GetType().Name;
            Console.WriteLine(type);
        }
    }
}
