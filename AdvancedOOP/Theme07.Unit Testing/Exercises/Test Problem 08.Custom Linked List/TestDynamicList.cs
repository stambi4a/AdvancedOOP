using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Problem_08.Custom_Linked_List
{
    using CustomLinkedList;

    [TestClass]
    public class TestDynamicList
    {
        private DynamicList<int> dynamicList;

        [TestInitialize]
        private void Initialize()
        {
            this.dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        public void CountOfEmptyListShouldBeZero()
        {
            this.Initialize();
            var count = this.dynamicList.Count;
            Assert.AreEqual(0, count, "Count of Empty List should be 0!");
        }

        [TestMethod]
        public void CountOfNotEmptyListShouldReturnCorrectValue()
        {
            this.Initialize();
            for (var i = 0; i < 10; i++)
            {
                this.dynamicList.Add(i);
            }

            var count = this.dynamicList.Count;
            Assert.AreEqual(10, count, "Count of elemenst in the list should be 10!");
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void IndexerGetterWithNegativeIndexShouldThrowException()
        {
            this.Initialize();
            var element = this.dynamicList[-1];
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void IndexerGetterWithIndexEqualToCountShouldThrowException()
        {
            this.Initialize();
            for (var i = 0; i < 5; i++)
            {
                this.dynamicList.Add(i);
            }

            var element = this.dynamicList[5];
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void IndexerGetterWithIndexBiggerThanCountShouldThrowException()
        {
            this.Initialize();
            for (var i = 0; i < 5; i++)
            {
                this.dynamicList.Add(i);
            }

            var element = this.dynamicList[6];
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void IndexerSetterWithNegativeIndexShouldThrowException()
        {
            this.Initialize();
            this.dynamicList[-1] = 10;
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void IndexerSetterWithIndexEqualToCountShouldThrowException()
        {
            this.Initialize();
            for (var i = 0; i < 5; i++)
            {
                this.dynamicList.Add(i);
            }

            this.dynamicList[5] = 10;
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void IndexerSetterWithIndexBiggerThanCountShouldThrowException()
        {
            this.Initialize();
            for (var i = 0; i < 5; i++)
            {
                this.dynamicList.Add(i);
            }

            this.dynamicList[6] = 10;
        }

        [TestMethod]
        public void ElementAddedToEmptyListShouldBeTheOnlyElement()
        {
            this.Initialize();
            this.dynamicList.Add(10);

            var element = this.dynamicList[0];
            Assert.AreEqual(10, element, "Added element in empty list should be the first element!");
        }

        [TestMethod]
        public void ElementAddedToNonEmptyListShouldBeTheLastElement()
        {
            this.Initialize();
            for (var i = 0; i < 5; i++)
            {
                this.dynamicList.Add(i);
            }

            for (var i = 4; i >= 1; i--)
            {
                var element = this.dynamicList[i];
                Assert.AreEqual(i, element, "Added element in non empty list should be the first element!");
            }
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void RemoveAtNegativeIndexShouldThrowProperException()
        {
            this.Initialize();
            this.dynamicList.RemoveAt(-1);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void RemoveAtIndexEqualToListCountShouldThrowProperException()
        {
            this.Initialize();
            for (var i = 0; i < 5; i++)
            {
                this.dynamicList.Add(i);
            }

            this.dynamicList.RemoveAt(5);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void RemoveAtIndexBiggerThanListCountShouldThrowProperException()
        {
            this.Initialize();
            for (var i = 0; i < 5; i++)
            {
                this.dynamicList.Add(i);
            }

            this.dynamicList.RemoveAt(6);
        }

        [TestMethod]
        public void RemoveAtIndexShouldRemoveProperUnit()
        {
            this.Initialize();
            for (var i = 0; i < 10; i++)
            {
                this.dynamicList.Add(i);
            }

            for (var i = 8; i >= 0; i--)
            {
                this.dynamicList.RemoveAt(i);
                var element = this.dynamicList[i];
                Assert.AreEqual(9, element, "Element at index of removed element should be next element");
            }
        }

        [TestMethod]
        public void RemoveAtLastIndexShouldChangeCountProperly()
        {
            this.Initialize();
            for (var i = 0; i < 10; i++)
            {
                this.dynamicList.Add(i);
            }

            this.dynamicList.RemoveAt(9);
            var count = this.dynamicList.Count;
            Assert.AreEqual(9, count, "Count should be 9");
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void RemoveAtLastIndexShouldRemoveProperElement()
        {
            this.Initialize();
            for (var i = 0; i < 10; i++)
            {
                this.dynamicList.Add(i);
            }

            this.dynamicList.RemoveAt(9);
            var element = this.dynamicList[9];
        }

        [TestMethod]
        public void RemoveNonContainedElementShouldReturnProperValue()
        {
            this.Initialize();
            for (var i = 0; i < 10; i++)
            {
                this.dynamicList.Add(i);
            }

            var result = this.dynamicList.Remove(15);
            Assert.AreEqual(-1, result, "Returned value shold be -1");
        }

        [TestMethod]
        public void RemoveNonContainedElementShouldReturnProperIndex()
        {
            this.Initialize();
            for (var i = 0; i < 10; i++)
            {
                this.dynamicList.Add(i);
            }

            for (var i = 0; i < 10; i++)
            {
                var result = this.dynamicList.Remove(i);
                Assert.AreEqual(0, result, $"Returned value shold be {i}");
            }    
        }

        [TestMethod]
        public void IndexOfNonExistingElementShouldReturnProperValue()
        {
            this.Initialize();
            for (var i = 0; i < 10; i++)
            {
                this.dynamicList.Add(i);
            }

            var element = this.dynamicList.IndexOf(15);
            Assert.AreEqual(-1, element, "Returned index should be -1");
        }

        [TestMethod]
        public void IndexOfShouldReturnProperValue()
        {
            this.Initialize();
            for (var i = 0; i < 10; i++)
            {
                this.dynamicList.Add(i);
            }

            for (var i = 0; i < 10; i++)
            {
                var element = this.dynamicList.IndexOf(i);
                Assert.AreEqual(i, element, $"Returned index should be {i}");
            } 
        }

        [TestMethod]
        public void ContainsOfNonContainedElementShouldReturnProperValue()
        {
            this.Initialize();
            for (var i = 0; i < 10; i++)
            {
                this.dynamicList.Add(i);
            }

            var result = this.dynamicList.Contains(15);
            Assert.IsFalse(result, "Contains for non-conatined element should retuns false");
        }

        [TestMethod]
        public void ContainsOfContainedElementShouldReturnProperValue()
        {
            this.Initialize();
            for (var i = 0; i < 10; i++)
            {
                this.dynamicList.Add(i);
            }

            for (var i = 0; i < 10; i++)
            {
                var result = this.dynamicList.Contains(i);
                Assert.IsTrue(result, "Contains for non-conatined element should retuns false");
            }
           
        }
    }
}
