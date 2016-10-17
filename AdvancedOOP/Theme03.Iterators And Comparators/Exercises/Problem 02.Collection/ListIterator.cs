namespace Problem_02.Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Resources;

    public class ListIterator : IEnumerable<string>
    {
        private IList<string> collection;

        private int currentIndex;
        public ListIterator(IList<string> elements)
        {
            this.collection = elements;
            this.Reset();
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

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ",this.collection));
        }

        public IEnumerator<string> GetEnumerator()
        {
            this.Reset();
            for (var i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[this.currentIndex];
                this.Move();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Reset()
        {
            this.currentIndex = 0;
        }
    }
}
