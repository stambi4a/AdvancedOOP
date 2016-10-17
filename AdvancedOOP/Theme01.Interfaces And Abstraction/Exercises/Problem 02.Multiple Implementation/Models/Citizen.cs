namespace Problem_01.Define_An_Interface.Models
{
    using Problem_01.Define_An_Interface.Interfaces;

    using Problem_02.Multiple_Implementation.Interfaces;
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get;  }

        public int Age { get; }

        public string Id { get; }

        public string Birthdate { get; }
    }
}
