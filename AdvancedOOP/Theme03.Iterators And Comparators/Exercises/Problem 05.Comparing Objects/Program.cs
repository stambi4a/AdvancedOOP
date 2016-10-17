namespace Problem_05.Comparing_Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static void Main(string[] args)
        {
            var listPeople = new List<Person>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                var input = line.Split();
                var name = input[0];
                var age = int.Parse(input[1]);
                var town = input[2];
                var somePerson = new Person(name, age, town);
                listPeople.Add(somePerson);
            }

            var index = int.Parse(Console.ReadLine());
            var peopleCount = listPeople.Count;
            if (index < 0 || index >= peopleCount)
            {
                Console.WriteLine("No matches");
                return;
            }

            var person = listPeople[index];
            var equals = listPeople.Count(somePerson => somePerson.CompareTo(person) == 0);
            var notEquals = peopleCount - equals;
            Console.WriteLine(equals + " " + notEquals + " " + peopleCount);

        }
    }

    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; }

        public int Age { get; }

        public string Town { get; }

        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age - other.Age;
            }

            if (result == 0)
            {
                result = this.Town.CompareTo(other.Town);
            }

            return result;
        }
    }
}
