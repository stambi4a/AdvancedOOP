namespace Problem_03.Generic_Swap_Methos_Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static void Main(string[] args)
        {
            var box = new Box<string>();
            var countElements = int.Parse(Console.ReadLine());
            for (var i = 0; i < countElements; i++)
            {
                var element = Console.ReadLine();
                box.AddElement(element);
            }

            var indices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.SwapElements(indices[0], indices[1]);
            Console.WriteLine(box);
        }
    }

    public class Box<T>
    {
        public Box()
        {
            this.Elements = new List<T>();
        }

        public List<T> Elements { get; }

        public void AddElement(T element)
        {
            this.Elements.Add(element);
        }
        public void SwapElements(int firstIndex, int secondIndex)
        {
            var old = this.Elements[firstIndex];
            this.Elements[firstIndex] = this.Elements[secondIndex];
            this.Elements[secondIndex] = old;
        }

        public override string ToString()
        {
            var genericType = typeof(T);
            var type = genericType.FullName;
            var listBuilder = new StringBuilder();
            foreach (var element in this.Elements)
            {
                listBuilder.Append(type + ": ").Append(element).AppendLine();
            }

            return listBuilder.ToString();
        }
    }
}
