namespace Problem_06.Birthday_Celebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static void Main(string[] args)
        {
            var subjects = InitialiseSubjects();
            var fakeIdEnding = Console.ReadLine();
            var detainedSubjects = FindSubjectsBornInAgivenYear(subjects, fakeIdEnding);
            PrintDetainedSubjects(detainedSubjects);
        }

        private static void PrintDetainedSubjects(IEnumerable<IBirthable> detainedSubjects)
        {
            var birthdays = detainedSubjects.Select(subject => subject.Birthday);
            Console.WriteLine(string.Join(Environment.NewLine, birthdays));
        }
        private static ICollection<IBirthable> InitialiseSubjects()
        {
            var subjects = new List<IBirthable>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var subjectParams = input.Split();
                if (subjectParams[0] == "Pet")
                {
                    var subject = new Pet(subjectParams[1], subjectParams[2]);
                    subjects.Add(subject);
                }
                else if(subjectParams[0] == "Citizen")
                {
                    var age = int.Parse(subjectParams[2]);
                    var subject = new Citizen(subjectParams[1], age, subjectParams[4], subjectParams[3]);
                    subjects.Add(subject);
                }
            }

            return subjects;
        }

        private static IEnumerable<IBirthable> FindSubjectsBornInAgivenYear(ICollection<IBirthable> subjects, string year)
        {
            return subjects.Where(subject => subject.CheckDateYear(year)).ToList();
        }
    }



    public interface ISubject
    {
        string Id { get; }

        bool CheckFakeId(string fakeIdEnding);
    }

    public interface IRobot
    {
        string Model { get; }
    }

    public interface ICitizen
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

    public class Robot : Subject, IRobot
    {
        public Robot(string model, string id)
            : base(id)
        {
            this.Model = model;
        }

        public string Model { get; }
    }

    public class Citizen : Subject, ICitizen, INameable, IBirthable
    {
        public Citizen(string name, int age, string birthday, string id)
            : base(id)
        {
            this.Name = name;
            this.Age = age;
            this.Birthday = birthday;
        }

        public string Name { get; }
        public int Age { get; }
        public string Birthday { get; }

        public bool CheckDateYear(string year)
        {
            return this.Birthday.EndsWith(year);
        }
    }

    public class Pet: INameable, IBirthable
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; }

        public string Birthday { get; }

        public bool CheckDateYear(string year)
        {
            return this.Birthday.EndsWith(year);
        }
    }
}
