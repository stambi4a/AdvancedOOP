namespace Problem_04.Bubble_Sort_Test
{
    using System;
    public class BubbleSorter<T> : Sorter<T> where T: IComparable
    {
        public override void Sort(T[] elements)
        {
            var length = elements.Length;
            for (var i = 0; i < length - 1; i++)
            {
                for (var j = 0; j < length - i - 1; j++)
                {
                    if (elements[j].CompareTo(elements[j + 1]) > 0)
                    {
                        var old = elements[j + 1];
                        elements[j + 1] = elements[j];
                        elements[j] = old;
                    }
                }
            }
        }
    }
}
