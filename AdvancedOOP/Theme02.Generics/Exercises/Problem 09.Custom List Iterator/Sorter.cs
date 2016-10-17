namespace Problem_09.Custom_List_Iterator
{
    using System;

    public class Sorter
    {
        public static void Sort<T>(T[] elements) where T:IComparable<T>
        {
            Array.Sort(elements);
        }
    }
}
