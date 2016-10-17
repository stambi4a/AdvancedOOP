namespace Problem_08.Custom_List_Sorter
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
