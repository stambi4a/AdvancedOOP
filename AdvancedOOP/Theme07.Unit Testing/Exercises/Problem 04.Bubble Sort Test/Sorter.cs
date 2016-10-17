namespace Problem_04.Bubble_Sort_Test
{
    using System;
    public abstract class Sorter<T> : ISorter<T> where T:IComparable
    {
        public abstract void Sort(T[] elements);
    }
}
