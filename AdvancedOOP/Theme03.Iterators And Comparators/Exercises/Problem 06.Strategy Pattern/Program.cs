namespace Problem_06.Strategy_Pattern
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static void Main(string[] args)
        {
            var listPeopleSortedByName= new SortedSet<Person>(new NameComparator());
            var listPeopleSortedByAge = new SortedSet<Person>(new AgeComparator());
            var countPeople = int.Parse(Console.ReadLine());
            for (var i = 0; i < countPeople; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person(name, age);
                listPeopleSortedByName.Add(person);
                listPeopleSortedByAge.Add(person);
            }

            Console.WriteLine(string.Join(Environment.NewLine, listPeopleSortedByName));
            Console.WriteLine(string.Join(Environment.NewLine, listPeopleSortedByAge));
        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }

        public int Age { get; }

        public override string ToString()
        {
            return this.Name + " " + this.Age;
        }
    }

    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var result = x.Name.Length - y.Name.Length;
            if (result == 0)
            {
                result = x.Name.ToLower()[0] - y.Name.ToLower()[0];
            }

            return result;
        }
    }

    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var result = x.Age - y.Age;

            return result;
        }
    }
}
