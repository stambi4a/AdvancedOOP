namespace Problem_01.Generic_Box
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var countNumbers = int.Parse(Console.ReadLine());
            for (var i = 0; i < countNumbers; i++)
            {
                var expression = Console.ReadLine();
                var box = new Box<string>(expression);
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
