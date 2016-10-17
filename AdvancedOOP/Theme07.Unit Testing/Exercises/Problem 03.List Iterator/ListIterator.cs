namespace Problem_03.List_Iterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListIterator : IListIterator
    {
        private IList<string> collection;

        private int currentIndex;
        public ListIterator(IList<string> elements)
        {
            this.Collection = elements;
            this.currentIndex = 0;
        }

        public IList<string> Collection
        {
            get
            {
                return this.collection;
            }

            set
            {
                if(value.Any(element=>element == null))
                {
                    throw new ArgumentNullException();
                }

                this.collection = value;
            }
        }
        public bool Move()
        {
            if (!this.HasNext())
            {
                return false;
            }

            this.currentIndex++;
            return true;
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
