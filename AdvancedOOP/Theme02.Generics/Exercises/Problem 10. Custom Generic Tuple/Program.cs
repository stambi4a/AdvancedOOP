namespace Problem_10.Custom_Generic_Tuple
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var firstTupleFirstItem= input[0] + " " + input[1];
            var firstTupleSecondItem = input[2];
            var firstTuple = new GenericTuple<string, string>(firstTupleFirstItem, firstTupleSecondItem);
            Console.WriteLine(firstTuple);

            input = Console.ReadLine().Split();
            var secondTupleFirstItem = input[0];
            var secondTupleSecondItem = int.Parse(input[1]);
            var secondTuple = new GenericTuple<string, int>(secondTupleFirstItem, secondTupleSecondItem);
            Console.WriteLine(secondTuple);

            input = Console.ReadLine().Split();
            var thirdTupleFirstItem = int.Parse(input[0]);
            var thirdTupleSecondItem = double.Parse(input[1]);
            var thirdTuple = new GenericTuple<int, double>(thirdTupleFirstItem, thirdTupleSecondItem);
            Console.WriteLine(thirdTuple);
        }
    }

    public class GenericTuple<T1, T2>
    {
        private readonly T1 item1;

        private readonly T2 item2;

        public GenericTuple(T1 value1, T2 value2)
        {
            this.item1 = value1;
            this.item2 = value2;
        }

        public override string ToString()
        {
            return this.item1 + " -> " + this.item2;
        }
    }
}
