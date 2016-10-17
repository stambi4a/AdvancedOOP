namespace Problem_11.Threeuple
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var firstTupleFirstItem = input[0] + " " + input[1];
            var firstTupleSecondItem = input[2];
            var firstTupleThirdItem = input[3];
            var firstTuple = new GenericTuple<string, string, string>(firstTupleFirstItem, firstTupleSecondItem, firstTupleThirdItem);
            Console.WriteLine(firstTuple);

            input = Console.ReadLine().Split();
            var secondTupleFirstItem = input[0];
            var secondTupleSecondItem = int.Parse(input[1]);
            var secondTupleThirdItem = input[2] == "drunk" ? true : false;
            var secondTuple = new GenericTuple<string, int, bool>(secondTupleFirstItem, secondTupleSecondItem, secondTupleThirdItem);
            Console.WriteLine(secondTuple);

            input = Console.ReadLine().Split();
            var thirdTupleFirstItem = input[0];
            var thirdTupleSecondItem = double.Parse(input[1]);
            var thirdTupleThirdItem = input[2];
            var thirdTuple = new GenericTuple<string, double, string>(thirdTupleFirstItem, thirdTupleSecondItem, thirdTupleThirdItem);
            Console.WriteLine(thirdTuple);
        }
    }

    public class GenericTuple<T1, T2, T3>
    {
        private readonly T1 item1;

        private readonly T2 item2;

        private readonly T3 item3;

        public GenericTuple(T1 value1, T2 value2, T3 value3)
        {
            this.item1 = value1;
            this.item2 = value2;
            this.item3 = value3;
        }

        public override string ToString()
        {
            return this.item1 + " -> " + this.item2 + " -> " + this.item3;
        }
    }
}
