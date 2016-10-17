namespace Problem_09.Collection_Hierarchy.Models
{
    using System.Collections.Generic;

    using Problem_09.Collection_Hierarchy.Interfaces;
    public class MyList : IMyList
    {
        public MyList()
        {
            this.Elements = new LinkedList<string>();
        }
        public int Add(string element)
        {
            this.Elements.AddFirst(element);

            return 0;
        }

        public LinkedList<string> Elements { get; }

        public int GetCount()
        {
            return this.Elements.Count;
        }

        public string Remove()
        {
            var element = this.Elements.First.Value;
            this.Elements.RemoveFirst();

            return element;
        }
    }
}
