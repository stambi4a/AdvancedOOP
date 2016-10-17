namespace Problem_08.Pet_Clinics
{
    using System.Linq;

    public class Pet
    {
        public Pet(string name, int age, string type)
        {
            this.Name = name;
            this.Age = age;
            this.Type = type;
        }

        public string Name { get; }

        public int Age { get; }

        public string Type { get; }

        public override bool Equals(object obj)
        {
            var other = obj as Pet;
            return this.Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.Length << 16 + this.Name.ToCharArray().Sum(letter => (int)letter);
        }
        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Type}";
        }
    }
}
