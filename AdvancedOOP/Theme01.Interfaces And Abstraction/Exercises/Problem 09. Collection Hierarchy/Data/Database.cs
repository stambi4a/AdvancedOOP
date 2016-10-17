namespace Problem_09.Collection_Hierarchy.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Problem_09.Collection_Hierarchy.Interfaces;
    using Problem_09.Collection_Hierarchy.Models;

    public class Database : IDatabase
    {
        public Database()
        {
            this.AddCollection = new AddCollection();
            this.AddRemoveCollection = new AddRemoveCollection();
            this.MyList = new MyList();
        }

        public IAddCollection AddCollection { get; }

        public IAddRemoveCollection AddRemoveCollection { get; }

        public IMyList MyList { get; }

        public void AddElements(IReadOnlyList<string> elements)
        {
            this.AddElementsToCollection(elements, this.AddCollection);
            this.AddElementsToCollection(elements, this.AddRemoveCollection);
            this.AddElementsToCollection(elements, this.MyList);
        }

        public void RemoveElements(int countRemovedElements)
        {
            this.RemoveElementsFromCollection(countRemovedElements, this.AddRemoveCollection);
            this.RemoveElementsFromCollection(countRemovedElements, this.MyList);
        }

        private void AddElementsToCollection(IReadOnlyList<string> elements, IAddCollection collection)
        {
            if (elements == null) throw new ArgumentNullException(nameof(elements));
            var indicesAdded = new List<int>();
            foreach (var element in elements)
            {
                indicesAdded.Add(collection.Add(element));
            }

            Console.WriteLine(string.Join(" ", indicesAdded));
        }

        private void RemoveElementsFromCollection(int countRemovedElements, IAddRemoveCollection collection)
        {
            var removedElements = new List<string>();
            for (var i = 0; i < countRemovedElements; i++)
            {
                removedElements.Add(collection.Remove());
            }
            
            Console.WriteLine(string.Join(" ", removedElements));
        }

        public void GetCount()
        {
            var count = this.MyList.GetCount();
            Console.WriteLine(count);
        }
    }
}
