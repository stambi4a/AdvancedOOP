namespace Problem_05.Generic_Count_Method_Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

            var elementToCompare = Console.ReadLine();
            var countGreaterElements = box.GetCountGreaterElements(box.Elements, elementToCompare);
            Console.WriteLine(countGreaterElements);
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

        public int GetCountGreaterElements<T>(List<T> list, T element) where T:IComparable<T>
        {
            var greaterElementsCount = list.Count(listElement => listElement.CompareTo(element) > 0);

            return greaterElementsCount;
        }
    }
}
