namespace Problem_04.Bubble_Sort_Test
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var elements = new[] { 1, 4, 3, 10, 7, 11, 10, 8, 6, 0 };
            var sorter = new BubbleSorter<int>();
            sorter.Sort(elements);
            Console.WriteLine(string.Join(" < ", elements));
        }
    }
}
