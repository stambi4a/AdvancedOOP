using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProblem_02.ExtendedDatabase
{
    using System.Linq;

    using Problem_02.Extended_Database;

    [TestClass]
    public class TestDatabase
    {
        private IDatabase database;
        [TestInitialize]
        public void Initialize()
        {
            this.database = new Database();
        }
        [TestMethod]
        public void CreateNewDatabaseShouldCreateEmptyArrayOfPeople()
        {
            this.Initialize();
            var people = this.database.Fetch();
            var type = people.GetType().Name;
            Assert.AreEqual("Person[]", type);
            Assert.IsFalse(people.Any(person=>person != null), "Constructor should contain empty collection");
        }

        [TestMethod]
        public void AddPersonToEmptyArrayShouldAddToIndex0()
        {
            this.Initialize();
            var person = new Person("Sasho", 1);
            this.database.AddPerson(person);
            var people = this.database.Fetch();
            var returned = people[0];
            Assert.AreEqual(person, returned, "Constructo shold contain empty collection");
        }

        [TestMethod]
        public void AddPersonToNonEmptyArrayShouldAddToLastEmptyIndex()
        {
            this.Initialize();
            var person1 = new Person("Sasho", 1);
            var person2 = new Person("Misho", 2);
            var person3 = new Person("Tisho", 3);
            this.database.AddPerson(person1);
            this.database.AddPerson(person2);
            this.database.AddPerson(person3);
            var people = this.database.Fetch();
            var returned = people[2];
            Assert.AreEqual(person3, returned, "Constructor should contain empty collection");
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void AddPersonWithExistingNameShouldThrowException()
        {
            this.Initialize();
            var person1 = new Person("Sasho", 1);
            var person2 = new Person("Sasho", 2);
            this.database.AddPerson(person1);
            this.database.AddPerson(person2);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void AddPersonWithExistingIdShouldThrowException()
        {
            this.Initialize();
            var person1 = new Person("Sasho", 1);
            var person2 = new Person("Misho", 1);
            this.database.AddPerson(person1);
            this.database.AddPerson(person2);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void FindPersonByNonExistantNameShouldThrowException()
        {
            this.Initialize();
            var person1 = new Person("Stani", 1);
            this.database.AddPerson(person1);
            var person = this.database.FindByUsername("stan");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void FindPersonWithNullNameShouldThrowException()
        {
            this.Initialize();
            var person1 = new Person(null, 1);
            this.database.AddPerson(person1);
            var person = this.database.FindByUsername(null);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void FindPersonByNonExistantIdShouldThrowException()
        {
            this.Initialize();
            var person1 = new Person("Stani", 1);
            this.database.AddPerson(person1);
            var person = this.database.FindById(2);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void FindPersonWithNegativeIdShouldThrowException()
        {
            this.Initialize();
            var person1 = new Person(null, 1);
            this.database.AddPerson(person1);
            var person = this.database.FindById(-4);
        }
    }
}
