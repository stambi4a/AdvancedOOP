namespace Problem_02.Generic_Box_Of_Integer
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var countNumbers = int.Parse(Console.ReadLine());
            for (var i = 0; i < countNumbers; i++)
            {
                var expression = int.Parse(Console.ReadLine());
                var box = new Box<int>(expression);
                Console.WriteLine(box);
            }
        }
    }
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; }

        public override string ToString()
        {
            return this.Value.GetType().FullName + ": " + this.Value;
        }
    }

}
