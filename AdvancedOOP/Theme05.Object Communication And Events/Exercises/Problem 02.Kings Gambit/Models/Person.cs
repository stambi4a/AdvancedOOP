namespace Problem_02.Kings_Gambit.Models
{
    using Problem_02.Kings_Gambit.Interfaces;
    public abstract class Person : IPerson
    {
        protected Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
