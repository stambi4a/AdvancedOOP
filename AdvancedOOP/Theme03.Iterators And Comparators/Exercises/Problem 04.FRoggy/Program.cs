namespace Problem_04.FRoggy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static void Main(string[] args)
        {
            var stones = Console.ReadLine().Split(new [] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            var lake = new Lake(stones);
            lake.Print();
        }
    }

    public class Lake : IEnumerable<long>
    {
        public Lake(long[] stones)
        {
            this.Stones = stones;
        }

        public long[] Stones { get; }
        public IEnumerator<long> GetEnumerator()
        {
            if (this.Stones.Length == 0)
            {
                yield break;
            }

            for (var i = 0; i < this.Stones.Length; i = i + 2)
            {
                yield return this.Stones[i];
            }

            var currentIndex = ((this.Stones.Length) / 2) * 2 - 1;
            for (var i = currentIndex; i >= 1; i = i - 2)
            {
                yield return this.Stones[i];
            }
        }

        public void Print()
        {
            Console.WriteLine(string.Join(", ", this));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
