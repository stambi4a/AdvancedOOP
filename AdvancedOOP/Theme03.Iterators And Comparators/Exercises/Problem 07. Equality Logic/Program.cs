namespace Problem_07.Equality_Logic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static void Main(string[] args)
        {
            var listOfSortedPeople= new SortedSet<Person>();
            var listOfHashedPeople = new HashSet<Person>();
            var countPeople = int.Parse(Console.ReadLine());
            for (var i = 0; i < countPeople; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person(name, age);
                listOfHashedPeople.Add(person);
                listOfSortedPeople.Add(person);
            }

            Console.WriteLine(listOfHashedPeople.Count);
            Console.WriteLine(listOfSortedPeople.Count);
        }
    }

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }

        public int Age { get; }
        public override bool Equals(object other)
        {
            var y = other as Person;
            return this.Name == y.Name && this.Age == y.Age;
        }

        public override int GetHashCode()
        {
            var hashCode =  this.Name.Length * 10000;
            hashCode = this.Name.Aggregate(hashCode, (current, letter) => current + letter);
            hashCode += this.Age * 10000;

            return hashCode;
        }

        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age - other.Age;
            }

            return result;
        }
    }
}
