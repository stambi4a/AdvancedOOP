namespace Problem_02.Extended_Database
{
    using System;
    using System.Linq;

    public class Database : IDatabase
    {
        public const int ArrayCapacity = 16;

        private Person[] people;

        private int currentIndex;
        public Database(params Person[] people)
        {
            this.people = new Person[ArrayCapacity];
            this.currentIndex = 0;
            this.AddInputELements(people);
        }

        private void AddInputELements(params Person[] people)
        {
            foreach (var person in people)
            {
                this.AddPerson(person);
            }
        }

        public void AddPerson(Person person)
        {
            if (this.people.Any(per => per != null &&  per.Id == person.Id))
            {
                throw new InvalidOperationException();
            }

            if (this.people.Any(per => per != null && per.Name == person.Name))
            {
                throw new InvalidOperationException();
            }
            this.people[this.currentIndex] = person;
            this.currentIndex++;
        }

        public void RemovePerson()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException();
            }

            this.people[this.currentIndex] = null;
            this.currentIndex--;
        }

        public IPerson FindById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var pers = this.people.FirstOrDefault(person => person != null && person.Id == id);
            if (pers == null)
            {
                throw new InvalidOperationException();
            }

            return pers;
        }

        public IPerson FindByUsername(string userName)
        {
            if (userName == null)
            {
                throw new ArgumentNullException();
            }

            var pers = this.people.FirstOrDefault(person => person != null && person.Name == userName);
            if (pers == null)
            {
                throw new InvalidOperationException();
            }

            return pers;
        }

        public Person[] Fetch()
        {
            return this.people;
        }
    }
}
