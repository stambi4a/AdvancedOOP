using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProblem_03.ListIterator
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;

    using Problem_03.List_Iterator;

    [TestClass]
    public class TestListIterator
    {
        private ListIterator iterator;

        [TestInitialize]
        private void Initialize(IList<string> strings)
        {
            this.iterator = new ListIterator(strings);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CreateListIteratorWithOneOrMoreNullElementsShouldThrowException()
        {
            var collection = new List<string> { "null", null };
            this.Initialize(collection);
        }

        [TestMethod]
        public void MoveInListIteratorWithEmptyCollectionShouldReturnFalse()
        {
            var collection = new List<string> ();
            this.Initialize(collection);
            var result = this.iterator.Move();
            Assert.IsFalse(result, "Empty collection should not be iterated!");
        }

        [TestMethod]
        public void MoveInListIteratorWithNonEmptyCollectionShouldReturnTrueFor4Times()
        {
            var collection = new List<string> {"Java", "CSharp", ".Net", "Entity", "WPF"};
            this.Initialize(collection);
            for (var i = 0; i < 4; i++)
            {
                var result = this.iterator.Move();
                Assert.IsTrue(result, "Non empty collection should allow to be iterated as many times as its element count!");
            }
        }

        [TestMethod]
        public void MoveInListIteratorAsManyTimesAsIteratorCollectionCountShouldReturnFalseLastTime()
        {
            var collection = new List<string> { "Java", "CSharp", ".Net", "Entity", "WPF" };
            this.Initialize(collection);
            for (var i = 0; i < 4; i++)
            {
                this.iterator.Move();
            }

            var result = this.iterator.Move();
            Assert.IsFalse(result, "Move more times than count should return false");
        }

        [TestMethod]
        public void MoveOnceShouldMoveToIndex1()
        {
            var collection = new List<string> { "Java", "WPF"};
            this.Initialize(collection);
            
            this.iterator.Move();
            var builder = new StringBuilder();
            Console.SetOut(new StringWriter(builder));
            this.iterator.Print();
            var result = builder.ToString();
            Assert.AreEqual("WPF" + Environment.NewLine, result, "Move once should move to the next index");
        }

        [TestMethod]
        public void Move5TimesShouldMoveToIndex5()
        {
            var collection = new List<string> { "Java", "CSharp", ".Net", "Entity", "WPF", "WCF" };
            this.Initialize(collection);
            for (var i = 0; i < collection.Count - 1; i++)
            {
                this.iterator.Move();
            }

            var builder = new StringBuilder();
            Console.SetOut(new StringWriter(builder));
            this.iterator.Print();
            var result = builder.ToString();
            Assert.AreEqual("WCF" + Environment.NewLine, result, "Move many times should move to the correct index");
        }

        [TestMethod]
        public void MoveAsManyTimesAsCollectionCountShouldStayAtLastIndex()
        {
            var collection = new List<string> { "Java", "CSharp", ".Net", "Entity", "WPF", "WCF" };
            this.Initialize(collection);
            for (var i = 0; i < collection.Count; i++)
            {
                this.iterator.Move();
            }

            var builder = new StringBuilder();
            Console.SetOut(new StringWriter(builder));
            this.iterator.Print();
            var result = builder.ToString();
            Assert.IsTrue(result == "WCF" + Environment.NewLine,
                string.Format($"{result} should be the same as \"WCF\""));
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void PrintEmptyCollectionShouldThrowProperException()
        {
            var collection = new List<string>();
            this.Initialize(collection);
            
            this.iterator.Print();
        }

        [TestMethod]
        public void PrintCollectionShouldPrintCorrectElement()
        {
            var collection = new List<string> { "Java", "CSharp", ".Net", "Entity", "WPF", "WCF" };
            this.Initialize(collection);
            for (var i = 0; i < collection.Count - 1 ; i++)
            {
                this.iterator.Move();
            }

            var builder = new StringBuilder();
            Console.SetOut(new StringWriter(builder));
            this.iterator.Print();
            var result = builder.ToString();
            Assert.IsTrue(result == "WCF" + Environment.NewLine, string.Format($"{result} should be the same as \"WCF\""));
        }
    }
}
