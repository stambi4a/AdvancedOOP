namespace Problem_03.Ferrari
{
    using System;

    using Problem_03.Ferrari.Interfaces;
    using Problem_03.Ferrari.Models;

    public class Program
    {
        private static void Main(string[] args)
        {
            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }

            string driver = Console.ReadLine();
            ICar ferrari = new Ferrari(driver);
            Console.WriteLine(ferrari);
        }
    }
}
