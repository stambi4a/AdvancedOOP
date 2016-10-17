namespace Problem_04.Bubble_Sort_Test
{
    public interface ISorter<in T>
    {
        void Sort(T[] elements);
    }
}