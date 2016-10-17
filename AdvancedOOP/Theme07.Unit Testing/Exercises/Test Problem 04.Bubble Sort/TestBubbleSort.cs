namespace Test_Problem_04.Bubble_Sort
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Problem_04.Bubble_Sort_Test;

    [TestClass]
    public class TestBubbleSort
    {
        private ISorter<int> sorter;

        [TestInitialize]
        public void Initialize()
        {
            this.sorter = new BubbleSorter<int>();
        }

        [TestMethod]
        public void SortEmptyArrayShouldMakeNoChangesInArray()
        {
            this.Initialize();
            var elements = new int[5];
            var newElements = new int[5];
            Array.Copy(elements, newElements, 5);
            this.sorter.Sort(elements);

            CollectionAssert.AreEqual(elements, newElements, "Sorting empty array should not change the array");
        }

        [TestMethod]
        public void SortArrayShouldSortArrayProperly()
        {
            this.Initialize();
            var elements = new [] { 7, 5, 10, 2, 0};
            this.sorter.Sort(elements);

            CollectionAssert.AreEqual(elements, new int[] { 0, 2, 5, 7, 10 }, "Sorting empty array should not change the array");
        }
    }
}
