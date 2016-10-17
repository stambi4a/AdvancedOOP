namespace Problem_01.Define_An_Interface
{
    using System;
    using System.Reflection;

    using Interfaces;

    using Problem_01.Define_An_Interface.Models;

    internal class Program
    {
        static void Main(string[] args)
        {
            Type personInterface = typeof(Citizen).GetInterface("IPerson");
            PropertyInfo[] properties = personInterface.GetProperties();
            Console.WriteLine(properties.Length);
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            IPerson person = new Citizen(name, age);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
