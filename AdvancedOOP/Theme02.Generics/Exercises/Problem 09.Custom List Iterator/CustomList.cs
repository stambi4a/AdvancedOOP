namespace Problem_09.Custom_List_Iterator
{
    using System;
    using System.CodeDom;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class CustomList<T> : IEnumerable<T> where T: IComparable<T>
    {
        private int capacity;

        private int count;

        private T[] elements;
        public CustomList(int capacity = 1)
        {
            this.count = 0;
            this.capacity = capacity;
            this.elements = new T[this.capacity];
        }
        public void Add(T element)
        {
            if (this.count == this.capacity)
            {
                this.capacity *= 2;
                var newArrayOfElements = new T[this.capacity];
                Array.Copy(this.elements, newArrayOfElements, this.count);
                this.elements = newArrayOfElements;
            }

            this.elements[this.count++] = element;
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException($"index should be in the range[0..{this.count - 1}");
            }

            var element = this.elements[index];
            Array.Copy(this.elements, index + 1, this.elements, index, this.count - index - 1);
            this.count--;

            return element;
        }

        public bool Contains(T element)
        {
            for (var i = 0; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(element) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= this.count || 
                secondIndex < 0 || secondIndex >= this.count)
            {
                throw new IndexOutOfRangeException($"index should be in the range[0..{this.count - 1}");
            }

            var swapElement = this.elements[firstIndex];
            this.elements[firstIndex] = this.elements[secondIndex];
            this.elements[secondIndex] = swapElement;
        }

        public int CountGreaterThan(T element)
        {
            var countGreater = 0;
            for (var i = 0; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(element) > 0)
                {
                    countGreater++;
                }
            }

            return countGreater;
        }

        public T Max()
        {
            return this.elements.Max();
        }

        public T Min()
        {
            return this.elements.Min();
        }

        public void Sort()
        {
            var newArrayOfElements = new T[this.count];
            Array.Copy(this.elements, newArrayOfElements, this.count);
            Array.Sort(newArrayOfElements);
            Array.Copy(newArrayOfElements, this.elements, this.count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)this.elements.GetEnumerator();
        }

        public override string ToString()
        { 
            var elementsToPrint = this.elements.Take(this.count);
            return string.Join(Environment.NewLine, elementsToPrint);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
