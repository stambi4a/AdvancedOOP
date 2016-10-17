using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_07.Food_Shortage
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var buyers = InitialiseBuyers();
            var totalboughtFood = BuyFood(buyers);
            Console.WriteLine(totalboughtFood);
        }

        private static int BuyFood(IDictionary<string, IBuyer> buyers)
        {
            var totalFoodQuantity = 0;
            while (true)
            {
                var buyerName = Console.ReadLine();
                if (buyerName == "End")
                {
                    break;
                }

                if (buyers.ContainsKey(buyerName))
                {
                    totalFoodQuantity += buyers[buyerName].BuyFood();
                }
            }

            return totalFoodQuantity;
        }

        private static IDictionary<string, IBuyer> InitialiseBuyers()
        {
            var subjects = new Dictionary<string, IBuyer>();
            var buyerCount = int.Parse(Console.ReadLine());
            var index = 1;
            while (index <= buyerCount)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var subjectParams = input.Split();
                var age = int.Parse(subjectParams[1]);
                var name = subjectParams[0];
                if (subjectParams.Length == 3)
                {
                    var subject = new Rebel(name, age, subjectParams[2]);
                    subjects.Add(name, subject);
                }
                else
                {
                    var subject = new Citizen(name, age, subjectParams[3], subjectParams[2]);
                    subjects.Add(name, subject);
                }
                index++;
            }

            return subjects;
        }
    }



    public interface ISubject
    {
        string Id { get; }

        bool CheckFakeId(string fakeIdEnding);
    }

    public interface IAgeable
    {
        int Age { get; }
    }

    public interface INameable
    {
        string Name { get; }
    }

    public interface IBirthable
    {
        string Birthday { get; }

        bool CheckDateYear(string year);
    }

    public interface IRebel
    {
        string Group { get; }
    }

    public interface IBuyer
    {
        int Food { get; }

        int BuyFood();
    }

    public abstract class Subject : ISubject
    {
        protected Subject(string id)
        {
            this.Id = id;
        }
        public string Id { get; protected set; }

        public override string ToString()
        {
            return this.Id;
        }

        public bool CheckFakeId(string fakeIdEnding)
        {
            return this.Id.EndsWith(fakeIdEnding);
        }
    }

    public class Citizen : Subject, IAgeable, INameable, IBirthable, IBuyer
    {
        private const int DefaultCitizenBoughtFoodQuantity = 10;
        public Citizen(string name, int age, string birthday, string id)
            : base(id)
        {
            this.Name = name;
            this.Age = age;
            this.Birthday = birthday;
            this.Food = 0;
        }

        public string Name { get; }
        public int Age { get; }
        public string Birthday { get; }

        public bool CheckDateYear(string year)
        {
            return this.Birthday.EndsWith(year);
        }

        public int Food { get; }

        public int BuyFood()
        {
            return DefaultCitizenBoughtFoodQuantity;
        }
    }

    public class Rebel: INameable, IAgeable, IRebel, IBuyer
    {
        private const int DefaultRebelBoughtFoodQuantity = 5;
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }
        public string Name { get; }

        public int Age { get; }

        public string Group { get; }

        public int Food { get; }

        public int BuyFood()
        {
            return DefaultRebelBoughtFoodQuantity;
        }
    }
}

