namespace Problem_05.Border_Control
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
            var detainedSubjects = DetainSubjects(subjects, fakeIdEnding);
            PrintDetainedSubjects(detainedSubjects);
        }

        private static void PrintDetainedSubjects(IEnumerable<ISubject> detainedSubjects)
        {
            Console.WriteLine(string.Join(Environment.NewLine, detainedSubjects));
        }
        private static  ICollection<ISubject> InitialiseSubjects()
        {
            var subjects = new List<ISubject>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var subjectParams = input.Split();
                if (subjectParams.Length == 3)
                {
                    var age = int.Parse(subjectParams[1]);
                    var subject = new Citizen(subjectParams[0], age, subjectParams[2]);
                    subjects.Add(subject);
                }
                else
                {
                    var subject = new Robot(subjectParams[0], subjectParams[1]);
                    subjects.Add(subject);
                }
            }

            return subjects;
        }

        private static IEnumerable<ISubject> DetainSubjects(ICollection<ISubject> subjects, string fakeIdEnding)
        {
            return subjects.Where(subject => subject.CheckFakeId(fakeIdEnding)).ToList();
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
        string Name { get; }
        int Age { get; }
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

    public class Citizen : Subject, ICitizen
    {
        public Citizen(string name, int age, string id)
            : base(id)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }
        public int Age { get; }
    }
}
