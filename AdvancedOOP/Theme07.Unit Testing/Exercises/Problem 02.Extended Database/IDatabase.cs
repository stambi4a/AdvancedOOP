namespace Problem_02.Extended_Database
{
    public interface IDatabase
    {
        void AddPerson(Person person);
        Person[] Fetch();
        IPerson FindById(int id);
        IPerson FindByUsername(string userName);
        void RemovePerson();
    }
}