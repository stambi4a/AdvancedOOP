namespace Problem_01.List_Iterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListIterator
    {
        private IList<string> collection;

        private int currentIndex;
        public ListIterator(IList<string> elements)
        {
            this.collection = elements;
            this.currentIndex = 0;
        }

        public void Move()
        {
            this.currentIndex++;
        }

        public bool HasNext()
        {
            return this.currentIndex < this.collection.Count - 1;
        }

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.collection[this.currentIndex]);
        }
    }
}
