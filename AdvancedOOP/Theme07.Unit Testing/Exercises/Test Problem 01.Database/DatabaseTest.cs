namespace Test_Problem_01.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Problem_01.Database;

    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void CreateDatabaseWithoutElementsShouldCreateEmptyArray()
        {
            var database = new Database();
            var element = 100;

            var array = database.Fetch();
            Assert.IsTrue(array != null, "Database should create empty array!");
        }
        [TestMethod]
        public void CreateDatabaseWithElementsShouldCreateArrayWithGivenElements()
        {
            var database = new Database(1, 100, 1000, 1000000);

            var array = database.Fetch();
            CollectionAssert.AreEqual(new int[] {1, 100, 1000, 1000000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                 array, "Database should create array containing given elements!");
        }


        //[ExpectedException(typeof(InvalidOperationException))]
        //[TestMethod]
        //public void ArrayCapacityShouldBe16()
        //{
        //    var database = new Database();
        //}

        [TestMethod]
        public void AddToEmptyArrayShouldAddToFirstEmptyCell()
        {
            var database = new Database();
            var element = 100;
            database.AddElement(element);

            var array = database.Fetch();
            Assert.AreEqual(array[0], element, "First element of empty database elements array should be the added element!");
        }

        [TestMethod]
        public void AddShouldAddCorrectlyManyElements()
        {
            var database = new Database();
            var elements = new List<int>();
            for (var i = 1; i <= Database.ArrayCapacity; i++)
            {
                elements.Add(i);
            }

            foreach (var element in elements)
            {
                database.AddElement(element);
            }

            var array = database.Fetch();
            CollectionAssert.AreEqual(elements.ToArray(), array, "Elements in database should be added in the given");
        }

        [TestMethod]
        public void AddManyElementsShouldAddAllElements()
        {
            var database = new Database();
            var elements = new List<int>();
            for (var i = 1; i <= Database.ArrayCapacity; i++)
            {
                elements.Add(i);
            }

            foreach (var element in elements)
            {
                database.AddElement(element);
            }

            var array = database.Fetch();
            Assert.AreEqual(array.Length, Database.ArrayCapacity, "Added elements should be the same count");
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void Add17ElementsShouldThrowException()
        {
            var database = new Database();
            var elements = new List<int>();
            for (var i = 1; i <= Database.ArrayCapacity + 1; i++)
            {
                elements.Add(i);
            }

            foreach (var element in elements)
            {
                database.AddElement(element);
            }

            var array = database.Fetch();
            CollectionAssert.AreEqual(elements.ToArray(), array, "Elements in database should be added in the given order");
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void RemoveElementFromEmptyDatabaseShouldThrowException()
        {
            var database = new Database();
            var element = database.RemoveElement();
        }

        [TestMethod]
        public void RemoveElementShouldRemoveElementFromTheLastNonEmptyCell()
        {
            var database = new Database();
            database.AddElement(1);
            database.AddElement(2);
            var element = database.RemoveElement();
            Assert.AreEqual(2, element, "Removed element should be the last added element");
        }

        [TestMethod]
        public void FetchEmptyDatabaseShouldReturnArray()
        {
            var database = new Database();
            var array = database.Fetch();
            var typeName = array.GetType().Name;
            Assert.AreEqual("Int32[]", typeName, "Returned collection should be integer array!");
        }

        [TestMethod]
        public void FetchEmptyDatabaseShouldReturnEmptyArray()
        {
            var database = new Database();
            var array = database.Fetch();
            var compared = Enumerable.Repeat(0, Database.ArrayCapacity).ToArray();
            CollectionAssert.AreEqual(compared, array, "Returned collection from Database with no elements should be empty");
        }

        [TestMethod]
        public void FetchDatabaseWithElementsShouldReturnArrayWithSameElements()
        {
            var database = new Database();
            database.AddElement(1);
            database.AddElement(2);

            var array = database.Fetch();
            CollectionAssert.AreEqual(new int[] {1, 2, 0,0,0,0,0,0,0,0,0,0,0,0,0,0}, array, "Returned collection should return all added elements");
        }
    }
}
