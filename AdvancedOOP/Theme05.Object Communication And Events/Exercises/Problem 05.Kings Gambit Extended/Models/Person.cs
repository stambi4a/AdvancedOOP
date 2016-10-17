namespace Problem_05.Kings_Gambit_Extended.Models
{
    using Problem_05.Kings_Gambit_Extended.Interfaces;

    public abstract class Person : IPerson
    {
        protected Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
