namespace Problem_02.Extended_Database
{
    public class Person : IPerson
    {
        public Person(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
